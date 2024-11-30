import { Layout } from 'antd';
import { Outlet } from 'react-router-dom';
import FooterAdmin from '~/components/layouts/admin-layout/footer';
import HeaderAdmin from '~/components/layouts/admin-layout/header';
import SiderResponsive from '~/components/layouts/admin-layout/sider-responsive';
import ScrollToTop from '~/components/ScrollToTop';
const { Content } = Layout;

const AdminLayout = () => {
  return (
    <>
      <Layout hasSider className="h-full">
        <SiderResponsive />
        <Layout>
          <HeaderAdmin />
          <Content
            style={{
              margin: '24px 16px 0',
              overflow: 'initial',
            }}
          >
            <Outlet />
            <ScrollToTop />
          </Content>
          <FooterAdmin />
        </Layout>
      </Layout>
    </>
  );
};

export default AdminLayout;
