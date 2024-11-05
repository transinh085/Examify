import { queryOptions, useQuery } from "@tanstack/react-query";
import { api } from "~/lib/api";

const seftApi = () => {
  return api.get(`/identity-service/api/auth/self`);
}

export const getSeft = () => {
  return queryOptions({
    queryKey: ['seft'],
    queryFn: () => seftApi(),
  });
}

export const useGetSeft = () => {
  return useQuery({
    ...getSeft()
  });
};