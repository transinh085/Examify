import { Card, Flex, Progress, Tag } from 'antd';
import PropTypes from 'prop-types';

const QuizItem = ({ title, description, image, percent, questions }) => {
  const twoColors = {
    '0%': '#108ee9',
    '100%': '#87d068',
  };

  return (
    <Card
      styles={{
        body: {
          padding: 0,
        },
      }}
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
  );
};

QuizItem.propTypes = {
  title: PropTypes.string,
  description: PropTypes.string,
  image: PropTypes.string,
  percent: PropTypes.number,
};

export default QuizItem;
