import { Alert, Button, Card, Flex, Form, Space, Watermark, Input, Divider, Select, Tabs } from 'antd';

const SettingPage = () => {
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
            <Form name="updateEmail" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off">
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
              <Form.Item
                hasFeedback
                label="Tên tài khoản"
                name="username"
                validateTrigger="onChange"
                rules={[
                  {
                    required: true,
                    message: 'Username là bắt buộc!',
                  },
                  {
                    pattern: /^[A-Za-z][A-Za-z0-9]*$/,
                    message: 'Username phải bắt đầu bằng chữ cái và chỉ chứa chữ cái và số!',
                  },
                ]}
              >
                <Input placeholder="Nhập username" defaultValue='nbao02031_11225' />
              </Form.Item>
              <Form.Item>
                <Button block>Lưu thay đổi</Button>
              </Form.Item>
            </Form>
          </Tabs.TabPane>
          <Tabs.TabPane tab={<span style={{ fontSize: '16px', fontWeight: 'bold' }}>Mật khẩu</span>} key="tab 2">
            <Form name="updatePassword" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off">
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
                <Button block>Lưu thay đổi</Button>
              </Form.Item>
            </Form>
          </Tabs.TabPane>
        </Tabs>
      </Card>
    </Flex >
  );
};

export default SettingPage;


