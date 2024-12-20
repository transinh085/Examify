/* eslint-disable react-hooks/exhaustive-deps */
import { Avatar, Button, Flex, Layout, QRCode, Space } from 'antd';
import {
  FireOutlined,
  SoundFilled,
  UsergroupAddOutlined,
} from '@ant-design/icons';
import FullScreenButton from '~/features/admin/activity/classic/components/FullScreenButton';
import CopyButton from '~/components/share/Button/CopyButton';
import backgroundURL from '~/assets/svg/lobby_550.svg';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import { useEffect } from 'react';
import { useSignalRStore } from '~/stores/signalR-store';
import { useGetJoinQuiz } from '~/features/admin/activity/classic/api/get-user-join';
import { useNavigate, useParams } from 'react-router-dom';
import { useCreateQuizResultMutation } from '~/features/do-quiz/api/create-quiz-result';

const { Header, Content } = Layout;

const JoinWait = () => {
  const { code } = useParams();

  const navigate = useNavigate();

  const { addUserJoin, setUserJoin, userJoin, isPlayingSound, toggleSound } = useManagerQuizStore();

  const { initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage, checkConnection } = useSignalRStore();

  const {
    data: userJoins
  } = useGetJoinQuiz({ code });

  useEffect(() => {
    if(userJoins){
      setUserJoin(userJoins?.items || []);
    }
  }, [userJoins]);

  const createQuizResultMutation = useCreateQuizResultMutation({
    mutationConfig: {
      onSuccess: (data) => {
        navigate(`/join/game/${data.quizResultId}`);
      },
    },
  });

  const handleStartQuiz = () => {
    console.log({ code });
    createQuizResultMutation.mutate({ code });
  };

  useEffect(() => {
    initializeSignalR('https://localhost:8386/notification-service/api/notification-hub');

    addSignalRHandler('JoinQuiz', (user) => {
      addUserJoin(user);
    });

    addSignalRHandler('StartQuiz', handleStartQuiz);
  
    const interval = setInterval(() => {
      if (checkConnection() && userJoins) {
        sendSignalRMessage('JoinQuizUser', userJoins?.quizId);
        clearInterval(interval); 
      }
    }, 1000);
  
    return () => {
      removeSignalRHandler('JoinQuiz');
      clearInterval(interval);
    };
  }, [initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage, checkConnection, userJoins, addUserJoin]);

  return (
    <Layout className="min-h-screen bg-cover bg-center relative" style={{ backgroundImage: `url(${backgroundURL})` }}>
      <Header className="sticky top-0 z-10 bg-ds-dark-500 bg-opacity-50 px-4 border-b border-white/30">
        <Flex className="items-center h-full max-w-8xl mx-auto" justify="space-between">
          <h4 className="text-white font-bold text-3xl">Examify</h4>
          <Space size="small">
            <Button type="primary" icon={<FireOutlined />} className="bg-ds-light-500-20" />
            <Button
              type="primary"
              icon={isPlayingSound ? <SoundFilled className="text-white" /> : <SoundFilled className="text-white" />}
              className="bg-ds-light-500-20"
              onClick={toggleSound}
            />
            <FullScreenButton />
          </Space>
        </Flex>
      </Header>
      <Content className="relative">
        <Flex justify="center" align="center">
          <Flex
            justify="center"
            className="p-4 bg-ds-dark-500 bg-opacity-50 z-10 justify-center items-center"
            gap={10}
            style={{ borderRadius: '0 0 24px 24px' }}
          >
            <Flex
              gap={2}
              vertical
              className="px-6 py-2 max-w-2xl bg-ds-light-500-20"
              style={{ borderRadius: '0 0 24px 24px' }}
            >
              <Space size="small" className="text-white justify-center items-center px-10 py-2">
                <div
                  className="w-[50px] h-[50px] rounded-full flex justify-center items-center"
                  style={{ backgroundColor: '#ffffff0d' }}
                >
                  1
                </div>
                <div className="text-base w-[98px] font-medium break-words">Join using any device</div>
                <Space size="middle" className="w-[400px]">
                  <div className="flex justify-center items-center space-x-2 underline cursor-pointer">
                    <span className="text-4xl font-bold">join</span>
                    <span className="text-4xl font-bold">my</span>
                    <span className="text-4xl font-bold">examify.com</span>
                  </div>
                </Space>
                <CopyButton text={`http://localhost:3000/join?code=${code}`} />
              </Space>
              <div className="h-[0.5px] my-2 bg-white w-full" />
              <Space size="small" className="text-white justify-center items-center">
                <div
                  className="w-[50px] h-[50px] rounded-full flex justify-center items-center"
                  style={{ backgroundColor: '#ffffff0d' }}
                >
                  2
                </div>
                <div className="text-base w-[98px] font-medium break-words">Enter the join code</div>
                <Space size="middle" className="w-[400px] justify-between">
                  <div className="flex justify-center items-center space-x-4">
                    {code && code.split('').map((item, index) => (
                      <span key={index} className="text-6xl font-bold">
                        {item}
                      </span>
                    ))}
                  </div>
                </Space>
                <CopyButton text={code} />
              </Space>
            </Flex>
            <Flex gap={2} className="p-4 bg-ds-light-500-20" style={{ borderRadius: '0 0 24px 24px' }} vertical>
              <Flex className="bg-white" vertical gap={4}>
                <QRCode errorLevel="H" value={`http://localhost:3000/join?code=${code}`} size={130} />
              </Flex>
            </Flex>
          </Flex>
        </Flex>
        <Flex justify="center" align="center" className="mb-9 mt-6">
          <div className="max-w-lg bg-ds-dark-500 flex justify-center items-center text-white text-3xl py-2 px-6 rounded-full">
            <Space size={'middle'}>
              <UsergroupAddOutlined />
              <span>Waiting Admin Start...</span>
            </Space>
          </div>
        </Flex>
        <Flex justify="center" align="center" gap={6}>
          {userJoin.length > 0 &&
            userJoin.map((user, index) => (
              <Space
                key={index}
                className="bg-ds-dark-500 p-2 rounded-full justify-center items-center bg-opacity-50"
                gap={3}
              >
                <Avatar src={user.avatar} alt={user.name} size={30} />
                <span className="text-white text-lg">{user.name}</span>
              </Space>
            ))}
        </Flex>
      </Content>
    </Layout>
  );
};

export default JoinWait;
