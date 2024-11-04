import { Button, Col, Flex, Layout, Row, Space } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import { useBoolean } from '~/hooks/useBoolean';
import AddQuestionModal from '~/features/quiz/components/question/AddQuestionModal';
import { useLoaderData } from 'react-router-dom';
import { getQuizQueryOptions, useGetQuiz } from '~/features/quiz/api/quizzes/get-quiz';
import { useGetQuestionByQuizId } from '~/features/quiz/api/questions/get-question-by-quiz-id';
import { useMemo } from 'react';
import QuestionList from '~/features/quiz/components/create-quiz/QuestionList';
import QuizBulkUpdateForm from '~/features/quiz/components/create-quiz/QuizBulkUpdateForm';
import QuizEditorHeader from '~/features/quiz/components/create-quiz/QuizEditorHeader';
const { Content } = Layout;

export const CreateQuizLoader =
  (queryClient) =>
  async ({ params }) => {
    const query = getQuizQueryOptions(params.quizId);
    return queryClient.getQueryData(query.queryKey) ?? (await queryClient.fetchQuery(query));
  };

const CreateQuizPage = () => {
  const initialQuizData = useLoaderData();

  const { data: questions = [] } = useGetQuestionByQuizId({
    quizId: initialQuizData.id,
  });

  const { data: quizData } = useGetQuiz({
    id: initialQuizData.id,
    queryConfig: { initialData: initialQuizData, enabled: false },
  });

  return (
    <Layout className="bg-[#f2f2f2] min-h-screen">
      <QuizEditorHeader quizData={quizData} />
      <Content className="w-full md:w-[95%] xl:w-[1280px] 2xl:w-[1280px] mx-auto mt-4 flex-grow">
        <Row gutter={[16]}>
          <Col span={6}>
            <QuizBulkUpdateForm quizId={initialQuizData.id} questions={questions} />
          </Col>
          <Col span={18}>
            <QuestionSection quizId={initialQuizData.id} questions={questions} />
          </Col>
        </Row>
      </Content>
    </Layout>
  );
};

const QuestionSection = ({ quizId, questions }) => {
  const {
    value: isAddQuestionModalOpen,
    setTrue: openAddQuestionModal,
    setFalse: closeAddQuestionModal,
  } = useBoolean();

  const points = useMemo(() => questions.reduce((acc, question) => acc + question.points, 0), [questions]);
  return (
    <>
      <Flex align="center" justify="space-between" className="mb-4">
        <Space className="text-lg">
          <span className="font-semibold">{questions.length} questions</span>
          <span>({points} points)</span>
        </Space>
        <Button color="primary" variant="filled" icon={<PlusOutlined />} onClick={openAddQuestionModal}>
          Add question
        </Button>
      </Flex>
      <QuestionList quizId={quizId} questions={questions} />
      <AddQuestionModal quizId={quizId} open={isAddQuestionModalOpen} onCancel={closeAddQuestionModal} />
    </>
  );
};

export default CreateQuizPage;
