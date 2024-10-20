import {
  HomeOutlined,
  ScheduleOutlined,
  UserOutlined,
  TeamOutlined,
  FileSearchOutlined,
  DollarOutlined,
  BarChartOutlined,
  TruckOutlined,
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
    icon: <UserOutlined />,
    label: 'Settings',
    path: '/admin/settings',
  },
  {
    key: '5',
    icon: <DollarOutlined />,
    label: 'Memes',
    path: '/admin/memes',
  },
  {
    key: '6',
    icon: <TeamOutlined />,
    label: 'Collections',
    path: '/admin/collections',
  },
  {
    key: '7',
    icon: <TruckOutlined />,
    label: 'Profile',
    path: '/admin/profile',
  },
  {
    key: '8',
    icon: <BarChartOutlined />,
    label: 'Logout',
  },
]);

const userMenu = Object.freeze([
  { title: 'Home', href: '/' },
  { title: 'Schedule', href: '/schedules' },
  { title: 'Tickets', href: '/tickets' },
  { title: 'Orders', href: '/orders' },
  { title: 'Contact', href: '/contacts' },
  { title: 'About', href: '/about' },
]);

export { adminMenu, userMenu };
