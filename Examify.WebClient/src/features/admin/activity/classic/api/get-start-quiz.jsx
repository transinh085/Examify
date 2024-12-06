import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getStartQuiz = ({ code }) => {
  return api.get(`result-service/api/quiz-results/${code}/start-quiz`);
};

export const getStartQuizQueryOptions = (code) => {
  return queryOptions({
    queryKey: ['start-quiz', { code }],
    queryFn: () => getStartQuiz({ code }),
  });
};

export const useGetStartQuiz = ({ queryConfig, code }) => {
  return useQuery({
    ...getStartQuizQueryOptions(code),
    ...queryConfig,
  });
};
