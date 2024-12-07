import { queryOptions, useQuery } from '@tanstack/react-query';
import { api } from '~/lib/api';

const getRecentActivity = (params) => {
  return api.get(`/result-service/api/recent-activities`, { params });
};

export const getRecentActivityOptions = (params) => {
  return queryOptions({
    queryKey: ['recent-activities', params.pageNumber, params.pageSize],
    queryFn: () => getRecentActivity(params),
  });
};

export const useGetRecentActivity = (params, queryConfig = {}) => {
  return useQuery({
    ...getRecentActivityOptions(params),
    ...queryConfig,
  });
};
