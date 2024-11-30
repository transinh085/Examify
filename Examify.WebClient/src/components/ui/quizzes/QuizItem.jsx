import { Avatar, Button, Card, Divider, Flex, Modal, Progress, Tag } from 'antd';
import PropTypes from 'prop-types';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { PlayCircleOutlined } from '@ant-design/icons';
import { useCreateQuizResultMutation } from '~/features/do-quiz/api/create-quiz-result';

const QuizItem = ({
  id,
  title,
  description,
  code,
  cover,
  questionCount,
  attemptCount,
  owner,
  grade,
  isAttempt,
  percent = 20,
}) => {
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
        className="shadow-sm overflow-hidden cursor-pointer"
        onClick={() => setOpen(true)}
      >
        <div
          className="h-[120px] bg-cover bg-center relative"
          style={{
            backgroundImage: `url(${cover})`,
          }}
        >
          <Tag color="green" className="absolute bottom-1 left-1">
            {questionCount} câu hỏi
          </Tag>
          <Tag color="cyan" className="absolute bottom-1 right-1">
            {attemptCount} lượt thi
          </Tag>
        </div>
        <Flex vertical justify="space-between" className="p-3 h-[130px]" gap={2}>
          <div>
            <h1 className="text-base font-semibold line-clamp-2 overflow-hidden text-ellipsis">{title}</h1>
            <p className="line-clamp-2 overflow-hidden text-ellipsis text-xs mt-2 text-[#444]">{description}</p>
          </div>
          {isAttempt && <Progress percent={percent} size={[null, 12]} strokeColor={twoColors} />}
        </Flex>
      </Card>
      <QuizDetailModal
        {...{ id, title, description, code, cover, questionCount, attemptCount, owner, grade, open, setOpen }}
      />
    </>
  );
};

const QuizDetailModal = ({
  title,
  description,
  code,
  cover,
  questionCount,
  attemptCount,
  owner,
  grade,
  open,
  setOpen,
}) => {
  const navigate = useNavigate();

  const createQuizResultMutation = useCreateQuizResultMutation({
    mutationConfig: {
      onSuccess: (data) => {
        navigate(`/join/game/${data.quizResultId}`);
      },
    },
  });

  const handleStartQuiz = () => {
    console.log({ code });
    createQuizResultMutation.mutate({ code });
  };

  return (
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
      rootClassName="quiz-modal"
    >
      <div
        className="w-full h-[220px] bg-cover bg-center relative"
        style={{
          backgroundImage: `url(${cover})`,
        }}
      >
        <Tag color="green" className="absolute bottom-2 left-2">
          {questionCount} câu hỏi
        </Tag>
        <Tag color="cyan" className="absolute bottom-2 right-2">
          {attemptCount} lượt thi
        </Tag>
      </div>
      <div className="p-4">
        <h1 className="text-lg font-semibold line-clamp-2 overflow-hidden text-ellipsis">{title}</h1>
        <p className="line-clamp-2 overflow-hidden text-ellipsis text-sm mt-2 text-[#444]">{description}</p>
        <Flex justify="space-between" align="center" className="pt-4">
          <Flex align="center" gap={10}>
            <Avatar src={owner?.image} />
            <h1 className="text-base font-semibold">{owner?.fullName}</h1>
          </Flex>
          <Flex align="center" gap={4}>
            <Tag color="green">{grade?.name}</Tag>
          </Flex>
        </Flex>
        <Divider className="m-3" />
        <Flex align="center" gap={10} className="pt-4">
          <Button type="primary" size="large" icon={<PlayCircleOutlined />} onClick={handleStartQuiz} block>
            Start now
          </Button>
        </Flex>
      </div>
    </Modal>
  );
};

QuizItem.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  image: PropTypes.string,
  percent: PropTypes.number,
};

export default QuizItem;
