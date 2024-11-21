import { useMutation, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useAuthentication = (options) => {
  return useQuery({
    queryKey: ['authentication'],
    queryFn: () => api.get('/identity-service/api/auth/self'),
    ...options,
    // do not set initialData here
  });
};

export const useVerifyToken = ({ data }) => {
  return api.post('/identity-service/api/auth/verify-account', data);
};

export const useVerifyTokenMutation = ({ mutationConfig }) => {
  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    onSuccess: (...args) => {
      onSuccess?.(...args);
    },
    ...restConfig,
    mutationFn: useVerifyToken,
  });
};
