import { Avatar, Button, Flex, Input, Layout, Menu } from 'antd';
import logo from '~/assets/examify-logo.png';
import {
  ClockCircleOutlined,
  HomeOutlined,
  PlusCircleOutlined,
  QuestionCircleOutlined,
  UserOutlined,
} from '@ant-design/icons';
import { Link } from 'react-router-dom';
const { Header: AntHeader } = Layout;

const items = [
  {
    key: '1',
    label: 'Home',
    icon: <HomeOutlined />,
    url: '/',
  },
  {
    key: '2',
    label: 'Quiz',
    icon: <QuestionCircleOutlined />,
    url: '/quiz',
  },
  {
    key: '3',
    label: 'Activity',
    icon: <ClockCircleOutlined />,
    url: '/activity',
  },
];

const Header = () => {
  return (
    <AntHeader className="sticky top-0 z-50 flex items-center justify-between bg-white border-b border-1 px-4">
      <Flex align="center" gap={40} className="flex-1">
        <Link to="/">
          <img src={logo} alt="logo" className="h-[40px] w-auto" />
        </Link>
        <Input.Search placeholder="Find a quiz" style={{ width: 250 }} />

        <Menu theme="light" mode="horizontal" defaultSelectedKeys={['1']} items={items} className="flex-1" />
      </Flex>

      <Flex align="center" gap={20}>
        <Link to="/create-quiz">
          <Button variant="filled" color="default" icon={<PlusCircleOutlined />}>
            Create a quiz
          </Button>
        </Link>
        <Avatar style={{ backgroundColor: '#87d068' }} icon={<UserOutlined />} />
      </Flex>
    </AntHeader>
  );
};
export default Header;
