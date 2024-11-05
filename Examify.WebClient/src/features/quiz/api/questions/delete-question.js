import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getQuestionByQuizIdQueryOptions } from '~/features/quiz/api/questions/get-question-by-quiz-id';
import { api } from '~/lib/api';

export const deleteQuestion = ({ quizId, questionId }) => {
  return api.delete(`/quiz-service/api/quizzes/${quizId}/questions/${questionId}`);
};

export const useDeleteQuestion = ({ mutationConfig }) => {
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
    mutationFn: deleteQuestion,
  });
};
