import { Avatar, Button, Dropdown, Flex, Space, Tag } from 'antd';
import {
  DeleteOutlined,
  HeatMapOutlined,
  LikeOutlined,
  MoreOutlined,
  PlayCircleOutlined,
  RadarChartOutlined,
  ShareAltOutlined,
  UnorderedListOutlined,
} from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';

const TestCard = ({ id, imgSrc, title, author, date, tags, details }) => {
  const navigate = useNavigate();

  const handleCardClick = () => {
    navigate(`/admin/quiz/${id}`);
  };
  return (
    <Flex className="bg-white px-2 py-2 rounded-lg border" justify="space-between">
      <Space size="middle">
        <img
          onClick={handleCardClick}
          className="w-[120px] h-[120px] rounded-sm cursor-pointer"
          src={imgSrc}
          alt="imgTest"
        />
        <Space direction="vertical" size="small">
          <Tag>{tags}</Tag>
          <h1 onClick={handleCardClick} className="font-bold cursor-pointer hover:underline">
            {title}
          </h1>
          <Space size="small">
            {/* Icon info */}
            <Space>
              <UnorderedListOutlined />
              <span className="text-xs">{details.questions}</span>
            </Space>
            <Space>
              <HeatMapOutlined />
              <span className="text-xs">{details.grade}</span>
            </Space>
            <Space>
              <RadarChartOutlined />
              <span className="text-xs">{details.subject}</span>
            </Space>
          </Space>
          <Space size="small">
            <Avatar size={20} src="https://avatars.githubusercontent.com/u/120194990?v=4" />
            <span className="text-xs">{author}</span>
            <span className="text-xs">.</span>
            <span className="text-xs">{date}</span>
          </Space>
        </Space>
      </Space>
      <Flex justify="space-between" vertical align="end">
        <DropdownMenu />
        <Space>
          <Button icon={<PlayCircleOutlined />}>Play</Button>
          <Button icon={<ShareAltOutlined />}>Share</Button>
        </Space>
      </Flex>
    </Flex>
  );
};

const DropdownMenu = () => {
  const items = [
    {
      label: 'Like',
      key: '0',
      icon: <LikeOutlined />,
    },
    {
      label: 'Share',
      key: '1',
      icon: <ShareAltOutlined />,
    },
    {
      label: 'Delete',
      key: '2',
      icon: <DeleteOutlined />,
      danger: true,
    },
  ];
  return (
    <Dropdown menu={{ items }} trigger={['click']}>
      <a onClick={(e) => e.preventDefault()}>
        <Button type="text" icon={<MoreOutlined />} size="small" />
      </a>
    </Dropdown>
  );
};

export default TestCard;
