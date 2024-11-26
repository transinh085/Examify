import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const getQuizResult = (id) => {
  return api.get(`/result-service/api/quiz-results/${id}`);
};

export const getQuizResultOptions = (id) => {
  return queryOptions({
    queryKey: ['get-quiz-result', id],
    queryFn: () => getQuizResult(id),
  });
};

export const useGetQuizResult = ({ id }, options = {}) => {
  return useQuery({
    ...getQuizResultOptions(id),
    ...options,
  });
};
