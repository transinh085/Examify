import AuthLayout from '~/components/layouts/auth-layout';
import AuthGuard from '../guards/auth-guard';

const AuthRoutes = {
  path: '/auth',
  element: (
    <AuthGuard>
      <AuthLayout />
    </AuthGuard>
  ),
  children: [
    {
      path: 'login',
      lazy: async () => {
        let LoginRoute = await import('../pages/auth/login');
        return { Component: LoginRoute.default };
      },
    },
    {
      path: 'register',
      lazy: async () => {
        let RegisterRoute = await import('../pages/auth/register');
        return { Component: RegisterRoute.default };
      },
    },
    {
      path: 'verify-account',
      lazy: async () => {
        let AccountVerification = await import('../pages/auth/verify-account');
        return { Component: AccountVerification.default };
      },
    },
    {
      path: 'verify-account/:token',
      lazy: async () => {
        let AccountVerificationResult = await import('../pages/auth/verify-account-result');
        return { Component: AccountVerificationResult.default };
      },
    },
  ],
};
export default AuthRoutes;
