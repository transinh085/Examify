import { Layout } from 'antd';
import ReportList from '~/features/admin/reports/components/ReportList';

const { Content } = Layout;

const ReportPage = () => {
  return (
    <Content>
      <ReportList  />
    </Content>
  );
};

export default ReportPage;
