import { useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const getLanguages = () => {
  return api.get(`/catalog-service/api/languages`);
};

export const useGetLanguages = () => {
  return useQuery({
    queryKey: ['languages'],
    queryFn: getLanguages,
    refetchOnWindowFocus: false,
  });
};
