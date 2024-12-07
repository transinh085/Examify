import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const searchQuiz = (params) => {
  return api.get(`/quiz-service/api/quizzes/search`, { params });
};

export const searchQuizOptions = (params) => {
  return queryOptions({
    queryKey: ['quiz-subject', params.keyword, params.subjectId, params.pageNumber, params.pageSize],
    queryFn: () => searchQuiz(params),
  });
};

export const useSearchQuiz = (params, queryConfig = {}) => {
  return useQuery({
    ...searchQuizOptions(params),
    ...queryConfig,
  });
};
