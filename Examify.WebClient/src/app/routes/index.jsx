import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import CustomerRoutes from './customer-routes';
import AuthRoutes from './auth-routes';
import AdminRoutes from './admin-routes';
import ErrorRoutes from './error-routes';
import QuizRoutes from '~/app/routes/quiz-routes';
import JoinRoutes from '~/app/routes/join-routes';
import ManagaerQuizRoutes from '~/app/routes/manager-routes';

const createAppRouter = () => createBrowserRouter([AuthRoutes, CustomerRoutes, AdminRoutes, ErrorRoutes, QuizRoutes, JoinRoutes, ManagaerQuizRoutes]);

export const AppRouter = () => {
  const router = createAppRouter();
  return <RouterProvider router={router} />;
};
