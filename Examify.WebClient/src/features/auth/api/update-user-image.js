import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const updateUserImage = ({ id, imageUrl }) => {
    return api.patch(`/identity-service/api/users/image`, { id, imageUrl });
};

export const useUpdateUserMutation = ({ mutationConfig }) => {
    const { onSuccess, ...restConfig } = mutationConfig || {};
    return useMutation({
        onSuccess: (...args) => {
            onSuccess?.(...args);
        },
        ...restConfig,
        mutationFn: updateUserImage,
    });
};