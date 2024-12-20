/* eslint-disable react-hooks/exhaustive-deps */
import { Avatar, Button, Col, Flex, Layout, QRCode, Row, Space } from 'antd';
import {
  ClockCircleOutlined,
  PlaySquareOutlined,
  UsergroupAddOutlined,
} from '@ant-design/icons';
import CopyButton from '~/components/share/Button/CopyButton';
import backgroundURL from '~/assets/svg/lobby_550.svg';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import { useEffect } from 'react';
import { useSignalRStore } from '~/stores/signalR-store';
import { useGetJoinQuiz } from '~/features/admin/activity/classic/api/get-user-join';
import HeaderManagerQuiz from '~/features/admin/activity/classic/components/HeaderManagerQuiz';
import { useStartQuiz } from '~/features/admin/activity/classic/api/start-quiz';
import { useQueryClient } from '@tanstack/react-query';
import { VITE_ENDPOINT } from '~/config/env';

const {  Content } = Layout;

const ManagerQuizWait = () => {
  const { quiz, addUserJoin, setUserJoin, userJoin } = useManagerQuizStore();
  const queryClient = useQueryClient();

  const { initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage, checkConnection } = useSignalRStore();

  const {
    data: userJoins
  } = useGetJoinQuiz({ code: quiz?.code});

  const muteStartQuiz = useStartQuiz({
    mutationConfig: {
      onSuccess: () => {
        queryClient.invalidateQueries(['quiz', { id: quiz?.id }]);
      }
    }
  })

  const handleStartQuiz = () => {
    muteStartQuiz.mutate({ id: quiz?.id });
  };

  useEffect(() => {
    if(userJoins){
      setUserJoin(userJoins?.items || []);
    }
  }, [userJoins]);

  useEffect(() => {
    initializeSignalR('https://localhost:8386/notification-service/api/notification-hub');

    addSignalRHandler('JoinQuiz', (user) => {
      console.log('JoinQuiz', user);
      addUserJoin(user);
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
  }, [initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage, checkConnection, quiz]);

  return (
    <Layout className="min-h-screen bg-cover bg-center relative" style={{ backgroundImage: `url(${backgroundURL})` }}>
      <HeaderManagerQuiz/>
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
                <CopyButton text={`http://localhost:3000/join?code=${quiz?.code}`} />
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
                    {quiz?.code?.split('').map((item, index) => (
                      <span key={index} className="text-6xl font-bold">
                        {item}
                      </span>
                    ))}
                  </div>
                </Space>
                <CopyButton text={quiz?.code} />
              </Space>
            </Flex>
            <Flex gap={2} className="p-4 bg-ds-light-500-20" style={{ borderRadius: '0 0 24px 24px' }} vertical>
              <Flex className="bg-white" vertical gap={4}>
                <QRCode errorLevel="H" value={`${VITE_ENDPOINT}/join?code=${quiz?.code}`} size={130} />
              </Flex>
            </Flex>
          </Flex>
        </Flex>
        <Flex justify="center" align="center" className="mb-6">
          <Row
            className="p-4 bg-ds-dark-500 max-w-2xl w-full border-t border-white/30"
            style={{ borderRadius: '0 0 24px 24px' }}
            gutter={12}
          >
            <Col span={12} className="bg-ds-light-500-20 px-10 py-3 rounded-md">
              <Flex className="text-white text-xl px-2" justify="space-between" align="center" gap={4}>
                <Space size={'middle'}>
                  <ClockCircleOutlined />
                  <span className="text-lg font-bold">Auto start your quiz</span>
                </Space>
                <PlaySquareOutlined />
              </Flex>
            </Col>
            <Col span={12}>
              <Button
                loading={muteStartQuiz?.isPending}
                onClick={handleStartQuiz}
                type="primary"
                className="w-full h-full shadow-xl text-2xl uppercase font-bold"
              >
                Start
              </Button>
            </Col>
          </Row>
        </Flex>
        <Flex justify="center" align="center" className="mb-3">
          <div className="max-w-lg bg-ds-dark-500 flex justify-center items-center text-white text-3xl py-2 px-6 rounded-full">
            <Space size={'middle'}>
              <UsergroupAddOutlined />
              <span>Waiting for participants...</span>
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
                <span className="text-white text-lg pr-2">{user.name}</span>
              </Space>
            ))}
        </Flex>
      </Content>
    </Layout>
  );
};

export default ManagerQuizWait;
