import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useCreateQuizResult = ({ quizId }) => {
  return api.post(`/result-service/api/quizzes/${quizId}/quiz-results`);
};

export const useCreateQuizResultMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useCreateQuizResult,
  });
};
