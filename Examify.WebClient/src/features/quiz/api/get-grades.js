import { useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getGrades = () => {
  return api.get(`/catalog-service/api/grades`);
};

export const useGetGrades = () => {
  return useQuery({
    queryKey: ['grades'],
    queryFn: getGrades,
    refetchOnWindowFocus: false,
  });
};
