import { useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getSubjects = () => {
  return api.get(`/catalog-service/api/subjects`);
};

export const useGetSubjects = () => {
  return useQuery({
    queryKey: ['subjects'],
    queryFn: getSubjects,
    refetchOnWindowFocus: false,
  });
};
