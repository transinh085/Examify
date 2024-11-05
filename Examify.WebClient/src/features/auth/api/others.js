import { useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useAuthentication = (options) => {
  return useQuery({
    queryKey: ['authentication'],
    queryFn: () => api.get('/identity-service/api/auth/self'),
    ...options,
    // do not set initialData here
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
