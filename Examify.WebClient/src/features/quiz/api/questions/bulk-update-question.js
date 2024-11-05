import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getQuestionByQuizIdQueryOptions } from '~/features/quiz/api/questions/get-question-by-quiz-id';
import { api } from '~/lib/api';

export const bulkUpdateQuestion = ({ quizId, data }) => {
  return api.patch(`/quiz-service/api/quizzes/${quizId}/questions/bulk`, data);
};

export const useBulkUpdateQuestion = ({ mutationConfig }) => {
  const queryClient = useQueryClient();
  const { onSuccess, ...restConfig } = mutationConfig || {};
  return useMutation({
    onSuccess: async (data, variables, ...args) => {
      queryClient.invalidateQueries({
        queryKey: getQuestionByQuizIdQueryOptions(variables.quizId).queryKey,
      });
      onSuccess?.(data, ...args);
    },
    ...restConfig,
    mutationFn: bulkUpdateQuestion,
  });
};
