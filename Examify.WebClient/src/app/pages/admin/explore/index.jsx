import { Button, Space, Watermark } from 'antd';

const ExplorePage = () => {
  return (
    <div>
      <Space>
        <Button type="primary">Primary Button</Button>
        <Button type="default">Default Button</Button>
      </Space>
      <Watermark content="Explore">
        <div style={{ height: 500 }} />
      </Watermark>
    </div>
  );
};

export default ExplorePage;
