import { Card, Flex, Progress, Tag } from 'antd';
import PropTypes from 'prop-types';
import { useState } from 'react';
import QuizDetailModal from '~/features/customer/dashboard/components/QuizDetailModal';

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



QuizItem.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  image: PropTypes.string,
  percent: PropTypes.number,
};

export default QuizItem;
