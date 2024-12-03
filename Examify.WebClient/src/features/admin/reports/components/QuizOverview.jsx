import { Card, Flex, QRCode, Space } from 'antd';
import { useGetQuizById } from '../api/get-quiz';

const QuizOverview = ({ quizId }) => {
  const { data: quiz } = useGetQuizById({ quizId });
  return (
    <Card title="Quiz Overview">
      <Flex align="center" justify="space-between">
        <Flex align="start" gap={14}>
          <img src={quiz?.cover} alt="cover" className="w-[300px] h-auto rounded-md" />
          <Space direction="vertical" size={1} className="w-full">
            <h1 className="text-lg font-semibold">{quiz?.title}</h1>
            <p>{quiz?.description}</p>
            <p>100 lượt thi</p>
            <p>20 câu hỏi</p>
          </Space>
        </Flex>
        <Space direction="vertical" size={1} align="center">
          <QRCode value={quiz?.code} />
          <h1 className="text-lg font-semibold">{quiz?.code}</h1>
        </Space>
      </Flex>
    </Card>
  );
};

export default QuizOverview;
