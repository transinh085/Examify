import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useLogin = ({ email, password }) => {
  return api.post(`/identity-service/auth/login`, { email, password });
};

export const useLoginMutation = ({ mutationConfig }) => {
  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    onSuccess: (...args) => {
      onSuccess?.(...args);
    },
    ...restConfig,
    mutationFn: useLogin,
  });
};
