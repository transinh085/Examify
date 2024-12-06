import { LogoutOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Avatar, Divider, Dropdown, Flex, Space, theme } from 'antd';
import Cookies from 'js-cookie';
import React from 'react';
import { useNavigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';
const { useToken } = theme;

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

  const moveProfile = () => {
    navigate('/admin/profile');
  };

  const moveSetting = () => {
    navigate('/admin/settings');
  };

  const { token } = useToken();
  const contentStyle = {
    backgroundColor: token.colorBgElevated,
    borderRadius: token.borderRadiusLG,
    boxShadow: token.boxShadowSecondary,
  };
  const menuStyle = {
    boxShadow: 'none',
  };

  const items = [
    {
      key: '1',
      label: 'Account info',
      icon: <UserOutlined />,
      onClick: moveProfile,
    },
    {
      key: '2',
      label: 'Settings',
      icon: <SettingOutlined />,
      onClick: moveSetting,
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
    <Dropdown
      menu={{
        items,
      }}
      dropdownRender={(menu) => (
        <div style={contentStyle}>
          <Space
            style={{
              padding: 8,
            }}
          >
            <Flex vertical justify="start">
              <p className="text-primary font-medium text-sm">
                {user?.firstName} {user?.lastName}
              </p>
              <p className="text-[red]] text-xs">{user?.email}</p>
            </Flex>
          </Space>
          <Divider
            style={{
              margin: 0,
            }}
          />
          {React.cloneElement(menu, {
            style: menuStyle,
          })}
        </div>
      )}
      trigger={['click']}
      placement="bottomRight"
      arrow
    >
      <Avatar src={user?.image} className="border-2 border-primary cursor-pointer" size={40}>
        P
      </Avatar>
    </Dropdown>
  );
};

export default UserDropdown;
