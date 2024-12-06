import DoQuizLayout from '~/components/layouts/do-quiz-layout';
import PrivateGuard from '../guards/private-guard';

const DoQuizRoutes = {
  path: '/join',
  element: (
    <PrivateGuard>
      <DoQuizLayout />
    </PrivateGuard>
  ),
  children: [
    {
      path: "",
      lazy: async () => {
        const JoinWait = await import('../pages/customer/join');
        return { Component: JoinWait.default };
      }
    },
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
    {
      path: 'wait/:code',
      lazy: async () => {
        const JoinWait = await import('../pages/customer/join/wait/[code]');
        return { Component: JoinWait.default };
      }
    }
  ],
};

export default DoQuizRoutes;
