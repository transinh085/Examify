import { Button, Space, Watermark } from 'antd';

const CollectionPage = () => {
  return (
    <div>
      <Space>
        <Button type="primary">Primary Button</Button>
        <Button type="default">Default Button</Button>
      </Space>
      <Watermark content="Collections">
        <div style={{ height: 500 }} />
      </Watermark>
    </div>
  );
};

export default CollectionPage;
