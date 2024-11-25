import { QueryClientProvider } from '@tanstack/react-query';
import { App as AntApp, ConfigProvider } from 'antd';
import { queryClient } from '~/lib/queryClient';
import AuthProvider from './auth-provider';
import { GoogleOAuthProvider } from '@react-oauth/google';
import { GOOGLE_OAUTH_CLIENT_ID } from '~/config/env';

const AppProvider = ({ children }) => {
  return (
    <GoogleOAuthProvider clientId={GOOGLE_OAUTH_CLIENT_ID}>
      <ConfigProvider
        theme={{
          token: {
            fontFamily: 'Inter',
            borderRadius: 6,
            controlHeight: 34,
            colorPrimary: '#027f91',
            colorLinkHover: '#027f91',
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
        <QueryClientProvider client={queryClient}>
          <AuthProvider>
            <AntApp>{children}</AntApp>
          </AuthProvider>
        </QueryClientProvider>
      </ConfigProvider>
    </GoogleOAuthProvider>
  );
};

export default AppProvider;
