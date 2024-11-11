import { CreateQuizLoader } from '~/app/pages/quiz/create-quiz';
import { queryClient } from '~/lib/queryClient';

const QuizRoutes = {
  path: 'admin/quiz/:quizId',
  lazy: async () => {
    const CreateQuizPage = await import('../pages/quiz/create-quiz');
    return { Component: CreateQuizPage.default };
  },
  loader: CreateQuizLoader(queryClient),
};

export default QuizRoutes;
