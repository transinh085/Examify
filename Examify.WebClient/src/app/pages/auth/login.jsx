import { Button, Divider, Flex, Form, Input, message, Space, Typography } from 'antd';
import { useGoogleLoginMutation, useLoginMutation } from '~/features/auth/api/login';
// import gg from '~/assets/svg/gg.svg';
import fb from '~/assets/svg/fb.svg';
import { Link, useNavigate, useSearchParams } from 'react-router-dom';
import Cookies from 'js-cookie';
import RULES from '~/features/auth/rules';
import useAuthStore from '~/stores/auth-store';
import FacebookLogin from 'react-facebook-login/dist/facebook-login-render-props';
import { useLoginFacebookMutation } from '~/features/auth/api/login-facebook';
import { GoogleLogin } from '@react-oauth/google';

const LoginRoute = () => {
  const [searchParams] = useSearchParams();
  const redirect = searchParams.get('redirect');
  const navigate = useNavigate();
  const { setUser } = useAuthStore();

  const [form] = Form.useForm();

  const handleSetUser = (data) => {
    Cookies.set('token', data?.token, { expires: 30 });
    Cookies.set('refreshToken', data?.refreshToken, { expires: 30 });
    setUser(data);
    navigate(redirect ? redirect : '/');
  };

  const mutation = useLoginMutation({
    mutationConfig: {
      onSuccess: (data) => {
        handleSetUser(data);
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const loginFacebookMutation = useLoginFacebookMutation({
    mutationConfig: {
      onSuccess: (data) => {
        handleSetUser(data);
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const handleLogin = (data) => {
    mutation.mutate({
      email: data.email,
      password: data.password,
    });
  };

  const handleFacebookCallback = (response) => {
    if (response?.status === 'unknown') {
      console.error('Sorry!', 'Something went wrong with facebook Login.');
      return;
    }
    loginFacebookMutation.mutate({
      accessToken: response.accessToken,
    });
  };

  const googleLoginMutation = useGoogleLoginMutation({
    mutationConfig: {
      onSuccess: (data) => {
        handleSetUser(data);
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const handleGoogleLogin = (credential) => {
    googleLoginMutation.mutate({ data: credential });
  };

  return (
    <Space
      size="middle"
      direction="vertical"
      className="p-8 rounded-[8px] w-[90%] md:w-[460px] bg-white border shadow-sm"
    >
      <Typography className="text-[22px] font-semibold">Login</Typography>

      <Space gap={10} direction="vertical" className="w-full">
        <GoogleLogin
          onSuccess={handleGoogleLogin}
          onError={() => {
            console.log('Login Failed');
          }}
        />
        <FacebookLogin
          buttonStyle={{ padding: '6px' }}
          appId="423573474136909"
          autoLoad={false}
          fields="name,email,picture"
          callback={handleFacebookCallback}
          returnScopes={false}
          render={(renderProps) => (
            <Button onClick={renderProps.onClick} className="flex justify-start items-center h-[38px] rounded" block>
              <img src={fb} />
              <p className="flex-1">Đăng nhập bằng Facebook</p>
            </Button>
          )}
        />
      </Space>

      <Divider>
        <Typography className="text-[#333] mb-2">Or</Typography>
      </Divider>

      <Form
        form={form}
        onFinish={handleLogin}
        layout="vertical"
        variant="filled"
        initialValues={{
          email: 'transinh085@gmail.com',
          password: '12345678',
        }}
      >
        <Flex vertical>
          <Form.Item label="Email" name="email" rules={RULES.login.email} required={false} validateTrigger="onBlur">
            <Input placeholder="Enter your email..." />
          </Form.Item>
          <Form.Item
            label="Password"
            name="password"
            rules={RULES.login.password}
            required={false}
            validateTrigger="onBlur"
          >
            <Input.Password placeholder="Enter your password..." />
          </Form.Item>
        </Flex>
        <Form.Item className="mb-0">
          <Button loading={mutation.isPending} type="primary" htmlType="submit" className="w-full">
            Login
          </Button>
        </Form.Item>
      </Form>
      <Typography className="text-center">
        <Link to={'/auth/register'}>
          <a href="forgot-password" className="block mb-3">
            Forgot password
          </a>
          Do you have an account yet? <span className="cursor-pointer  font-bold">Register</span>
        </Link>
      </Typography>
    </Space>
  );
};

export default LoginRoute;
