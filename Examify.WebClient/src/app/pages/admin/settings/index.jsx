import { Alert, Button, Card, Flex, Form, Space, Watermark, Input, Divider, Select } from 'antd';

const SettingPage = () => {
  return (
    <Flex className='justify-center'>
      <Card
        style={{
          width: 700,
        }}
      >
        <h1 className='from-neutral-900 font-bold text-2xl'>Cài đặt</h1>
        <Divider orientation="left">Tài khoản</Divider>
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

        <Divider orientation="left">Mật khẩu</Divider>
        <Form name="updatePassword" style={{ maxWidth: 600 }} layout="vertical" autoComplete="off">
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
        <Divider orientation="left">Xóa tài khoản</Divider>
        <Button
          danger
          block
          style={{
            backgroundColor: '#fff', // Màu nền mặc định
            color: '#ff4d4f', // Màu chữ mặc định của button danger
          }}
          onMouseEnter={(e) => {
            e.target.style.backgroundColor = '#ff4d4f'; // Đổi nền sang đỏ khi hover
            e.target.style.color = '#fff'; // Đổi màu chữ sang trắng khi hover
          }}
          onMouseLeave={(e) => {
            e.target.style.backgroundColor = '#fff'; // Trở về nền mặc định
            e.target.style.color = '#ff4d4f'; // Trở về màu chữ mặc định
          }}
        >
          Danger Default
        </Button>
      </Card>
    </Flex >
  );
};

export default SettingPage;


