import { Watermark } from 'antd';
const DashboardPage = () => {
  return (
    <div>
      <Watermark content={['Dashboard', 'phat.le@smartr.co']}>
        <div className="h-[500px]"></div>
      </Watermark>
    </div>
  );
};

export default DashboardPage;
