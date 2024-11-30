import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useCreateQuizResult = ({ code }) => {
  return api.post(`/result-service/api/quiz-results`, {
    code,
  });
};

export const useCreateQuizResultMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useCreateQuizResult,
  });
};
