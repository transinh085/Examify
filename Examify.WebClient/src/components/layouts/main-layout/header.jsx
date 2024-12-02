import { Button, Flex, Input, Layout, Menu } from 'antd';
import logo from '~/assets/examify-logo.png';
import { ClockCircleOutlined, HomeOutlined, PlusCircleOutlined } from '@ant-design/icons';
import { Link, useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';
import UserDropdown from '~/components/layouts/share/user-dropdown';
const { Header: AntHeader } = Layout;

const items = [
  {
    key: '1',
    label: 'Home',
    icon: <HomeOutlined />,
    url: '/',
  },
  {
    key: '3',
    label: 'Activity',
    icon: <ClockCircleOutlined />,
    url: '/activities',
  },
];

const Header = () => {
  const navigate = useNavigate();

  const { isAuthenticated } = useAuthStore();

  const moveAdmin = () => {
    navigate('/admin');
  };

  return (
    <AntHeader className="sticky top-0 z-50 flex items-center justify-between bg-white border-b px-4">
      <Flex align="center" gap={40} className="flex-1">
        <Link to="/">
          <img src={logo} alt="logo" className="h-[40px] w-auto object-cover" />
        </Link>
        <Input.Search placeholder="Find a quiz" style={{ width: 250 }} />

        <Menu theme="light" mode="horizontal" defaultSelectedKeys={['1']} items={items} className="flex-1" />
      </Flex>

      <Flex align="center" gap={20}>
        {isAuthenticated ? (
          <>
            <Button variant="filled" color="default" icon={<PlusCircleOutlined />} onClick={moveAdmin}>
              Create a quiz
            </Button>
            <UserDropdown />
          </>
        ) : (
          <Button type="primary" onClick={() => navigate('/auth/login')}>
            Login
          </Button>
        )}
      </Flex>
    </AntHeader>
  );
};
export default Header;
