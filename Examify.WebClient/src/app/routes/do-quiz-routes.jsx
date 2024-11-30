import DoQuizLayout from '~/components/layouts/do-quiz-layout';

const DoQuizRoutes = {
  path: '/join',
  element: <DoQuizLayout />,
  children: [
    {
      path: 'game/:result_id',
      lazy: async () => {
        const DoQuizPage = await import('../pages/customer/join/game/[result_id]');
        return { Component: DoQuizPage.default };
      },
    },
    {
      path: 'game/:result_id/result',
      lazy: async () => {
        const ResultPage = await import('../pages/customer/join/game/[result_id]/result');
        return { Component: ResultPage.default };
      },
    },
  ],
};

export default DoQuizRoutes;
