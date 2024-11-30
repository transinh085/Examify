import { Col, Flex, Pagination, Row } from 'antd';
import { useMemo } from 'react';
import QuizItem from '~/components/ui/quizzes/QuizItem';

const TopicDetailsPage = () => {
  const quizzes = useMemo(
    () => [
      {
        id: 1,
        title: 'The basis of NodeJS',
        description: 'Learn the basic of NodeJS',
        image:
          'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/eb5f16ad-fc3e-41ea-824d-c11dd08cebb5?w=200&h=200',
        percent: 60,
        questions: 10,
      },
      {
        id: 2,
        title: 'The basis of JavaScript',
        description: 'Learn the basic of JavaScript',
        image:
          'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/7a3e981b-8d06-4110-b375-25d53690695d?w=200&h=200',
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
    <div className="py-4">
      <h1 className="text-lg mb-4">
        Popular quizzes for <strong>Math</strong>
      </h1>
      <Row gutter={[20, 20]}>
        {quizzes.map((quiz) => (
          <Col span={6} key={quiz.id}>
            <QuizItem {...quiz} />
          </Col>
        ))}
        {quizzes.map((quiz) => (
          <Col span={6} key={quiz.id}>
            <QuizItem {...quiz} />
          </Col>
        ))}
        {quizzes.map((quiz) => (
          <Col span={6} key={quiz.id}>
            <QuizItem {...quiz} />
          </Col>
        ))}
        {quizzes.map((quiz) => (
          <Col span={6} key={quiz.id}>
            <QuizItem {...quiz} />
          </Col>
        ))}
      </Row>
      <Flex justify="end" className="py-6">
        <Pagination defaultCurrent={1} total={50} />
      </Flex>
    </div>
  );
};

export default TopicDetailsPage;
