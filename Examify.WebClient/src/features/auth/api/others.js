import { useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useAuthentication = () => {
  return useQuery({
    queryKey: ['authentication'],
    queryFn: () => api.get('/auth/me'),
    initialData: {
      user: null,
      token: null,
    },
  });
};

export const useVerifyAccount = (token, options) => {
  return useQuery({
    queryKey: ['account-verification'],
    queryFn: () => api.get(`/auth/verify-account/${token}`),
    ...options,
    initialData: {},
  });
};
