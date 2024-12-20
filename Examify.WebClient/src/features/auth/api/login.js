import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useLogin = ({ email, password }) => {
  return api.post('/identity-service/api/auth/login', { email, password });
};

export const useLoginMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useLogin,
  });
};



export const useGoogleLogin = ({ data }) => {
  return api.post(`/identity-service/api/auth/login-google`, data);
};

export const useGoogleLoginMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useGoogleLogin,
  });
};