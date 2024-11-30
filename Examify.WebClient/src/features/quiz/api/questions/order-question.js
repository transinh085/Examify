import { useMutation } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const orderQuestion = ({ questionId, order }) => {
  return api.patch(`/quiz-service/api/questions/${questionId}/order`, {
    questionId,
    order,
  });
};

export const useOrderQuestion = () => {
  return useMutation({
    mutationFn: orderQuestion,
  });
};
