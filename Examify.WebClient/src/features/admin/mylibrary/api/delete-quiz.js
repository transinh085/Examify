import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const deleteQuiz = ({ id }) => {
  return api.delete(`/quiz-service/api/quizzes/${id}`);
};

export const useDeleteQuiz = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: deleteQuiz,
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ['quiz-user'],
      });
    },
  });
};
