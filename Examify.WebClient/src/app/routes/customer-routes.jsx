import MainLayout from '~/components/layouts/main-layout';
import PrivateGuard from '../guards/private-guard';

const CustomerRoutes = {
  path: '/',
  element: (
    <PrivateGuard>
      <MainLayout />
    </PrivateGuard>
  ),
  errorElement: async () => {
    let NotFoundRoute = await import('../pages/not-found');
    return { Component: NotFoundRoute.default };
  },
  children: [
    {
      path: '/',
      lazy: async () => {
        const DashboardRoute = await import('../pages/customer/dashboard');
        return { Component: DashboardRoute.default };
      },
    },
    {
      path: '/topics/:id',
      lazy: async () => {
        const TopicDetailsPage = await import('../pages/customer/topics/[id]');
        return { Component: TopicDetailsPage.default };
      },
    },
  ],
};

export default CustomerRoutes;
