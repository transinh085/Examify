import { Button, Col, Flex, Row } from 'antd';
import PropTypes from 'prop-types';
import StartIcon from '~/components/icons/StartIcon';
import { Link } from 'react-router-dom';
import { RightOutlined } from '@ant-design/icons';
import QuizItemSkeleton from '~/features/customer/dashboard/components/QuizItemSkeleton';
import QuizItem from '~/features/customer/dashboard/components/QuizItem';
import { useSearchQuiz } from '~/features/customer/dashboard/api/search-quizzes';

const QuizListBySubject = ({ id, name }) => {
  const { data = [], isLoading } = useSearchQuiz({ subjectId: id, pageNumber: 1, pageSize: 4 });
  return (
    <Flex vertical gap={16}>
      <Flex align="center" justify="space-between" className="w-full">
        <Flex align="center" gap={8}>
          <StartIcon /> <h1 className="text-lg font-semibold">{name}</h1>
        </Flex>
        <Link to={`/search?subjectId=${id}&subjectName=${name}`} className="text-blue-500">
          <Button variant="outlined" color="primary" icon={<RightOutlined />} iconPosition="end">
            See more
          </Button>
        </Link>
      </Flex>
      <Row gutter={[16, 16]}>
        {isLoading
          ? Array.from({ length: 8 }).map((_, index) => (
              <Col xs={24} sm={12} md={8} lg={6} key={index}>
                <QuizItemSkeleton />
              </Col>
            ))
          : data?.items &&
            data?.items.map((quiz) => (
              <Col xs={24} sm={12} md={8} lg={6} key={quiz.id}>
                <QuizItem {...quiz} />
              </Col>
            ))}
      </Row>
    </Flex>
  );
};

QuizListBySubject.propTypes = {
  subjectName: PropTypes.string,
  quizzes: PropTypes.array,
};

export default QuizListBySubject;
