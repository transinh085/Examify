import { Avatar, Button, Card, Col, Flex, Row, Space } from 'antd';
import { Link } from 'react-router-dom';
import CorrectIcon from '~/components/icons/CorrectIcon';
import IncorrectIcon from '~/components/icons/IncorrectIcon';
import SoundIcon from '~/components/icons/SoundIcon';
import useDoQuizStore from '~/stores/do-quiz-store';

const OPTION_LETTERS = ['A', 'B', 'C', 'D'];

const MyQuizResult = () => {
  const { questionResults } = useDoQuizStore();
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
              <Avatar size="large" src="https://avatars.githubusercontent.com/u/93178609?v=4" />
              <Space direction="vertical" align="start" size={0}>
                <h1 className="font-semibold">Phat Le</h1>
                <p className="opacity-80 text-xs">lequanphat@gmail.com</p>
              </Space>
            </Space>
          </Space>
        </Card>
        <Card className="bg-[#2a0830] border-none">
          <Row gutter={[24, 24]}>
            <Col span={12}>
              <Card className="bg-black border-none">
                <Flex justify="space-between" className="w-full text-white">
                  <Space direction="vertical" className="w-full">
                    <h2>Your ranking</h2>
                    <h1 className="text-lg font-semibold">1/9</h1>
                  </Space>
                  <SoundIcon />
                </Flex>
              </Card>
            </Col>
            <Col span={12}>
              <Card className="bg-black border-none">
                <Flex justify="space-between" className="w-full text-white">
                  <Space direction="vertical" className="w-full">
                    <h2>Your score</h2>
                    <h1 className="text-lg font-semibold">1215</h1>
                  </Space>
                  <SoundIcon />
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
                    <h1 key={index} className='font-semibold'>
                      Question: {questionResult?.order + 1}: {questionResult?.question?.content}
                    </h1>
                    {questionResult?.isCorrect ? <CorrectIcon /> : <IncorrectIcon />}
                  </Space>
                  {questionResult?.answerResults?.map((answerResult, index) => (
                    <div
                      key={index}
                      className={`${
                        answerResult?.isSelected && (questionResult?.isCorrect ? 'bg-green-400 text-white' : 'bg-red-500 text-white')
                      } p-2 rounded-md`}
                    >
                      <h1 className=''>
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
