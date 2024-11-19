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
      path: 'verify-account/success',
      lazy: async () => {
        let AccountVerificationSuccess = await import('../pages/auth/verify-account-success');
        return { Component: AccountVerificationSuccess.default };
      },
    },
    {
      path: 'verify-account/failed',
      lazy: async () => {
        let AccountVerificationFailed = await import('../pages/auth/verify-account-failed');
        return { Component: AccountVerificationFailed.default };
      },
    },
    {
      path: 'verify-account/:token',
      lazy: async () => {
        let AccountVerificationProcessing = await import('../pages/auth/verify-account-processing');
        return { Component: AccountVerificationProcessing.default };
      },
    },
  ],
};
export default AuthRoutes;
