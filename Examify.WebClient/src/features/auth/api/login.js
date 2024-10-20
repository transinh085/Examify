import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useLogin = ({ data }) => {
  return api.post(`/auth/login`, data);
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
