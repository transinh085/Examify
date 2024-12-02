import ManagerQuizWait from '~/features/admin/activity/classic/components/ManagerQuizWait';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import ManagerQuizStart from '~/features/admin/activity/classic/components/ManagerQuizStart';
import { useParams } from 'react-router';
import { useGetQuiz } from '~/features/quiz/api/quizzes/get-quiz';
import { Flex, Spin } from 'antd';
import { useEffect } from 'react';

const ManagerQuizPage = () => {
  const quizId = useParams().id;
  const { isStart, setQuiz } = useManagerQuizStore();

  const { data: quiz } = useGetQuiz({ id: quizId });

  useEffect(() => {
    if(quiz)
    setQuiz(quiz);
  }, [quiz, setQuiz]);

  if (!quiz){
    return (
      <Flex justify="center" align="center">
        <Spin />
      </Flex>
    );
  }

 

  return isStart ? <ManagerQuizStart /> : <ManagerQuizWait />;
};

export default ManagerQuizPage;
