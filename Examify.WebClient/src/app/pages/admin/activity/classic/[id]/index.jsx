import ManagerQuizWait from '~/features/admin/activity/classic/components/ManagerQuizWait';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import ManagerQuizStart from '~/features/admin/activity/classic/components/ManagerQuizStart';
import { useParams } from 'react-router';
import { useGetQuiz } from '~/features/quiz/api/quizzes/get-quiz';
import { Flex, Spin } from 'antd';
import { useEffect } from 'react';
import ModalEndQuiz from '~/features/admin/activity/classic/components/ModalEndQuiz';

const ManagerQuizPage = () => {
  const quizId = useParams().id;
  const { setQuiz } = useManagerQuizStore();

  const { data: quiz } = useGetQuiz({ id: quizId });

  useEffect(() => {
    if (quiz) setQuiz(quiz);
  }, [quiz, setQuiz]);

  if (!quiz?.code) {
    return (
      <Flex justify="center" align="center" className="h-screen">
        <Spin />
      </Flex>
    );
  }

  return (
    <>
      {quiz?.isStart ? <ManagerQuizStart /> : <ManagerQuizWait />}
      <ModalEndQuiz/>
    </>
  );
};

export default ManagerQuizPage;
