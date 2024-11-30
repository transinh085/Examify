import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const getResultsOfQuiz = ({ quizId }) => {
  return api.get(`/result-service/api/quiz/${quizId}/quiz-results`);
};

export const getResultOfQuizQueryOption = ({ quizId }) => {
  return queryOptions({
    queryKey: ['get-results-of-quiz', quizId],
    queryFn: () => getResultsOfQuiz({ quizId }),
  });
};

export const useGetResultsOfQuiz = ({ quizId, queryOptions }) => {
  return useQuery({
    ...getResultOfQuizQueryOption({ quizId }),
    ...queryOptions,
  });
};
