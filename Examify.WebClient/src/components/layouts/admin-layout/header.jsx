import {
  BellOutlined,
  MenuFoldOutlined,
  MenuUnfoldOutlined,
  QuestionOutlined,
  SearchOutlined,
} from '@ant-design/icons';
import { Avatar, Button, Flex, Grid, Input, Layout, Popover, Space } from 'antd';
import { useNavigate } from 'react-router-dom';
import UserDropdown from '~/components/layouts/share/user-dropdown';
import useMenuStore from '~/stores/menu-store';
const { Header } = Layout;

const HeaderAdmin = () => {
  const { siderVisible, setSiderVisible } = useMenuStore();
  const breakpoint = Grid.useBreakpoint();
  const isMobile = typeof breakpoint.lg === 'undefined' ? false : !breakpoint.lg;
  const navigate = useNavigate();

  const moveJoin = () => {
    navigate('/join');
  };
  return (
    <Header className="p-0 bg-white sticky top-0 z-50 shadow-sm flex justify-between items-center px-5">
      <Space>
        <Button
          type="text"
          icon={siderVisible ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
          onClick={() => setSiderVisible(!siderVisible)}
        />
        <Input placeholder="Tìm kiếm..." variant="filled" suffix={<SearchOutlined />} />
      </Space>
      <Flex gap={10}>
        {isMobile ? (
          <UserDropdown />
        ) : (
          <>
            <NotificationButton />
            <Button className="font-bold" onClick={moveJoin}>
              Enter code
            </Button>
            <Button className="font-bold" icon={<QuestionOutlined />}>
              Help
            </Button>
            <UserDropdown />
          </>
        )}
      </Flex>
    </Header>
  );
};

const NotificationButton = () => {
  const content = (
    <div className="space-y-2">
      <Flex className="space-x-2 p-2 bg-gray-50 rounded-md cursor-pointer" align="center">
        <Avatar src="https://avatars.githubusercontent.com/u/120194990?v=4" alt="Avatar" size={30} />
        <p className="text-sm">You have a new message</p>
      </Flex>
      <Flex className="space-x-2 p-2 bg-gray-50 rounded-md cursor-pointer" align="center">
        <Avatar src="https://avatars.githubusercontent.com/u/120194990?v=4" alt="Avatar" size={30} />
        <p className="text-sm">You have a new message</p>
      </Flex>
      <Flex className="space-x-2 p-2 bg-gray-50 rounded-md cursor-pointer" align="center">
        <Avatar src="https://avatars.githubusercontent.com/u/120194990?v=4" alt="Avatar" size={30} />
        <p className="text-sm">You have a new message</p>
      </Flex>
    </div>
  );

  return (
    <Popover
      placement="bottomRight"
      content={content}
      title={<span className="font-semibold text-gray-800">Notifications</span>}
      trigger="click"
    >
      <Button icon={<BellOutlined />} />
    </Popover>
  );
};

export default HeaderAdmin;
