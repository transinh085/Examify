import { QueryClient } from '@tanstack/react-query';
import { CreateQuizLoader } from '~/app/pages/quiz/create-quiz';

const queryClient = new QueryClient();

const QuizRoutes = {
  path: 'quiz/:quizId',
  lazy: async () => {
    const CreateQuizPage = await import('../pages/quiz/create-quiz');
    return { Component: CreateQuizPage.default };
  },
  loader: async ({ params }) => {
    return CreateQuizLoader(queryClient)({ params });
  },
};

export default QuizRoutes;
