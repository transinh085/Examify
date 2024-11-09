import DoQuizLayout from '~/components/layouts/do-quiz-layout';

const DoQuizRoutes = {
  path: '/join',
  element: <DoQuizLayout />,
  children: [
    {
      path: 'game/:quiz_id',
      lazy: async () => {
        const DoQuizPage = await import('../pages/customer/join/game/[quiz_id]');
        return { Component: DoQuizPage.default };
      },
    },
  ],
};

export default DoQuizRoutes;
