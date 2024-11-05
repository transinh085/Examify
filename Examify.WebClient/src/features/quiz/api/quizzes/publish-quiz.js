import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const publishQuiz = ({ id }) => {
  return api.patch(`/quiz-service/api/quizzes/${id}/publish`);
};

export const usePublishQuiz = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: publishQuiz,
    ...mutationConfig,
  });
};
