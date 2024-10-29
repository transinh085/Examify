import { Button, Col, Flex, Row } from 'antd';
import QuizItem from '../../../components/ui/quizzes/QuizItem';
import PropTypes from 'prop-types';
import StartIcon from '~/components/icons/StartIcon';
import { Link } from 'react-router-dom';

const QuizListBySubject = ({ subjectName, quizzes = [] }) => {
  return (
    <Flex vertical gap={16}>
      <Flex align="center" justify="space-between" className="w-full">
        <Flex align="center" gap={8}>
          <StartIcon /> <h1 className="text-lg font-semibold">{subjectName}</h1>
        </Flex>
        <Link to="/topics/1" className="text-blue-500">
          <Button variant="outlined" color="primary">
            Xem thêm
          </Button>
        </Link>
      </Flex>
      <Row gutter={[16, 16]}>
        {quizzes.map((quiz) => (
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
