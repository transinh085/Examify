import { useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getQuizUser = ({ isPublished, pageNumber, pageSize }) => {
  return api.get(`/quiz-service/api/quizzes/current`, {
    params: {
      isPublished,
      pageNumber,
      pageSize,
    },
  });
};

export const useGetQuizUser = ({ isPublished, pageNumber, pageSize }) => {
  return useQuery({
    queryKey: ['quiz-user', { isPublished, pageNumber, pageSize }],
    queryFn: () => getQuizUser({ isPublished, pageNumber, pageSize }),
  });
};
