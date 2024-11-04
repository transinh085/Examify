import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getQuiz = ({ id }) => {
  return api.get(`/quiz-service/api/quizzes/${id}`);
};

export const getQuizQueryOptions = (id) => {
  return queryOptions({
    queryKey: ['quiz', { id }],
    queryFn: () => getQuiz({ id }),
  });
};

export const useGetQuiz = ({ queryConfig, id }) => {
  return useQuery({
    ...getQuizQueryOptions(id),
    ...queryConfig,
  });
};
