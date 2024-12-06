import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getUserJoin = ({ code }) => {
  return api.get(`result-service/api/quiz-results/${code}/join-quiz`);
};

export const getUserJoinQueryOptions = (code) => {
  return queryOptions({
    queryKey: ['join-quiz', { code }],
    queryFn: () => getUserJoin({ code }),
  });
};

export const useGetJoinQuiz = ({ queryConfig, code }) => {
  return useQuery({
    ...getUserJoinQueryOptions(code),
    ...queryConfig,
  });
};
