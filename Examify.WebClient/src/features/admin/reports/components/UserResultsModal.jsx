import { Avatar, Card, Checkbox, Col, Divider, Flex, Modal, Progress, Row, Segmented, Space, Tag } from 'antd';
import PropTypes from 'prop-types';
import { useGetUserResultsOfQuiz } from '../api/get-user-results-of-quiz';
import { useMemo, useState } from 'react';
import CorrectIcon from '~/components/icons/CorrectIcon';
import IncorrectIcon from '~/components/icons/IncorrectIcon';

const UserResultsModal = ({ open, handleClose, userId, quizId }) => {
  const [selectedAttempt, setSelectedAttempt] = useState(0);
  const { data: userResults } = useGetUserResultsOfQuiz({
    quizId,
    userId,
    queryOptions: { initialData: [], enabled: !!quizId && !!userId },
  });

  const options = useMemo(
    () =>
      (userResults || []).map((result) => ({
        label: 'Attempt ' + result.attemptedNumber,
        value: result.attemptedNumber,
      })),
    [userResults],
  );

  const correctQuestionRate = useMemo(() => {
    if (userResults) {
      const totalQuestions = userResults?.[selectedAttempt]?.questionResults?.length;
      const correctQuestions = userResults?.[selectedAttempt]?.questionResults?.filter(
        (questionResult) => questionResult.isCorrect,
      ).length;
      return (correctQuestions / totalQuestions) * 100;
    }
  }, [userResults, selectedAttempt]);

  return (
    <Modal title="User Results" centered open={open} onOk={handleClose} onCancel={handleClose} width={740}>
      <Space direction="vertical" size={10} className="w-full">
        <Space>
          <Avatar src={userResults?.[0]?.user?.avatar} />
          <Space>
            <h1 className="font-semibold">{userResults?.[0]?.user?.name}</h1>
          </Space>
        </Space>
        <Segmented
          options={options}
          onChange={(value) => {
            setSelectedAttempt(value - 1);
          }}
        />
        <Space
          direction="vertical"
          size={20}
          className="w-full h-[500px] overflow-y-auto overflow-x-hidden hidden-scrollbar"
        >
          <Row gutter={[20, 20]}>
            <Col span={8}>
              <Card>
                <h2>Your point</h2>
                <h1 className="text-[32px] font-semibold text-primary">
                  {userResults?.[selectedAttempt]?.totalPoints}
                </h1>
              </Card>
            </Col>
            <Col span={8}>
              <Card>
                <h2>Your time</h2>
                <h1 className="text-[32px] font-semibold text-primary">{userResults?.[selectedAttempt]?.timeTaken}</h1>
              </Card>
            </Col>
            <Col span={8}>
              <Card>
                <h2>Correct question</h2>
                <Progress type="circle" strokeColor="#00c985" percent={correctQuestionRate} size={42} />
              </Card>
            </Col>
          </Row>
          <Space direction="vertical" className="w-full">
            {userResults?.[selectedAttempt]?.questionResults?.map((questionResults) => (
              <Card key={questionResults.id}>
                <Flex align="center" justify="space-between">
                  <Tag color="cyan">{questionResults?.question?.type}</Tag>
                  <Space>
                    <p>
                      <strong className="font-medium">{questionResults?.timeTaken}</strong>s
                    </p>
                    <Divider type="vertical" />
                    <p>
                      <strong className="font-medium">{questionResults?.points}</strong> points
                    </p>
                  </Space>
                </Flex>
                <Space>
                  <h1 className="font-semibold my-2">
                    Question {questionResults?.order + 1}: {questionResults?.question?.content}
                  </h1>{' '}
                  {questionResults?.isCorrect ? <CorrectIcon /> : <IncorrectIcon />}
                </Space>
                <Space direction="vertical" size={14} className="w-full">
                  {questionResults?.answerResults?.map((answerResult) => (
                    <Space key={answerResult?.id} size={16} className="w-full">
                      {answerResult?.option?.isCorrect ? <CorrectIcon /> : <IncorrectIcon />}
                      <Checkbox checked={answerResult?.isSelected} />
                      <p>{answerResult?.option?.content}</p>
                    </Space>
                  ))}
                </Space>
              </Card>
            ))}
          </Space>
        </Space>
      </Space>
    </Modal>
  );
};

UserResultsModal.propTypes = {
  open: PropTypes.bool,
  handleClose: PropTypes.func,
  userId: PropTypes.string,
  quizId: PropTypes.string,
};

export default UserResultsModal;
