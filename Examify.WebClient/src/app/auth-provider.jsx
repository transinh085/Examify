import Cookies from 'js-cookie';
import { useEffect } from 'react';
import { useAuthentication } from '~/features/auth/api/others';
import useAuthStore from '~/stores/auth-store';

const AuthProvider = ({ children }) => {
  const { setUser } = useAuthStore();
  const {
    data: user,
    error,
    dataUpdatedAt,
  } = useAuthentication({
    enabled: true,
  });

  useEffect(() => {
    if (user) {
      setUser(user);
    }

    if (error) {
      Cookies.remove('token');
    }
  }, [user, setUser, error, dataUpdatedAt]);

  return children;
};

export default AuthProvider;
