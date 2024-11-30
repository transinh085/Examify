import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const getQuizById = ({ quizId }) => {
  return api.get(`/quiz-service/api/quizzes/${quizId}`);
};

export const getQuizByIdQueryOption = ({ quizId }) => {
  return queryOptions({
    queryKey: ['get-quiz-by-id', quizId],
    queryFn: () => getQuizById({ quizId }),
  });
};

export const useGetQuizById = ({ quizId }) => {
  return useQuery({
    ...getQuizByIdQueryOption({ quizId }),
    initialData: [],
  });
};
