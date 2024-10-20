import { LogoutOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Avatar, Dropdown, Flex } from 'antd';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';

const UserDropdown = () => {
  const navigate = useNavigate();
  const { user, resetUser } = useAuthStore();

  const handleLogout = () => {
    localStorage.removeItem('token');
    resetUser();
    navigate('/auth/login');
  };
  const items = [
    {
      key: '1',
      label: 'Account info',
      icon: <UserOutlined />,
    },
    {
      key: '2',
      label: 'Settings',
      icon: <SettingOutlined />,
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
    <Flex align="center" gap={12} justify="end">
      <Flex vertical justify="end">
        <p className="text-end text-white font-semibold text-[14px] translate-y-[2px]">{user?.name}</p>
        <p className="text-end text-[#ccc] text-[12px] translate-y-[-2px]">{user?.email}</p>
      </Flex>
      <Dropdown
        menu={{
          items,
        }}
        trigger={['click']}
        placement="bottomRight"
        arrow
      >
        <Avatar src="https://img.freepik.com/free-psd/3d-illustration-person-with-sunglasses_23-2149436188.jpg?size=338&ext=jpg&ga=GA1.1.2008272138.1727740800&semt=ais_hybrid">
          P
        </Avatar>
      </Dropdown>
    </Flex>
  );
};

export default UserDropdown;
