import { Flex, Spin } from 'antd';
import Cookies from 'js-cookie';
import { useEffect } from 'react';
import { useAuthentication } from '~/features/auth/api/others';
import useAuthStore from '~/stores/auth-store';
import { LoadingOutlined } from '@ant-design/icons';

const AuthProvider = ({ children }) => {
  const { setUser } = useAuthStore();
  const {
    data: user,
    error,
    dataUpdatedAt,
    isLoading,
  } = useAuthentication({
    enabled: true,
  });

  useEffect(() => {
    if (user) {
      console.log('user', user);
      setUser(user);
    }

    if (error) {
      Cookies.remove('token');
    }
  }, [user, setUser, error, dataUpdatedAt]);

  if (isLoading) {
    return (
      <Flex className="w-[100vw] h-[100vh] bg-gray-400" align="center" justify="center">
        <Spin indicator={<LoadingOutlined spin />} />
      </Flex>
    );
  }
  return children;
};

export default AuthProvider;
