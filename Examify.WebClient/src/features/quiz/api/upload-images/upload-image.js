import { useMutation } from "@tanstack/react-query";
import { api } from "~/lib/api";

const uploadImage = (file) => {
  const formData = new FormData();
  formData.append('file', file);

  return api.post('/quiz-service/api/upload-image', formData, {
    headers: { 'Content-Type': 'multipart/form-data' },
  });
};

export const useUploadImageMutation = ({ mutationConfig = {} }) => {
  return useMutation({
    mutationFn: uploadImage,
    ...mutationConfig,
  });
};
