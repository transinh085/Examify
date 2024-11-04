import { Button, Flex, Form, Input, message, Typography } from 'antd';
import { Link, useNavigate } from 'react-router-dom';
import { useRegisterMutation } from '~/features/auth/api/register';
import RULES from '~/features/auth/rules';

const RegisterRoute = () => {
  const navigate = useNavigate();
  const [form] = Form.useForm();

  const mutation = useRegisterMutation({
    mutationConfig: {
      onSuccess: (data) => {
        navigate('/auth/verify-account?email=' + data?.email);
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const handleRegister = () => {
    mutation.mutate({ data: form.getFieldsValue() });
  };

  const moveToLogin = () => {
    navigate('/auth/login');
  };

  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px]"
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      <Typography className="text-[22px] font-semibold">Register</Typography>
      <Form form={form} className="pt-4" onFinish={handleRegister} layout="vertical">
        <Flex vertical>
          <Form.Item label="First name" name="firstName" rules={RULES.register.firstName} required={false}>
            <Input placeholder="Enter your first name..." />
          </Form.Item>
          <Form.Item label="Last name" name="lastName" rules={RULES.register.lastName} required={false}>
            <Input placeholder="Enter your last name..." />
          </Form.Item>
          <Form.Item label="Email" name="email" rules={RULES.register.email} required={false}>
            <Input placeholder="Enter your email..." />
          </Form.Item>
          <Form.Item label="Password" name="password" rules={RULES.register.password} required={false}>
            <Input.Password placeholder="Enter your password..." />
          </Form.Item>
        </Flex>
        <Form.Item className="pt-4 m-0">
          <Button loading={mutation.isPending} type="primary" htmlType="submit" className="w-full">
            Create account
          </Button>
          <Typography className="text-center mt-6">
            <Link to={'/auth/login'}>
              Do your have an account yet?
              <span onClick={moveToLogin} className="underline text-blue-400 cursor-pointer">
                Login
              </span>
            </Link>
          </Typography>
        </Form.Item>
      </Form>
    </div>
  );
};

export default RegisterRoute;
