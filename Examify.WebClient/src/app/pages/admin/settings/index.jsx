import { Alert, Button, Card, Flex, Form, Space, Watermark, Input, Divider, Select, Tabs, message } from 'antd';
import { useUpdatePasswordMutation } from '~/features/auth/api/update-password';
import useAuthStore from '~/stores/auth-store';
import Cookies from 'js-cookie';

const SettingPage = () => {
  const { user, resetUser } = useAuthStore();
  const [form] = Form.useForm();
  const mutation = useUpdatePasswordMutation({
    mutationConfig: {
      onSuccess: (data) => {
        Cookies.set('token', data?.token);
        message.success('Update')
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const handleUpdate = (data) => {
    mutation.mutate({
      email: user.email,
      oldPassword: data.passwordLast,
      newPassword: data.passwordNew,
    });
  };
  return (
    <Flex className='justify-center'>
      <Card
        style={{
          width: 700,
        }}
      >
        <h1 className='from-neutral-900 font-bold text-2xl'>Cài đặt</h1>
        <Tabs size={'large'} className='px-8'>
          <Tabs.TabPane tab={<span style={{ fontSize: '16px', fontWeight: 'bold' }}>Tài khoản</span>} key="tab 1">
            <Form name="updateEmail" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off" initialValues={{ Email: user.email }}>
              <Form.Item
                hasFeedback
                label="Email"
                name="email"
                validateTrigger="onChange"
                rules={[
                  {
                    type: 'email',
                    message: 'Vui lòng nhập địa chỉ email hợp lệ!',
                  },
                  {
                    required: true,
                    message: 'Email là bắt buộc!',
                  },
                ]}
              >
                <Input placeholder="Validate required onBlur" defaultValue='nbao02031@gmail.com' />
              </Form.Item>
              <Form.Item>
                <Button block>Lưu thay đổi</Button>
              </Form.Item>
            </Form>
          </Tabs.TabPane>
          <Tabs.TabPane tab={<span style={{ fontSize: '16px', fontWeight: 'bold' }}>Mật khẩu</span>} key="tab 2">
            <Form form={form} onFinish={handleUpdate} name="updatePassword" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off">
              <Form.Item
                hasFeedback
                label="Last password"
                name="passwordLast"
                validateTrigger="onChange"
                rules={[
                  {
                    required: true,
                    message: 'Vui lòng nhập mật khẩu!',
                  }
                ]}
              >
                <Input.Password placeholder="Nhập mật khẩu!" />
              </Form.Item>
              <Form.Item
                hasFeedback
                label="New password (At least 6 characters)"
                name="passwordNew"
                validateTrigger="onChange"
                rules={[
                  {
                    required: true,
                    message: 'Vui lòng nhập mật khẩu mới!',
                  },
                  {
                    min: 6,
                    message: 'Mật khẩu phải có ít nhất 6 ký tự!',
                  },
                ]}
              >
                <Input.Password placeholder="Nhập mật khẩu mới" />
              </Form.Item>

              <Form.Item
                hasFeedback
                label="New password again"
                name="passwordNewCheck"
                dependencies={['passwordNew']}
                validateTrigger="onChange"
                rules={[
                  {
                    required: true,
                    message: 'Vui lòng xác nhận mật khẩu mới!',
                  },
                  ({ getFieldValue }) => ({
                    validator(_, value) {
                      if (!value || getFieldValue('passwordNew') === value) {
                        return Promise.resolve();
                      }
                      return Promise.reject(new Error('Mật khẩu xác nhận không khớp!'));
                    },
                  }),
                ]}
              >
                <Input.Password placeholder="Nhập lại mật khẩu mới" />
              </Form.Item>

              <Form.Item>
                <Button block htmlType="submit">Lưu thay đổi</Button>
              </Form.Item>
            </Form>
          </Tabs.TabPane>
        </Tabs>
      </Card>
    </Flex >
  );
};

export default SettingPage;


