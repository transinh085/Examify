import { Button, Col, Flex, Row, Space } from 'antd';
import { Link } from 'react-router-dom';
import { RightOutlined, StarFilled } from '@ant-design/icons';
import { useGetRecentActivity } from '~/features/customer/dashboard/api/get-recent-activity';
import RecentQuiz from '~/features/customer/dashboard/components/RecentQuizItem';
import QuizItemSkeleton from '~/features/customer/dashboard/components/QuizItemSkeleton';

const RecentQuizList = () => {
  const {
    data = {
      items: [],
    },
    isLoading,
  } = useGetRecentActivity({
    pageNumber: 1,
    pageSize: 4,
  });

  return (
    <div>
      <Flex align="center" justify="space-between" className="w-full mb-4">
        <Space align="center">
          <StarFilled className="text-yellow-500 text-xl sm:text-2xl" />
          <h1 className="text-lg font-semibold">Recent Activity</h1>
        </Space>
        <Link to="/activities" className="text-blue-500">
          <Button variant="outlined" color="primary" icon={<RightOutlined />} iconPosition="end">
            See more
          </Button>
        </Link>
      </Flex>
      <Row gutter={[16, 16]}>
        {isLoading
          ? Array.from({ length: 4 }).map((_, index) => (
              <Col xs={24} sm={12} md={8} lg={6} key={index}>
                <QuizItemSkeleton />
              </Col>
            ))
          : data.items.map((quiz) => (
              <Col xs={24} sm={12} md={8} lg={6} key={quiz.id}>
                <RecentQuiz {...quiz} />
              </Col>
            ))}
      </Row>
    </div>
  );
};

export default RecentQuizList;
