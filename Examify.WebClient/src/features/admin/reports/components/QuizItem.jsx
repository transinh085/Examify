import { HeatMapOutlined, RadarChartOutlined, UnorderedListOutlined } from '@ant-design/icons';
import { Avatar, Flex, Space, Tag } from 'antd';
import dayjs from 'dayjs';
import { Link } from 'react-router-dom';
import blankImage from '~/assets/images/blank-thumbnail.jpg';
import relativeTime from 'dayjs/plugin/relativeTime';
dayjs.extend(relativeTime);

const QuizItem = ({ id, title, cover, subject, grade, owner, questionCount, createDate }) => {
  return (
    <Flex className="bg-white px-2 py-2 rounded-lg border" justify="space-between">
      <Space size="middle">
        <Link to={id}>
          <img
            className="w-[200px] h-[120px] rounded-sm cursor-pointer object-cover "
            src={cover ?? blankImage}
            alt="imgTest"
          />
        </Link>
        <Space direction="vertical" size="small">
          <Tag color="cyan">Assessment</Tag>
          <Link to={id}>
            <h1 className="font-bold cursor-pointer hover:underline">{title}</h1>
          </Link>
          <Space size="small">
            {/* Icon info */}
            <Space>
              <UnorderedListOutlined />
              <span className="text-xs">{questionCount}</span>
            </Space>
            <Space>
              <HeatMapOutlined />
              <span className="text-xs">{grade.name ?? 'N/A'}</span>
            </Space>
            <Space>
              <RadarChartOutlined />
              <span className="text-xs">{subject.name ?? 'N/A'}</span>
            </Space>
          </Space>
          <Space size="small">
            <Avatar size={20} src={owner?.image} />
            <span className="text-xs">{owner?.fullName}</span>
            <span className="text-xs">-</span>
            <span className="text-xs">{dayjs(createDate).fromNow()}</span>
          </Space>
        </Space>
      </Space>
    </Flex>
  );
};

export default QuizItem;
