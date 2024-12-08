import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getQuizQueryOptions } from '~/features/quiz/api/quizzes/get-quiz';
import { api } from '~/lib/api';

export const updateQuizNew = ({ id, data }) => {
  return api.put(`/quiz-service/api/quizzes/p/${id}`, data);
};

export const useUpdateQuizNew = ({ mutationConfig }) => {
  const queryClient = useQueryClient();
  const { onSuccess, ...restConfig } = mutationConfig || {};
  return useMutation({
    onSuccess: async (data, ...args) => {
      queryClient.setQueryData(getQuizQueryOptions(data.id).queryKey, (old) => ({ ...old, ...data }));
      onSuccess?.(data, ...args);
    },
    ...restConfig,
    mutationFn: updateQuizNew,
  });
};
