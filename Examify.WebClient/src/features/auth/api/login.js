import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useLogin = ({ email, password }) => {
  return api.post('/identity-service/api/auth/login', { email, password });
};

export const useLoginMutation = ({ mutationConfig }) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    onSuccess: async (...args) => {
      onSuccess?.(...args);
      await queryClient.invalidateQueries('authentication');
    },
    ...restConfig,
    mutationFn: useLogin,
  });
};
