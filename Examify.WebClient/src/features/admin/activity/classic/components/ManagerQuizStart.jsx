import { Avatar, Button, Checkbox, Flex, Layout, Progress, Space } from 'antd';
import { CloseCircleOutlined, UsergroupAddOutlined } from '@ant-design/icons';
import CopyButton from '~/components/share/Button/CopyButton';
import backgroundURL2 from '~/assets/images/bg_image.jpg';
import videoRocket from '~/assets/mp4/rocket-powerup.mp4';
import AccuracyProgressBar from '~/features/admin/activity/classic/components/AccuracyProgressBar';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import HeaderManagerQuiz from '~/features/admin/activity/classic/components/HeaderManagerQuiz';
import { useGetStartQuiz } from '~/features/admin/activity/classic/api/get-start-quiz';
import { useEffect, useState } from 'react';
import { useSignalRStore } from '~/stores/signalR-store';
import { useQueryClient } from '@tanstack/react-query';

const { Content } = Layout;

const ManagerQuizStart = () => {
  const { tab, setTab, quiz } = useManagerQuizStore();
  const [ isCorrect, setIsCorrect ] = useState(0);
  const [ isWrong, setIsWrong ] = useState(0);
  const queryClient = useQueryClient();

  const { data: startQuiz } = useGetStartQuiz({ code: quiz?.code });
  const { initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage, checkConnection } = useSignalRStore();

  useEffect(() => {
    if(startQuiz){
      setIsCorrect(startQuiz?.questions.reduce((acc, question) => acc + question.correct, 0));
      setIsWrong(startQuiz?.questions.reduce((acc, question) => acc + question.incorrect, 0));
    }
  }, [startQuiz])

  useEffect(() => {
    initializeSignalR('https://localhost:8386/notification-service/api/notification-hub');

    addSignalRHandler('UpdateQuiz', () => {
      queryClient.invalidateQueries(['start-quiz', { code: quiz?.code }]);
    });
  
    const interval = setInterval(() => {
      if (checkConnection()) {
        sendSignalRMessage('JoinQuizAdmin', quiz?.id);
        clearInterval(interval); 
      }
    }, 1000);
  
    return () => {
      removeSignalRHandler('JoinQuiz');
      clearInterval(interval);
    };
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage, checkConnection, quiz]);


  return (
    <Layout
      className="full-base-screen bg-ds-dark-500 fixed top-0 left-0 overflow-scroll h-screen w-screen"
      style={{ backgroundImage: `url(${backgroundURL2})` }}
    >
      <HeaderManagerQuiz />
      <Content>
        <Flex justify="center" className="mb-12" align="center">
          <Flex className="max-w-sm w-full rounded-lg text-white justify-between px-3 items-center bg-ds-dark-500-30 bg-opacity-50 border border-white/30 h-[80px]">
            <Space direction="vertical">
              <span className="text-xs font-medium">Join code</span>
              <span className="text-lg font-extrabold">{quiz?.code}</span>
            </Space>
            <CopyButton text={quiz?.code} />
          </Flex>
        </Flex>
        <AccuracyProgressBar number_correct={isCorrect} number_wrong={isWrong} />
        <Flex justify="center" align="center">
          <Flex className="max-w-xs w-full bg-ds-dark-500 px-4 h-[50px]" style={{ borderRadius: '24px 24px 0 0' }}>
            <div
              onClick={() => setTab(1)}
              className={`text-white font-medium text-base flex justify-center items-center h-full w-[50%] cursor-pointer ${
                tab === 1 && 'border-b-2 border-white'
              }`}
            >
              Leaderboard
            </div>
            <div
              onClick={() => setTab(2)}
              className={`text-white font-medium text-base flex justify-center items-center h-full w-[50%] cursor-pointer ${
                tab === 2 && 'border-b-2 border-white'
              }`}
            >
              Questions
            </div>
          </Flex>
        </Flex>
        <Flex justify="center" className="mb-6">
          {tab === 1 && (
            <Flex className="p-4 bg-ds-dark-500-50 w-full max-w-5xl rounded-lg" vertical>
              <Flex gap={10} className="mb-6 text-base font-medium text-white">
                <UsergroupAddOutlined className="font-extrabold" />
                <span>{startQuiz?.users.length} paricipants</span>
              </Flex>
              <Flex vertical gap={8}>
                <table className="text-white">
                  <thead className="text-lg">
                    <td className="py-4 px-6 text-left">Rank</td>
                    <td className="py-4 px-6 text-left">Name</td>
                    <td className="py-4 px-6 text-left">Score</td>
                    <td></td>
                  </thead>
                  <tbody className="text-base">
                    {startQuiz?.users
                      .sort((a, b) => b.score - a.score)
                      .map((user, index) => {
                        return (
                          <tr
                            key={user.id}
                            className={`bg-ds-dark-500 ${index + 1 != startQuiz?.users.length && 'border-b border-white/30'}`}
                          >
                            <td className="py-4 px-6">
                              <span className="font-medium">{index + 1}</span>
                            </td>
                            <td className="py-4 px-6">
                              <Space size={'middle'}>
                                <Avatar src={user.image} size={30} />
                                <span className="font-medium">{user.name}</span>
                              </Space>
                            </td>
                            <td className="py-4 px-6">{user.score}</td>
                            <td>
                              <CloseCircleOutlined />
                            </td>
                          </tr>
                        );
                      })}
                  </tbody>
                </table>
              </Flex>
            </Flex>
          )}
          {tab === 2 && (
            <Flex className="p-4 bg-ds-dark-500-50 w-full max-w-5xl rounded-lg" vertical>
              <Flex justify="space-between" gap={10} className="mb-6 text-base font-medium text-white">
                <Space>
                  <UsergroupAddOutlined />
                  <span>{startQuiz?.questions.length} Questions</span>
                </Space>
                <Space>
                  <span>Sort by Accuracy</span>
                  <Checkbox />
                </Space>
              </Flex>
              <Flex vertical gap={8} className="rounded-lg text-white">
                {startQuiz?.questions.map((question) => (
                  <Flex vertical className="p-4 bg-ds-dark-500-50 rounded-lg mb-4" key={question.id}>
                    <Flex
                      justify="space-between"
                      align="center"
                      className="text-base py-2 border-b border-white/30 mb-3"
                    >
                      <Space size="small" className="px-2 py-1 rounded-lg bg-ds-light-500-20">
                        <Checkbox defaultChecked />
                        <span>{question.type}</span>
                      </Space>
                      <Space size="small" className="px-2 py-1 rounded-lg bg-ds-light-500-20" direction="vertical">
                        <Progress percent={question.progress} showInfo={false} />
                        <span>{`${question.correct} correct, ${question.incorrect} incorrect`}</span>
                      </Space>
                    </Flex>
                    <Flex justify="space-between" className="mb-3">
                      <span>{question.title}</span>
                      <Button>Edit</Button>
                    </Flex>
                    <Flex vertical gap={3}>
                      {question.options.map((option, idx) => (
                        <Checkbox key={idx} defaultChecked={option?.isCorrect} className="text-white">
                          {option.content}
                        </Checkbox>
                      ))}
                    </Flex>
                  </Flex>
                ))}
              </Flex>
            </Flex>
          )}
        </Flex>
        <div className="sticky bottom-4 right-4">
          <Flex justify='end' className='p-4'>
          <video
            className="rounded-full h-24 w-24"
            src={videoRocket}
            width="96"
            height="96"
            loop
            autoPlay
            muted
          ></video>
          </Flex>
        </div>
      </Content>
    </Layout>
  );
};

export default ManagerQuizStart;
