import { Button, Col, Flex, Row } from 'antd';
import QuizItem from '../../../components/ui/quizzes/QuizItem';
import { useMemo } from 'react';
import { Link } from 'react-router-dom';
import { RightOutlined } from '@ant-design/icons';

const RecentQuizList = () => {
  const recentQuizzes = useMemo(
    () => [
      {
        id: 1,
        title: 'The basis of NodeJS',
        description: 'Learn the basic of NodeJS',
        image: 'https://quizizz.com/_media/quizzes/ceab73a2-cd9d-466b-9dd8-6a0542929083-v2_200_200',
        percent: 60,
        questions: 10,
      },
      {
        id: 2,
        title: 'The basis of JavaScript',
        description: 'Learn the basic of JavaScript',
        image:
          'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/d03df85b-786b-4b70-87c9-6a44de4a8488?w=200&h=200',
        percent: 100,
        questions: 24,
      },
      {
        id: 3,
        title: 'The basis of Object Oriented Programming',
        description: 'Learn the basic of Object Oriented Programming',
        image:
          'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/c098205b-98c5-4f86-bb67-9ec047a483f3?w=200&h=200',
        percent: 100,
        questions: 8,
      },
      {
        id: 4,
        title: 'The basis of JavaScript',
        description: 'Learn the basic of JavaScript',
        image:
          'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/a2c54d45-a4d2-494c-8734-0ea27b4992e2?w=200&h=200',
        percent: 100,
        questions: 16,
      },
    ],
    [],
  );
  return (
    <>
      <Flex align="center" justify="space-between" className="w-full">
        <h1 className="text-lg font-semibold">Recent Activity</h1>
        <Link to="/topics/1" className="text-blue-500">
          <Button variant="outlined" color="primary" icon={<RightOutlined />} iconPosition="end">
            See more
          </Button>
        </Link>
      </Flex>
      <Row gutter={[16, 16]}>
        {recentQuizzes.map((quiz) => (
          <Col xs={24} sm={12} md={8} lg={6} key={quiz.id}>
            <QuizItem {...quiz} />
          </Col>
        ))}
      </Row>
    </>
  );
};

export default RecentQuizList;
