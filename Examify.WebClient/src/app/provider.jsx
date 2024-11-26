import { QueryClientProvider } from '@tanstack/react-query';
import { App as AntApp, ConfigProvider } from 'antd';
import { queryClient } from '~/lib/queryClient';
import AuthProvider from './auth-provider';
import { GoogleOAuthProvider } from '@react-oauth/google';

const AppProvider = ({ children }) => {
  return (
    <ConfigProvider
      theme={{
        token: {
          fontFamily: 'Inter',
          borderRadius: 6,
          controlHeight: 34,
          colorPrimary: '#027f91',
          colorLinkHover: '#027f91',
          colorLink: '#027f91',
        },
        components: {
          Table: {
            defaultProps: {
              size: 'middle',
              bordered: true,
              scroll: { x: true },
            },
          },
          Select: {
            defaultProps: {},
          },
        },
        hashed: false,
      }}
    >
      <GoogleOAuthProvider clientId="381736684532-nvaeqmmgriog6ctndltmnbtat450ks1e.apps.googleusercontent.com">
        <QueryClientProvider client={queryClient}>
          <AuthProvider>
            <AntApp>{children}</AntApp>
          </AuthProvider>
        </QueryClientProvider>
      </GoogleOAuthProvider>
    </ConfigProvider>
  );
};

export default AppProvider;
