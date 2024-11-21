import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const useSubmitAnswers = ({ questionResultId, Answers, TimeTaken, TimeSpent }) => {
  return api.put(`/result-service/api/question-results/${questionResultId}`, { Answers, TimeTaken, TimeSpent });
};

export const useSubmitAnswersMutation = ({ mutationConfig }) => {
  return useMutation({
    ...mutationConfig,
    mutationFn: useSubmitAnswers,
  });
};
