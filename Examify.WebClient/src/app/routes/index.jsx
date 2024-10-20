import { useQueryClient } from '@tanstack/react-query';
import { useMemo } from 'react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import CustomerRoutes from './customer-routes';
import AuthRoutes from './auth-routes';
import AdminRoutes from './admin-routes';
import ErrorRoutes from './error-routes';

const createAppRouter = () => createBrowserRouter([AuthRoutes, CustomerRoutes, AdminRoutes, ErrorRoutes]);

export const AppRouter = () => {
  const queryClient = useQueryClient();

  const router = useMemo(() => createAppRouter(queryClient), [queryClient]);
  return <RouterProvider router={router} />;
};
