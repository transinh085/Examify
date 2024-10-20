import { Button, Space, Watermark } from 'antd';

const MyLibraryPage = () => {
  return (
    <div>
      <Space>
        <Button type="primary">Primary Button</Button>
        <Button type="default">Default Button</Button>
      </Space>
      <Watermark content="My Library">
        <div style={{ height: 500 }} />
      </Watermark>
    </div>
  );
};

export default MyLibraryPage;
