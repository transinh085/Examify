import { useQueryClient } from '@tanstack/react-query';
import { Button, Flex, message, Pagination, Spin, Typography } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useCreateQuiz } from '~/features/quiz/api/quizzes/create-quiz';
import TestCard from '~/features/admin/mylibrary/components/TestCard';
import { useGetQuizUser } from '~/features/quiz/api/quizzes/get-quiz-user';

const TabContent = ({ params, setParams, isPublished = false }) => {
  const {
    data = {
      items: [],
    },
    isLoading,
  } = useGetQuizUser({
    isPublished,
    pageNumber: params.get('pageNumber') || 1,
    pageSize: params.get('pageSize') || 4,
  });

  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const createQuizMutation = useCreateQuiz({
    mutationConfig: {
      onSuccess: (data) => {
        queryClient.invalidateQueries('quiz-user');
        console.log('data', data);
        navigate(`/admin/quiz/${data.id}`);
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const createQuizHandler = () => {
    createQuizMutation.mutate();
  };

  if (isLoading)
    return (
      <Flex justify="center">
        <Spin />
      </Flex>
    );

  if (data.items.length === 0)
    return (
      <Flex className="space-y-3" vertical>
        <Flex justify="center">
          <img className="w-[200px] h-[200px]" src="https://cf.quizizz.com/image/emptystate-letscreate-v5.png" alt="" />
        </Flex>
        <Typography.Text className="text-center font-bold">Create your first quiz or lesson</Typography.Text>
        <Typography.Text className="text-center">
          Pull in questions from the Quizizz library or make your own. It’s quick and easy!
        </Typography.Text>
        <Flex justify="center">
          <Button
            loading={createQuizMutation.isPending}
            type="primary"
            className="font-bold text-lg"
            onClick={createQuizHandler}
            size="large"
          >
            Create a quiz
          </Button>
        </Flex>
      </Flex>
    );

  return (
    <Flex className="space-y-2" vertical>
      {data.items.map((item, index) => (
        <TestCard
          key={index}
          id={item.id}
          title={item.title}
          cover={item.cover}
          subject={item.subject}
          grade={item.grade}
          owner={item.owner}
          questionCount={item.questionCount}
          createDate={item.createdDate}
        />
      ))}
      <Pagination
        align="center"
        style={{
          marginTop: '20px',
        }}
        total={data.meta.totalCount}
        current={data.meta.currentPage}
        pageSize={data.meta.pageSize}
        onChange={(page, pageSize) => {
          params.set('pageNumber', page);
          params.set('pageSize', pageSize);
          setParams(params);
        }}
      />
    </Flex>
  );
};

export default TabContent;
