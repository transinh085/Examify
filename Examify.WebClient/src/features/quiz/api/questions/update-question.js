import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const updateQuestion = ({ id, data }) => {
  return api.put(`/quiz-service/api/questions/${id}`, data);
};

export const useUpdateQuestion = ({ mutationConfig }) => {
  const queryClient = useQueryClient();
  const { onSuccess, ...restConfig } = mutationConfig || {};
  return useMutation({
    onSuccess: async (data, variables, ...args) => {
      queryClient.invalidateQueries({
        queryKey: ['questions'],
      });
      onSuccess?.(data, ...args);
    },
    ...restConfig,
    mutationFn: updateQuestion,
  });
};
