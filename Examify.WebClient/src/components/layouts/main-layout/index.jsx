import { Layout } from 'antd';
import Footer from './footer';
import Header from './header';
import { Outlet } from 'react-router-dom';
import ScrollToTop from '~/components/ScrollToTop';

const MainLayout = () => {
  return (
    <Layout className="bg-[#f3f3f5]">
      <Header />
      <div className="w-[90%] md:w-[90%] xl:w-[1128px] 2xl:w-[1128px] mx-auto">
        <Outlet />
        <ScrollToTop />
      </div>
      <Footer style={{ textAlign: 'center' }}>Ant Design ©{new Date().getFullYear()} Created by Ant UED</Footer>
    </Layout>
  );
};

export default MainLayout;
