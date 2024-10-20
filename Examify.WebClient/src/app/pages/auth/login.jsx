import { Button, Col, Divider, Flex, Form, Input, message, Row, Typography } from 'antd';
import RULES from '~/config/rule';
import { useLoginMutation } from '~/features/auth/api/login';
import fb from '~/assets/svg/fb.svg';
import gg from '~/assets/svg/gg.svg';
import wt from '~/assets/svg/wt.svg';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';

const LoginRoute = () => {
  const navigate = useNavigate();
  const { setUser } = useAuthStore();

  const [form] = Form.useForm();
  const mutation = useLoginMutation({
    mutationConfig: {
      onSuccess: (data) => {
        localStorage.setItem('token', data?.token);
        setUser(data?.user);
        navigate('/');
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const handleLogin = () => {
    mutation.mutate({ data: form.getFieldsValue() });
  };

  return (
    <div className="p-8 rounded-[8px] w-[90%] md:w-[460px] bg-white border shadow-sm">
      <Typography className="text-[22px] font-semibold">Đăng nhập</Typography>
      <Form form={form} className="pt-4" onFinish={handleLogin} layout="vertical" variant="filled">
        <Flex vertical>
          <Form.Item label="Email" name="email" rules={RULES.login.email} required={false} validateTrigger="onBlur">
            <Input placeholder="Nhập email..." />
          </Form.Item>
          <Form.Item
            label="Mật khẩu"
            name="password"
            rules={RULES.login.password}
            required={false}
            validateTrigger="onBlur"
          >
            <Input.Password placeholder="Nhập mật khẩu..." />
          </Form.Item>
        </Flex>
        <Form.Item className="pt-2 m-0">
          <a href="forgot-password" className="block mb-3">
            Quên mật khẩu?
          </a>
          <Button loading={mutation.isPending} type="primary" htmlType="submit" className="w-full">
            Đăng nhập
          </Button>
        </Form.Item>
        <Form.Item className="pt-4 m-0">
          <Divider>
            <Typography className="text-[#333] mb-2">Hoặc</Typography>
          </Divider>
          <Row gutter={12}>
            <Col span={8}>
              <Button className="w-full">
                <img src={gg} alt="" />
                Google
              </Button>
            </Col>
            <Col span={8}>
              <Button className="w-full">
                <img src={wt} alt="" />
                Twitter
              </Button>
            </Col>
            <Col span={8}>
              <Button className="w-full">
                <img src={fb} alt="" />
                Facebook
              </Button>
            </Col>
          </Row>
          <Typography className="text-center mt-6">
            Bạn chưa có tài khoản? <a href="register">Đăng ký</a>
          </Typography>
        </Form.Item>
      </Form>
    </div>
  );
};

export default LoginRoute;
