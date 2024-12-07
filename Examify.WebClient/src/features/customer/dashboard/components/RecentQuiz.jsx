import { Card, Flex, Progress, Tag } from 'antd';
import { Link } from 'react-router-dom';

const RecentQuiz = ({ id, quizId, title, description, cover, questionCount, currentProgress }) => {
  const twoColors = {
    '0%': '#108ee9',
    '100%': '#87d068',
  };

  return (
    <Link to={`/join/game/${id}`}>
      <Card
        styles={{
          body: {
            padding: 0,
          },
        }}
        className="shadow-sm overflow-hidden cursor-pointer"
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
        </div>
        <Flex vertical justify="space-between" className="p-3 h-[130px]" gap={2}>
          <div>
            <h1 className="text-base font-semibold line-clamp-2 overflow-hidden text-ellipsis">{title}</h1>
            <p className="line-clamp-2 overflow-hidden text-ellipsis text-xs mt-2 text-[#444]">{description}</p>
          </div>
          <Progress percent={currentProgress} size={[null, 12]} strokeColor={twoColors} />
        </Flex>
      </Card>
    </Link>
  );
};

export default RecentQuiz;
