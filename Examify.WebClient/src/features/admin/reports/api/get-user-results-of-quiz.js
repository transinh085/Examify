import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const getUserResultsOfQuiz = ({ quizId, userId }) => {
  return api.get(`/result-service/api/quiz/${quizId}/users/${userId}/quiz-results`);
};

export const getUserResultsOfQuizQueryOption = ({ quizId, userId }) => {
  return queryOptions({
    queryKey: ['get-user-results-of-quiz', quizId, userId],
    queryFn: () => getUserResultsOfQuiz({ quizId, userId }),
  });
};

export const useGetUserResultsOfQuiz = ({ quizId, userId, queryOptions }) => {
  return useQuery({
    ...getUserResultsOfQuizQueryOption({ quizId, userId }),
    ...queryOptions,
  });
};
