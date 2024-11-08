import { MenuFoldOutlined, MenuUnfoldOutlined, SearchOutlined } from '@ant-design/icons';
import { Button, Input, Layout, Space } from 'antd';
import UserDropdown from '~/components/layouts/share/user-dropdown';
import useMenuStore from '~/stores/menu-store';
const { Header } = Layout;

const HeaderAdmin = () => {
  const { siderVisible, setSiderVisible } = useMenuStore();
  return (
    <Header className="p-0 bg-white sticky top-0 z-50 shadow-sm flex justify-between items-center px-5">
      <Space>
        <Button
          type="text"
          icon={siderVisible ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
          onClick={() => setSiderVisible(!siderVisible)}
        />
        <Input placeholder="Tìm kiếm..." variant="filled" suffix={<SearchOutlined />} />
      </Space>
      <UserDropdown />
    </Header>
  );
};

export default HeaderAdmin;
