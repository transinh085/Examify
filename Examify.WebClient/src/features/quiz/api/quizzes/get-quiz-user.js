import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getQuizUser = () => {
  return api.get(`/quiz-service/api/quizzes/current`);
};

export const getQuizQueryOptions = () => {
  return queryOptions({
    queryKey: ['quiz-user'],
    queryFn: () => getQuizUser(),
  });
};

export const useGetQuizUser = () => {
  return useQuery({
    ...getQuizQueryOptions()
  });
};
