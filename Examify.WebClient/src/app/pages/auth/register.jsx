import { Button, Flex, Form, Input, message, Typography } from 'antd';
import { useNavigate } from 'react-router-dom';
import RULES from '~/config/rule';
import { useRegisterMutation } from '~/features/auth/api/register';

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
  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px]"
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      <Typography className="text-[22px] font-semibold">Đăng ký</Typography>
      <Form form={form} className="pt-4" onFinish={handleRegister} layout="vertical">
        <Flex vertical>
          <Form.Item label="Họ tên" name="name" rules={RULES.register.name} required={false}>
            <Input placeholder="Nhập họ tên..." />
          </Form.Item>
          <Form.Item label="Email" name="email" rules={RULES.register.email} required={false}>
            <Input placeholder="Nhập email..." />
          </Form.Item>
          <Form.Item label="Mật khẩu" name="password" rules={RULES.register.password} required={false}>
            <Input.Password placeholder="Nhập mật khẩu..." />
          </Form.Item>
        </Flex>
        <Form.Item className="pt-4 m-0">
          <Button loading={mutation.isPending} type="primary" htmlType="submit" className="w-full">
            Tạo tài khoản
          </Button>
          <Typography className="text-center mt-6">
            Bạn đã có tài khoản? <a href="login">Đăng nhập</a>
          </Typography>
        </Form.Item>
      </Form>
    </div>
  );
};

export default RegisterRoute;
