import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const deleteQuiz = ({ id }) => {
  return api.patch(`/quiz-service/api/quizzes/${id}/publish`);
};

export const useDeleteQuiz = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: deleteQuiz,
    ...mutationConfig,
  });
};
