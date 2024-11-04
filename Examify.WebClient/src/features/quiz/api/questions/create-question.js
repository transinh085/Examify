import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getQuestionByQuizIdQueryOptions } from '~/features/quiz/api/questions/get-question-by-quiz-id';
import { api } from '~/lib/api';

export const createQuestion = ({ quizId, data }) => {
  return api.post(`/quiz-service/api/quizzes/${quizId}/questions`, data);
};

export const useCreateQuestion = ({ mutationConfig }) => {
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
    mutationFn: createQuestion,
  });
};
