import {
  ScheduleOutlined,
  UserOutlined,
  FileSearchOutlined,
  SettingOutlined,
  HomeOutlined,
} from '@ant-design/icons';

const adminMenu = Object.freeze([
  {
    key: '1',
    icon: <HomeOutlined />,
    label: 'Explore',
    path: '/admin',
  },
  {
    key: '2',
    icon: <ScheduleOutlined />,
    label: 'My library',
    path: '/admin/my-library',
  },
  {
    key: '3',
    icon: <FileSearchOutlined />,
    label: 'Reports',
    path: '/admin/reports',
  },
  {
    key: '4',
    icon: <SettingOutlined />,
    label: 'Settings',
    path: '/admin/settings',
  },
  {
    key: '5',
    icon: <UserOutlined />,
    label: 'Profile',
    path: '/admin/profile',
  }
]);

export { adminMenu };
