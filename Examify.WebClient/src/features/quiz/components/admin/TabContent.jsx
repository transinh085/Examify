import { useQueryClient } from '@tanstack/react-query';
import { Button, Flex, message, Typography } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useCreateQuiz } from '~/features/quiz/api/quizzes/create-quiz';
import TestCard from '~/features/quiz/components/admin/TestCard';

const TabContent = ({ data }) => {
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
  if (data.length === 0)
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
      {data.map((item, index) => (
        <TestCard
          key={index}
          id={item.id}
          imgSrc={item.cover}
          title={item.title}
          author={item.owner}
          questions={item.questions}
          date={item.createdDate}
          tags={item.gradeName}
          gradeName={item.gradeName}
          languageName={item.languageName}
        />
      ))}
    </Flex>
  );
};

export default TabContent;
