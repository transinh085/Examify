import { Button, Col, Flex, Row } from 'antd';
import QuizItem from '../../../components/ui/quizzes/QuizItem';
import PropTypes from 'prop-types';
import StartIcon from '~/components/icons/StartIcon';

const QuizListBySubject = ({ subjectName, quizzes = [] }) => {
  return (
    <Flex vertical gap={16}>
      <Flex align="center" justify="space-between" className="w-full">
        <Flex align="center" gap={8}>
          <StartIcon /> <h1 className="text-lg font-semibold">{subjectName}</h1>
        </Flex>
        <Button type="default">Xem thêm</Button>
      </Flex>
      <Row gutter={[16, 16]}>
        {quizzes.map((quiz) => (
          <Col span={6} key={quiz.id}>
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
