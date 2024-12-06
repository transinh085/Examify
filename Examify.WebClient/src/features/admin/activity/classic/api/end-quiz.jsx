import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const endQuiz = ({ id }) => {
  return api.patch(`/quiz-service/api/quizzes/${id}/end`);
};

export const useEndQuiz = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: endQuiz,
    ...mutationConfig,
  });
};
