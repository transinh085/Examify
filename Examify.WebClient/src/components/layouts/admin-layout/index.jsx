import { Layout } from 'antd';
import { Outlet } from 'react-router-dom';
import FooterAdmin from '~/components/layouts/admin-layout/footer';
import HeaderAdmin from '~/components/layouts/admin-layout/header';
import SiderResponsive from '~/components/layouts/admin-layout/sider-responsive';
const { Content } = Layout;

const AdminLayout = () => {
  return (
    <Layout hasSider>
      <SiderResponsive />
      <Layout>
        <HeaderAdmin/>
        <Content
          style={{
            margin: '24px 16px 0',
            overflow: 'initial',
          }}
        >
          <Outlet />
        </Content>
        <FooterAdmin />
      </Layout>
    </Layout>
  );
};

export default AdminLayout;
