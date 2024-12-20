import { LogoutOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Avatar, Dropdown, Flex } from 'antd';
import Cookies from 'js-cookie';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';

const UserDropdown = () => {
  const navigate = useNavigate();
  const { user, resetUser } = useAuthStore();

  const handleLogout = () => {
    Cookies.remove('token');
    Cookies.remove('refreshToken');
    resetUser();
    console.log('Logout');
    navigate('/auth/login');
  };
  const items = [
    {
      key: '1',
      label: 'Account info',
      icon: <UserOutlined />,
      onClick: () => {
        navigate('/admin/profile');
      },
    },
    {
      key: '2',
      label: 'Settings',
      icon: <SettingOutlined />,
      onClick: () => {
        navigate('/admin/settings');
      },
    },
    {
      key: '3',
      label: 'Logout',
      icon: <LogoutOutlined />,
      onClick: handleLogout,
      danger: true,
    },
  ];
  return (
    <Flex align="center" gap={8} justify="end">
      <Flex vertical justify="end">
        <p className="text-end text-primary font-medium text-base">
          {user?.firstName} {user?.lastName}
        </p>
        <p className="text-end text-[red]] text-xs">{user?.email}</p>
      </Flex>
      <Dropdown
        menu={{
          items,
        }}
        trigger={['click']}
        placement="bottomRight"
        arrow
      >
        <Avatar src={user?.image} className="border-2 border-primary" size={40}>
          P
        </Avatar>
      </Dropdown>
    </Flex>
  );
};

export default UserDropdown;
