import { Button, Space, Watermark } from 'antd';

const ReportPage = () => {
  return (
    <div>
      <Space>
        <Button type="primary">Primary Button</Button>
        <Button type="default">Default Button</Button>
      </Space>
      <Watermark content="Reports">
        <div style={{ height: 500 }} />
      </Watermark>
    </div>
  );
};

export default ReportPage;
