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
  SettingOutlined,
} from '@ant-design/icons';
import { Link, useNavigate } from 'react-router-dom';
import { useBoolean } from '~/hooks/useBoolean';
import SettingModal from './SettingModal';
import { usePlayQuiz } from '~/features/admin/mylibrary/api/play-quiz';
import dayjs from 'dayjs';
import relativeTime from 'dayjs/plugin/relativeTime';
import blankImage from '~/assets/images/blank-thumbnail.jpg';
import { useDeleteQuiz } from '~/features/admin/mylibrary/api/delete-quiz';
dayjs.extend(relativeTime);

const TestCard = ({
  id,
  title,
  cover,
  subject,
  grade,
  owner,
  questionCount,
  createDate,
  code,
  randomQuestions,
  randomOptions,
  startTime,
  endTime,
}) => {
  const navigate = useNavigate();

  const mutePlayQuiz = usePlayQuiz({
    mutationConfig: {
      onSuccess: () => {
        navigate(`/admin/activity/classic/${id}`);
      },
      onError: (error) => {
        console.log('error', error);
      },
    },
  });

  const handlePlayQuiz = () => {
    mutePlayQuiz.mutate({ id });
  };

  return (
    <Flex className="bg-white px-2 py-2 rounded-lg border" justify="space-between">
      <Space size="middle">
        <Link to={`/admin/quiz/${id}`}>
          <img
            className="w-[240px] h-[120px] rounded-sm cursor-pointer object-cover "
            src={cover ?? blankImage}
            alt="imgTest"
          />
        </Link>
        <Space direction="vertical" size="small">
          {
          
          ? <Tag color="cyan">Public</Tag> : <Tag color="gold-inverse">Private</Tag>}
          <Link to={`/admin/quiz/${id}`}>
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
      <Flex justify="space-between" vertical align="end">

        <DropdownMenu
          id={id}
          title={title}
          code={code}
          randomQuestions={randomQuestions}
          randomOptions={randomOptions}
          startTime={startTime}
          endTime={endTime}
        />

        <Space>
          <Button onClick={handlePlayQuiz} loading={mutePlayQuiz.isPending} icon={<PlayCircleOutlined />}>
            Play
          </Button>
          <Button icon={<ShareAltOutlined />}>Share</Button>
        </Space>
      </Flex>
    </Flex>
  );
};

const DropdownMenu = ({ id, title, code, randomQuestions, randomOptions, startTime, endTime }) => {

  const { value: isSettingModalOpen, setTrue: openSettingModal, setFalse: closeSettingModal } = useBoolean();
  const handleMenuClick = ({ key }) => {
    if (key === '2') {
      openSettingModal();
    }
  };

  const deleteQuizMutation = useDeleteQuiz();

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
      label: 'Settings',
      key: '2',
      icon: <SettingOutlined />,
      onClick: openSettingModal,
    },
    {
      label: 'Delete',
      key: '3',
      icon: <DeleteOutlined />,
      danger: true,
      onClick: () => {
        deleteQuizMutation.mutate({ id });
      },
    },
  ];
  return (
    <>
      <Dropdown menu={{ items, onClick: handleMenuClick }} trigger={['click']}>
        <a onClick={(e) => e.preventDefault()}>
          <Button type="text" icon={<MoreOutlined />} size="small" />
        </a>
      </Dropdown>
      <SettingModal
        id={id}
        data={title}
        open={isSettingModalOpen}
        onCancel={closeSettingModal}
        code={code}
        randomQuestions={randomQuestions}
        randomOptions={randomOptions}
        startTime={startTime}
        endTime={endTime}
      />
    </>
  );
};

export default TestCard;
