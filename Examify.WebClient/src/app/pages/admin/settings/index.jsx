import { Button, Space, Watermark } from 'antd';

const SettingPage = () => {
  return (
    <div>
      <Space>
        <Button type="primary">Primary Button</Button>
        <Button type="default">Default Button</Button>
      </Space>
      <Watermark content="Settings">
        <div style={{ height: 500 }} />
      </Watermark>
    </div>
  );
};

export default SettingPage;
