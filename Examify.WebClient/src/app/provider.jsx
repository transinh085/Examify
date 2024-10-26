import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { App as AntApp, ConfigProvider } from 'antd';
import AuthProvider from './auth-provider';

const queryClient = new QueryClient();
const AppProvider = ({ children }) => {
  return (
    <ConfigProvider
      theme={{
        token: {
          fontFamily: 'Inter',
          borderRadius: 4,
          controlHeight: 37,
          colorPrimary: '#2C3A47',
        },
        components: {
          Table: {
            defaultProps: {
              size: 'middle',
              bordered: true,
              scroll: { x: true },
            },
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
  );
};

export default AppProvider;
