import { queryOptions, useQuery } from "@tanstack/react-query";
import { api } from "~/lib/api";


const getTest = () => {
  return api.get("/notification-service/api/test");
}

export const useGetTest = () => {
  return useQuery(
    queryOptions({
      queryKey: ["test"],
      queryFn: () => getTest(),
    })
  )
}