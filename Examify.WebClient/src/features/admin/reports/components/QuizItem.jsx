import { HeatMapOutlined, RadarChartOutlined, UnorderedListOutlined } from '@ant-design/icons';
import { Avatar, Card, Space, Tag } from 'antd';
import moment from 'moment';
import { Link } from 'react-router-dom';

const QuizItem = ({ id, imgSrc, title, author, date, questions, gradeName, languageName }) => {
  return (
    <Card
      styles={{
        body: {
          padding: 0,
        },
      }}
    >
      <Space size="middle" className="p-2">
        <img
          className="w-[240px] h-[120px] rounded-sm cursor-pointer object-cover"
          src={imgSrc ?? 'https://avatars.githubusercontent.com/u/120194990?v=4'}
          alt="imgTest"
        />
        <Space direction="vertical" size="small">
          <Tag color="cyan">Assessment</Tag>
          <Link to={id}>
            <h1 className="font-bold cursor-pointer hover:underline">{title}</h1>
          </Link>
          <Space size="small">
            <Space>
              <UnorderedListOutlined />
              <span className="text-xs">{questions?.length}</span>
            </Space>
            <Space>
              <HeatMapOutlined />
              <span className="text-xs">{gradeName ?? ''}</span>
            </Space>
            <Space>
              <RadarChartOutlined />
              <span className="text-xs">{languageName ?? ''}</span>
            </Space>
          </Space>
          <Space size="small">
            <Avatar size={20} src={author?.image} />
            <span className="text-xs">{author?.name}</span>
            <span className="text-xs">-</span>
            <span className="text-xs">{moment(date).fromNow()}</span>
          </Space>
        </Space>
      </Space>
    </Card>
  );
};

export default QuizItem;
