import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useRegister = ({ data }) => {
  return api.post('/identity-service/api/auth/register', data);
};

export const useRegisterMutation = ({ mutationConfig }) => {
  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    onSuccess: (...args) => {
      onSuccess?.(...args);
    },
    ...restConfig,
    mutationFn: useRegister,
  });
};
