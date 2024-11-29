import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const getQuizBySubject = (subjectId, pageNumber, pageSize) => {
  return api.get(`/quiz-service/api/quizzes/subjects`, {
    params: {
      subjectId,
      pageNumber,
      pageSize,
    },
  });
};

export const getQuizBySubjectOptions = (subjectId, pageNumber, pageSize) => {
  return queryOptions({
    queryKey: ['quiz-subject', subjectId, pageNumber, pageSize],
    queryFn: () => getQuizBySubject(subjectId, pageNumber, pageSize),
  });
};

export const useGetQuizBySubject = ({ subjectId, pageNumber, pageSize }, queryConfig = {}) => {
  return useQuery({
    ...getQuizBySubjectOptions(subjectId, pageNumber, pageSize),
    ...queryConfig,
  });
};
