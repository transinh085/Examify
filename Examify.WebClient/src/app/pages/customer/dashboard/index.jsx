import { Watermark } from 'antd';
const DashboardPage = () => {
  return (
    <div>
      <Watermark content={'Dashboard'}>
        <div className="min-h-[calc(100vh-140px)]"></div>
      </Watermark>
    </div>
  );
};

export default DashboardPage;
