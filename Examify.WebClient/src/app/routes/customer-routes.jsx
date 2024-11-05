import MainLayout from '~/components/layouts/main-layout';

// can access as an guest or authenticated user
const CustomerRoutes = {
  path: '/',
  element: <MainLayout />,
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
      path: '/activities',
      lazy: async () => {
        const Activities = await import('../pages/customer/activities');
        return { Component: Activities.default };
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
