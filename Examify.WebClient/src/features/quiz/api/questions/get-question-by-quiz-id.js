import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getQuestionByQuizId = ({ quizId }) => {
  return api.get(`/quiz-service/api/quizzes/${quizId}/questions`);
};

export const getQuestionByQuizIdQueryOptions = (quizId) => {
  return queryOptions({
    queryKey: ['questions', { quizId }],
    queryFn: () => getQuestionByQuizId({ quizId }),
  });
};

export const useGetQuestionByQuizId = ({ queryConfig, quizId }) => {
  return useQuery({
    ...getQuestionByQuizIdQueryOptions(quizId),
    ...queryConfig,
  });
};
