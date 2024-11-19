import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const updateUser = ({ id, firstName, lastName }) => {
    return api.put(`/identity-service/api/users`, { id, firstName, lastName });
};

export const useUpdateUserMutation = ({ mutationConfig }) => {
    const { onSuccess, ...restConfig } = mutationConfig || {};
    return useMutation({
        onSuccess: (...args) => {
            onSuccess?.(...args);
        },
        ...restConfig,
        mutationFn: updateUser,
    });
};