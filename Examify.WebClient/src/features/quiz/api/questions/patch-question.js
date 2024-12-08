import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const patchQuestion = ({ id, duration, points }) => {
  return api.patch(`/quiz-service/api/questions/${id}/attributes`, {
    duration,
    points,
  });
};

export const usePatchQuestion = ({ mutationConfig }) => {
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
    mutationFn: patchQuestion,
  });
};
