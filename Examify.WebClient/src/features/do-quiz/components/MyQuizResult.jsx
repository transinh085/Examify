import { Avatar, Button, Card, Checkbox, Col, Divider, Flex, Row, Space, Tag } from 'antd';
import { Link } from 'react-router-dom';
import CorrectIcon from '~/components/icons/CorrectIcon';
import IncorrectIcon from '~/components/icons/IncorrectIcon';
import useDoQuizStore from '~/stores/do-quiz-store';

// import pointGif from '~/assets/gif/a.gif';
// import timeGif from '~/assets/gif/d.gif';
import useAuthStore from '~/stores/auth-store';

const MyQuizResult = () => {
  const { user } = useAuthStore();
  const { totalPoints, timeTaken, questionResults } = useDoQuizStore();
  return (
    <Flex justify="space-between" className="py-8 h-full">
      <Space direction="vertical" size={24} className="w-[640px] mx-auto h-full overflow-y-auto px-4 custom-scrollbar">
        <Card className="bg-[#2a0830] border-none">
          <Flex size={24} className="w-full text-white">
            <Space className="w-full">
              <Avatar size="large" src={user?.image} />
              <Space direction="vertical" align="start" size={0}>
                <h1 className="font-semibold">
                  {user?.firstName} {user?.lastName}
                </h1>
                <p className="opacity-80 text-xs">{user?.email}</p>
              </Space>
            </Space>
            <Link to={'/'}>
              <Button type="primary" shape="default" className="!bg-[#6d387d] !hover:bg-[red] float-end" onClick={null}>
                Back to home
              </Button>
            </Link>
          </Flex>
        </Card>
        <Card className="bg-[#2a0830] border-none">
          <Row gutter={[24, 24]}>
            <Col span={12}>
              <Card className="bg-white border-none">
                <Flex justify="space-between" className="w-full">
                  <Space direction="vertical" className="w-full">
                    <h1 className="text-lg opacity-70">Your point</h1>
                    <h1 className="text-[32px] font-semibold text-primary">{totalPoints}</h1>
                  </Space>
                  {/* <img src={pointGif} alt="gif" className="w-[100px]" /> */}
                </Flex>
              </Card>
            </Col>
            <Col span={12}>
              <Card className="bg-white border-none">
                <Flex justify="space-between" className="w-full">
                  <Space direction="vertical" className="w-full">
                    <h1 className="text-lg opacity-70">Your time</h1>
                    <h1 className="text-[32px] font-semibold text-primary">{timeTaken}s</h1>
                  </Space>
                  {/* <img src={timeGif} alt="gif" className="w-[100px]" /> */}
                </Flex>
              </Card>
            </Col>
          </Row>
          <Space direction="vertical" size={24} className="w-full mt-8">
            <Button type="primary" className="w-full py-5 !bg-[#6d387d] !hover:bg-[red] float-end">
              PLAY AGAIN
            </Button>
            <Button type="default" className="w-full py-5">
              TRY ANOTHER QUIZ
            </Button>
          </Space>
        </Card>
        <Card className="bg-[#2a0830] border-none">
          <h1 className="text-lg font-semibold text-white mb-4">Your results</h1>
          <Space direction="vertical" className="w-full" size={20}>
            {questionResults?.map((questionResults) => (
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
        </Card>
      </Space>
    </Flex>
  );
};

export default MyQuizResult;
