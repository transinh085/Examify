import { App, Button, Flex, Input, Layout, Menu } from 'antd';
import logo from '~/assets/examify-logo.png';
import {
  ClockCircleOutlined,
  HomeOutlined,
  PlusCircleOutlined,
  QuestionCircleOutlined,
} from '@ant-design/icons';
import { Link, useNavigate } from 'react-router-dom';
import { useCreateQuiz } from '~/features/quiz/api/create-quiz';
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
    url: '/activities',
  },
];

const Header = () => {
  const { message } = App.useApp();
  const navigate = useNavigate();

  const { mutate } = useCreateQuiz({
    mutationConfig: {
      onSuccess: (data) => {
        console.log('data', data);
        navigate(`/quiz/${data.id}`);
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const createQuizHandler = () => {
    console.log('createQuizHandler');
    mutate();
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
        <Button variant="filled" color="default" icon={<PlusCircleOutlined />} onClick={createQuizHandler}>
          Create a quiz
        </Button>
        <Button type='primary' onClick={() => navigate('/auth/login')}>Login</Button>
      </Flex>
    </AntHeader>
  );
};
export default Header;
