import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const playQuiz = ({ id }) => {
  return api.patch(`/quiz-service/api/quizzes/${id}/play`);
};

export const usePlayQuiz = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: playQuiz,
    ...mutationConfig,
  });
};
