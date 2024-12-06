import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const startQuiz = ({ id }) => {
  return api.patch(`/quiz-service/api/quizzes/${id}/start`);
};

export const useStartQuiz = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: startQuiz,
    ...mutationConfig,
  });
};
