import {
  ScheduleOutlined,
  FileSearchOutlined,
  HomeOutlined,
  OpenAIOutlined,
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
    icon: <OpenAIOutlined />,
    label: 'Examtify AI',
    path: '/admin/examtify-ai',
  }
]);

export { adminMenu };
