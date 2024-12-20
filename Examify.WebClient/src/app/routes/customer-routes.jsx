import MainLayout from '~/components/layouts/main-layout';
import PrivateGuard from '../guards/private-guard';

// can access as an guest or authenticated user
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
      path: '/activities',
      lazy: async () => {
        const Activities = await import('../pages/customer/activities');
        return { Component: Activities.default };
      },
    },
    {
      path: 'search',
      lazy: async () => {
        const SearchPage = await import('../pages/customer/search');
        return { Component: SearchPage.default };
      },
    },
  ],
};

export default CustomerRoutes;
