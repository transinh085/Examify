import { Avatar, Button, Card, Col, Flex, Row, Space } from 'antd';
import { Link } from 'react-router-dom';
import CorrectIcon from '~/components/icons/CorrectIcon';
import IncorrectIcon from '~/components/icons/IncorrectIcon';
import useDoQuizStore from '~/stores/do-quiz-store';

import pointGif from '~/assets/gif/a.gif';
import timeGif from '~/assets/gif/d.gif';
import useAuthStore from '~/stores/auth-store';

const OPTION_LETTERS = ['A', 'B', 'C', 'D'];

const MyQuizResult = () => {
  const { user } = useAuthStore();
  const { totalPoints, timeTaken, questionResults } = useDoQuizStore();
  return (
    <Flex justify="space-between" className="py-8 h-full">
      <Space direction="vertical" size={24} className="w-[640px] mx-auto h-full overflow-y-auto px-4 custom-scrollbar">
        <Link to={'/'}>
          <Button type="primary" shape="default" className="!bg-[#6d387d] !hover:bg-[red] float-end" onClick={null}>
            Back to home
          </Button>
        </Link>
        <Card className="bg-[#2a0830] border-none">
          <Space direction="vertical" size={24} className="w-full text-white">
            <Space className="w-full">
              <Avatar size="large" src={user?.image} />
              <Space direction="vertical" align="start" size={0}>
                <h1 className="font-semibold">
                  {user?.firstName} {user?.lastName}
                </h1>
                <p className="opacity-80 text-xs">{user?.email}</p>
              </Space>
            </Space>
          </Space>
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
                  <img src={pointGif} alt="gif" className="w-[100px]" />
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
                  <img src={timeGif} alt="gif" className="w-[100px]" />
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
          <Space direction="vertical" size={20} className="w-full">
            {questionResults?.map((questionResult, index) => (
              <Card key={index}>
                <Space direction="vertical" className="bg-white w-full">
                  <Space direction="horizontal" size={4}>
                    <h1 key={index} className="font-semibold">
                      Question: {questionResult?.order + 1}: {questionResult?.question?.content}
                    </h1>
                    {questionResult?.isCorrect ? <CorrectIcon /> : <IncorrectIcon />}
                  </Space>
                  {questionResult?.answerResults?.map((answerResult, index) => (
                    <div
                      key={index}
                      className={`${
                        answerResult?.isSelected &&
                        (questionResult?.isCorrect ? 'bg-green-400 text-white' : 'bg-red-500 text-white')
                      } p-2 rounded-md`}
                    >
                      <h1 className="">
                        {OPTION_LETTERS?.[index]}. {answerResult?.option?.content}
                      </h1>
                    </div>
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
