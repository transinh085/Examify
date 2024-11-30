import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useLoginGoogle = ({ accessToken }) => {
  return api.post('/identity-service/api/auth/login/google', { accessToken });
};

export const useLoginGoogleMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useLoginGoogle,
  });
};
