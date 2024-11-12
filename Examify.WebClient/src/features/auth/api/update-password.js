import { useMutation, useQueryClient } from '@tanstack/react-query';
import { api } from '~/lib/api';

export const updatePassApi = ({ email, oldPassword, newPassword }) => {
    return api.put('/identity-service/api/updatepassword', { email, oldPassword, newPassword });
};

export const useUpdatePasswordMutation = ({ mutationConfig }) => {
    const { onSuccess, ...restConfig } = mutationConfig || {};
    return useMutation({
        onSuccess: (...args) => {
            onSuccess?.(...args);
        },
        ...restConfig,
        mutationFn: updatePassApi,
    });
};