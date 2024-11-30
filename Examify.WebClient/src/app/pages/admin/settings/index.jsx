import { Alert, Button, Card, Flex, Form, Space, Watermark, Input, Divider, Select, Tabs, message } from 'antd';
import { json } from 'react-router-dom';
import { useUpdatePasswordMutation } from '~/features/auth/api/update-password';
import { useUpdateUserMutation } from '~/features/auth/api/update-user';
import useAuthStore from '~/stores/auth-store';
import UploadCover from '~/features/quiz/components/question/UploadCover';

const SettingPage = () => {
  const { user, resetUser, setUserProfile } = useAuthStore();
  const [form] = Form.useForm();
  const mutationPassword = useUpdatePasswordMutation({
    mutationConfig: {
      onSuccess: (data) => {
        message.success('Update succeed')
      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Something went wrong!');
      },
    },
  });

  const mutationUser = useUpdateUserMutation({
    mutationConfig: {
      onSuccess: (data) => {
        message.success('Update succeed');
        setUserProfile({ lastName: data.lastName, firstName: data.firstName });

      },
      onError: ({ response }) => {
        message.error(response?.data?.detail || 'Sai Sai Sai!');
      },
    },
  });

  const handleUpdatePassword = (data) => {
    mutationPassword.mutate({
      email: user.email,
      oldPassword: data.passwordLast,
      newPassword: data.passwordNew,
    });
  };
  const handleUpdateUser = (data) => {
    mutationUser.mutate({
      id: user.id,
      firstName: data.firstName,
      lastName: data.lastName,
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
            <Form form={form} name="updateEmail" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off"
              initialValues={{ email: user.email, firstName: user.firstName, lastName: user.lastName, image: user.image }}
              onFinish={handleUpdateUser}>
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
                <Input placeholder="Validate required onBlur" defaultValue={user.email} readOnly />
              </Form.Item>
              <Form.Item
                name="firstName"
                label="Tên"
                rules={[
                  {
                    type: 'firstname',
                    message: 'The input is not valid Firstname!',
                  },
                  {
                    required: true,
                    message: 'Please input your Firstname!',
                  },
                ]}
              >
                <Input defaultValue={user.firstName} />
              </Form.Item>
              <Form.Item
                name="lastName"
                label="Họ"
                rules={[
                  {
                    type: 'lastname',
                    message: 'The input is not valid Lastname!',
                  },
                  {
                    required: true,
                    message: 'Please input your Lastname!',
                  },
                ]}
              >
                <Input defaultValue={user.lastName} />
              </Form.Item>
              <Form.Item label="Image" name="image">
                {/* <UploadCover url={user.image} setFieldsValue={(value) => form.setFieldsValue({ image: value })} /> */}
              </Form.Item>
              <Form.Item>
                <Button block htmlType="submit">Lưu thay đổi</Button>
              </Form.Item>
            </Form>
          </Tabs.TabPane>
          <Tabs.TabPane tab={<span style={{ fontSize: '16px', fontWeight: 'bold' }}>Mật khẩu</span>} key="tab 2">
            <Form form={form} onFinish={handleUpdatePassword} name="updatePassword" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off">
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


