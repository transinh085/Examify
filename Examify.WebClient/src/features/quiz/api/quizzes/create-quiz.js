import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const createQuiz = () => {
  return api.post(`/quiz-service/api/quizzes`);
};

export const useCreateQuiz = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: createQuiz,
    ...mutationConfig,
  });
};
