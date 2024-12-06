import { Button, Flex, Input, Layout, Menu } from 'antd';
import logo from '~/assets/examify-logo.png';
import { ClockCircleOutlined, HomeOutlined, PlusCircleOutlined } from '@ant-design/icons';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';
import UserDropdown from '~/components/layouts/share/user-dropdown';
import { useMemo } from 'react';
const { Header: AntHeader } = Layout;

const items = [
  {
    key: '1',
    label: <Link to="/">Home</Link>,
    icon: <HomeOutlined />,
  },
  {
    key: '2',
    label: <Link to="/activities">Recent activity</Link>,
    icon: <ClockCircleOutlined />,
  },
];

const Header = () => {
  const navigate = useNavigate();
  const { isAuthenticated } = useAuthStore();
  const location = useLocation();

  const currentKey = useMemo(() => {
    return items.find((item) => item.label.props.to === location.pathname)?.key;
  }, [location.pathname]);

  console.log(location.pathname, currentKey);

  return (
    <AntHeader className="sticky top-0 z-50 flex items-center justify-between bg-white border-b px-4">
      <Flex align="center" gap={40} className="flex-1">
        <Link to="/">
          <img src={logo} alt="logo" className="h-[40px] w-auto object-cover" />
        </Link>
        <Input.Search
          placeholder="Find a quiz"
          style={{ width: 250 }}
          onSearch={(value) => {
            navigate(`/search?keyword=${value}`);
          }}
        />
        <Menu
          theme="light"
          mode="horizontal"
          selectedKeys={[currentKey ?? '1']}
          items={items}
          className="flex-1"
        />
      </Flex>

      <Flex align="center" gap={20}>
        {isAuthenticated ? (
          <>
            <Link to="/admin">
              <Button variant="filled" color="default" icon={<PlusCircleOutlined />}>
                Create a quiz
              </Button>
            </Link>
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
