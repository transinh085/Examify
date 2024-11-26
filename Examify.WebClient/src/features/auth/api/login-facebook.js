import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useLoginFacebook = ({ accessToken }) => {
  return api.post('/identity-service/api/auth/login/facebook', { accessToken });
};

export const useLoginFacebookMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useLoginFacebook,
  });
};
