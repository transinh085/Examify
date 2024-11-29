import { Avatar, Button, Card, Divider, Flex, Modal, Progress, Tag } from 'antd';
import PropTypes from 'prop-types';
import { useState } from 'react';
import { Link } from 'react-router-dom';
import { PlayCircleOutlined } from '@ant-design/icons';

const QuizItem = ({ title, description, image, percent, questions }) => {
  const [open, setOpen] = useState(false);
  const twoColors = {
    '0%': '#108ee9',
    '100%': '#87d068',
  };

  return (
    <>
      <Card
        styles={{
          body: {
            padding: 0,
          },
        }}
        onClick={() => setOpen(true)}
      >
        <div
          className="h-[120px] bg-cover bg-center relative"
          style={{
            backgroundImage: `url(${image})`,
          }}
        >
          <Tag color="green" className="absolute bottom-1 left-2">
            {questions} câu hỏi
          </Tag>
        </div>
        <Flex vertical justify="space-between" className="p-3 h-[150px]" gap={2}>
          <div>
            <h1 className="text-base font-semibold line-clamp-2 overflow-hidden text-ellipsis">{title}</h1>
            <p className="line-clamp-2 overflow-hidden text-ellipsis text-xs mt-2 text-[#444]">{description}</p>
          </div>

          <Progress percent={percent} size={[null, 12]} strokeColor={twoColors} />
        </Flex>
      </Card>
      <Modal
        title={null}
        footer={null}
        open={open}
        onCancel={() => setOpen(false)}
        styles={{
          content: {
            padding: 0,
            overflow: 'hidden',
          },
        }}
      >
        <div
          className="w-full h-[220px] bg-cover bg-center relative"
          style={{
            backgroundImage: `url(${image})`,
          }}
        >
          <Tag color="green" className="absolute bottom-2 left-2">
            {questions} câu hỏi
          </Tag>
          <Tag color="cyan" className="absolute bottom-2 right-2">
            120 lượt thi
          </Tag>
        </div>
        <div className="p-4">
          <h1 className="text-lg font-semibold line-clamp-2 overflow-hidden text-ellipsis">{title}</h1>
          <p className="line-clamp-2 overflow-hidden text-ellipsis text-base mt-2 text-[#444]">{description}</p>
          <Flex justify="space-between">
            <Flex align="center" gap={10} className="pt-3">
              <Avatar src={'https://avatars.githubusercontent.com/u/93178609?v=4'} />
              <h1 className="text-base font-semibold">Quan Phat</h1>
            </Flex>
            <Flex align="center" gap={4}>
              <p>Lớp: </p>
              <Tag color="green">8</Tag>
              <Tag color="green">9</Tag>
              <Tag color="green">10</Tag>
            </Flex>
          </Flex>
          <Divider className="m-3" />
          <p>
            Cấp độ khó: <strong>Trung bình</strong>
          </p>
          <p>Câu hỏi mẫu: ...</p>
          <Flex align="center" gap={10} className="pt-4">
            <Link to="/join/game/1" className="flex-1">
              <Button type="primary" size="large" icon={<PlayCircleOutlined />} block>
                Start now
              </Button>
            </Link>
          </Flex>
        </div>
      </Modal>
    </>
  );
};

QuizItem.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  image: PropTypes.string,
  percent: PropTypes.number,
};

export default QuizItem;
