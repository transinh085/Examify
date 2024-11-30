import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

const updateUserImage = ({ id, imageUrl }) => {
    return api.patch(`/identity-service/api/users/image`, { id, imageUrl });
};

export const useUpdateUserImageMutation = ({ mutationConfig }) => {
    const { onSuccess, ...restConfig } = mutationConfig || {};
    return useMutation({
        onSuccess: (...args) => {
            onSuccess?.(...args);
        },
        ...restConfig,
        mutationFn: updateUserImage,
    });
};