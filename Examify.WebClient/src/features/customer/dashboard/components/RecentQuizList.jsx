import { Button, Col, Flex, Row } from 'antd';
import { Link } from 'react-router-dom';
import { RightOutlined } from '@ant-design/icons';
import { useGetRecentActivity } from '~/features/customer/dashboard/api/get-recent-activity';
import RecentQuiz from '~/features/customer/dashboard/components/RecentQuiz';

const RecentQuizList = () => {
  const { data = [] } = useGetRecentActivity({
    pageNumber: 1,
    pageSize: 8,
  });

  console.log(data);

  return (
    <>
      <Flex align="center" justify="space-between" className="w-full">
        <h1 className="text-lg font-semibold">Recent Activity</h1>
        <Link to="/activities" className="text-blue-500">
          <Button variant="outlined" color="primary" icon={<RightOutlined />} iconPosition="end">
            See more
          </Button>
        </Link>
      </Flex>
      <Row gutter={[16, 16]}>
        {data.map((quiz) => (
          <Col xs={24} sm={12} md={8} lg={6} key={quiz.id}>
            <RecentQuiz {...quiz} />
          </Col>
        ))}
      </Row>
    </>
  );
};

export default RecentQuizList;
