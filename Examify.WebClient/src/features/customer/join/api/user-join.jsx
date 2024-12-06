import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const userJoin = ({ code }) => {
  return api.post(`result-service/api/join-quiz`, {
    code
  });
};

export const useUserJoin = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: userJoin,
    ...mutationConfig,
  });
};
