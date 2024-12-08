import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getRecentActivityOptions } from '~/features/customer/dashboard/api/get-recent-activity';
import { api } from '~/lib/api';

export const deleteQuizResult = ({ id }) => {
  return api.delete(`/result-service/api/quiz-results/${id}`);
};

export const useDeleteQuizResult = ({ params }) => {
  const queryClient = useQueryClient();
  const { status, pageNumber, pageSize } = params;

  return useMutation({
    mutationFn: deleteQuizResult,
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: getRecentActivityOptions({ status, pageNumber, pageSize }).queryKey,
      });
    },
  });
};
