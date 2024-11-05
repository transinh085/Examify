import { LogoutOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Avatar, Dropdown } from 'antd';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';

const UserDropdown = () => {
  const navigate = useNavigate();
  const { resetUser } = useAuthStore();
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
      onClick: () => {
        localStorage.removeItem('token');
        resetUser();
        navigate('/auth/login');
      },
    },
  ];
  return (
    <Dropdown
      menu={{
        items,
      }}
      trigger={['click']}
      placement="bottomLeft"
      arrow
    >
      <Avatar size="default" src={'https://avatars.githubusercontent.com/u/45101901?v=4'} className="cursor-pointer" />
    </Dropdown>
  );
};

export default UserDropdown;
