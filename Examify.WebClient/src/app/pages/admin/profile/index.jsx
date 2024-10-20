import { Button, Space, Watermark } from 'antd';

const ProfilePage = () => {
  return (
    <div>
      <Space>
        <Button type="primary">Primary Button</Button>
        <Button type="default">Default Button</Button>
      </Space>
      <Watermark content="Profile">
        <div style={{ height: 500 }} />
      </Watermark>
    </div>
  );
};

export default ProfilePage;
