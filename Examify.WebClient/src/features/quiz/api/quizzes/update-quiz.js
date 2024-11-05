import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getQuizQueryOptions } from '~/features/quiz/api/quizzes/get-quiz';
import { api } from '~/lib/api';

export const updateQuiz = ({ id, data }) => {
  return api.put(`/quiz-service/api/quizzes/${id}`, data);
};

export const useUpdateQuiz = ({ mutationConfig }) => {
  const queryClient = useQueryClient();
  const { onSuccess, ...restConfig } = mutationConfig || {};
  return useMutation({
    onSuccess: async (data, ...args) => {
      queryClient.setQueryData(getQuizQueryOptions(data.id).queryKey, (old) => ({ ...old, ...data }));
      onSuccess?.(data, ...args);
    },
    ...restConfig,
    mutationFn: updateQuiz,
  });
};
