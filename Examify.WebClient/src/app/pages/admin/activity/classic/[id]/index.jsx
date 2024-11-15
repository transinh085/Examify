import { useRef, useState } from 'react';
import { Avatar, Button, Checkbox, Col, Flex, Layout, Progress, QRCode, Radio, Row, Space } from 'antd';
import {
  ClockCircleOutlined,
  CloseCircleFilled,
  CloseCircleOutlined,
  FireOutlined,
  PlaySquareOutlined,
  SoundFilled,
  UsergroupAddOutlined,
} from '@ant-design/icons';
import FullScreenButton from '~/features/admin/activity/classic/components/FullScreenButton';
import soundPlay from '~/assets/mp3/mastery_party.mp3';
import CopyButton from '~/components/share/Button/CopyButton';
import backgroundURL from '~/assets/svg/lobby_550.svg';
import backgroundURL2 from '~/assets/images/bg_image.jpg';
import videoRocket from '~/assets/mp4/rocket-powerup.mp4';
import AccuracyProgressBar from '~/features/admin/activity/classic/components/AccuracyProgressBar';

const { Header, Content } = Layout;

const users = [
  {
    id: '1',
    name: 'lala',
    image: 'https://avatars.githubusercontent.com/u/120194990?v=4',
    score: 0,
    number_anwsered_correct: 0,
    number_anwsered_wrong: 0,
  },
  {
    id: '2',
    name: 'mono',
    image: 'https://avatars.githubusercontent.com/u/120194990?v=4',
    score: 3,
    number_anwsered_correct: 0,
    number_anwsered_wrong: 0,
  },
  {
    id: '3',
    name: 'hgbaodev',
    image: 'https://avatars.githubusercontent.com/u/120194990?v=4',
    score: 2,
    number_anwsered_correct: 0,
    number_anwsered_wrong: 0,
  },
];

// const questions = [
//   {
//     id: '1',
//     question: 'What is the capital of Vietnam?',
//     type: 'single_choice',
//     number_answer_correct: 1,
//     number_anwser_wrong: 3,
//     answers: [
//       { id: '1', answer: 'Hanoi', is_correct: true },
//       { id: '2', answer: 'Ho Chi Minh City', is_correct: false },
//       { id: '3', answer: 'Da Nang', is_correct: false },
//       { id: '4', answer: 'Hue', is_correct: false },
//     ],
//   },
//   {
//     id: '2',
//     question: 'What is the capital of Vietnam?',
//     type: 'mutiple_choice',
//     number_answer_correct: 1,
//     number_anwser_wrong: 3,
//     answers: [
//       { id: '1', answer: 'Hanoi', is_correct: true },
//       { id: '2', answer: 'Ho Chi Minh City', is_correct: false },
//       { id: '3', answer: 'Da Nang', is_correct: false },
//       { id: '4', answer: 'Hue', is_correct: false },
//     ],
//   }
// ]

const ManagerQuizPage = () => {
  const audioRef = useRef(new Audio(soundPlay));
  const [isPlayingSound, setIsPlayingSound] = useState(true);
  const [isStart, setIsStart] = useState(false);
  const [tab, setTab] = useState(1);

  audioRef.current.loop = true;

  const toggleSound = () => {
    isPlayingSound ? audioRef.current.pause() : audioRef.current.play();
    setIsPlayingSound(!isPlayingSound);
  };

  if (isStart) {
    return (
      <Layout
        className="full-base-screen bg-ds-dark-500 fixed top-0 left-0 overflow-scroll h-screen w-screen"
        style={{ backgroundImage: `url(${backgroundURL2})` }}
      >
        <Header className="sticky top-0 z-10 bg-ds-dark-500 bg-opacity-50 px-4 border-b border-white/30 mb-6">
          <Flex className="items-center h-full max-w-8xl mx-auto" justify="space-between">
            <h4 className="text-white font-bold text-3xl">Examify</h4>
            <Space size="small">
              <Button type="primary" icon={<FireOutlined />} className="bg-ds-light-500-20" />
              <Button
                type="primary"
                icon={
                  isPlayingSound ? <SoundFilled className="text-white" /> : <CloseCircleFilled className="text-white" />
                }
                className="bg-ds-light-500-20"
                onClick={toggleSound}
              />
              <FullScreenButton />
              <div className="w-[1px] bg-white h-6 mx-2" />
              <Button color="danger" variant="solid" className="text-lg rounded-sm">
                End
              </Button>
            </Space>
          </Flex>
        </Header>
        <Content>
          <Flex justify="center" className="mb-12" align="center">
            <Flex className="max-w-sm w-full rounded-lg text-white justify-between px-3 items-center bg-ds-dark-500-30 bg-opacity-50 border border-white/30 h-[80px]">
              <Space direction="vertical">
                <span className="text-xs font-medium">Join code</span>
                <span className="text-lg font-extrabold">469127</span>
              </Space>
              <CopyButton text="https://github.com/hgbaodev" />
            </Flex>
          </Flex>
          <AccuracyProgressBar number_correct={0} number_wrong={0} />
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
          <Flex justify="center" className='mb-6'>
            {tab === 1 && (
              <Flex className="p-4 bg-ds-dark-500-50 w-full max-w-5xl rounded-lg" vertical>
                <Flex gap={10} className="mb-6 text-lg font-medium text-white">
                  <UsergroupAddOutlined className="font-extrabold" />
                  <span>{users.length} paricipants</span>
                </Flex>
                <Flex vertical gap={8}>
                  <table className="text-white">
                    <thead className="text-lg">
                      <td className="py-4 px-6 text-left">Rank</td>
                      <td className="py-4 px-6 text-left">Name</td>
                      <td className="py-4 px-6 text-left">Score</td>
                      <td className="py-4 px-6 text-left">Process</td>
                      <td></td>
                    </thead>
                    <tbody className="text-base">
                      {users
                        .sort((a, b) => b.score - a.score)
                        .map((user, index) => {
                          return (
                            <tr
                              key={user.id}
                              className={`bg-ds-dark-500 ${index + 1 != users.length && 'border-b border-white/30'}`}
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
                              <td className="py-4 px-6">
                                <Progress percent={50} showInfo={false} />
                              </td>
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
                <Flex justify="space-between" gap={10} className="mb-6 text-lg font-medium text-white">
                  <Space>
                    <UsergroupAddOutlined />
                    <span>3 Questions</span>
                  </Space>
                  <Space>
                    <span>Sort by Accuracy</span>
                    <Checkbox />
                  </Space>
                </Flex>
                <Flex justify="center" className="mt-6 mb-6">
                  <Space>
                    <Button>1</Button>
                    <Button>2</Button>
                    <Button>3</Button>
                  </Space>
                </Flex>
                <Flex vertical gap={8} className='rounded-lg text-white'>
                  <Flex vertical className='p-4 bg-ds-dark-500-50 rounded-lg'>
                      <Flex justify='space-between' align='center' className='text-base py-2 border-b border-white/30 mb-3'>
                         <Space size={"small"} className='px-2 py-1 rounded-lg bg-ds-light-500-20'>
                            <Checkbox defaultChecked/>
                            <span>Mutiple Choice</span>
                         </Space>
                         <Space size={"small"} className='px-2 py-1 rounded-lg bg-ds-light-500-20' direction='vertical'>
                            <Progress percent={50} showInfo={false} />
                            <span>1 correct, 1 incorrect</span>
                         </Space>
                      </Flex>
                      <Flex justify='space-between' className='mb-3'>
                        <span>What is the capital of Vietnam?</span>
                        <Button>Edit</Button>
                      </Flex>
                      <Flex vertical gap={3}>
                        <Radio className='text-white' value={1}>A</Radio>
                        <Radio className='text-white' value={1}>A</Radio>
                        <Radio className='text-white' value={1}>A</Radio>
                        <Radio className='text-white' value={1}>A</Radio>
                      </Flex>
                  </Flex>
                </Flex>
              </Flex>
            )}
          </Flex>
        </Content>
        <div className="absolute bottom-4 right-3">
          <video
            className="rounded-full h-24 w-24"
            src={videoRocket}
            width="96"
            height="96"
            loop
            autoPlay
            muted
          ></video>
        </div>
      </Layout>
    );
  } else {
    return (
      <Layout className="min-h-screen bg-cover bg-center relative" style={{ backgroundImage: `url(${backgroundURL})` }}>
        <Header className="sticky top-0 z-10 bg-ds-dark-500 bg-opacity-50 px-4 border-b border-white/30">
          <Flex className="items-center h-full max-w-8xl mx-auto" justify="space-between">
            <h4 className="text-white font-bold text-3xl">Examify</h4>
            <Space size="small">
              <Button type="primary" icon={<FireOutlined />} className="bg-ds-light-500-20" />
              <Button
                type="primary"
                icon={
                  isPlayingSound ? <SoundFilled className="text-white" /> : <CloseCircleFilled className="text-white" />
                }
                className="bg-ds-light-500-20"
                onClick={toggleSound}
              />
              <FullScreenButton />
              <div className="w-[1px] bg-white h-6 mx-2" />
              <Button color="danger" variant="solid" className="text-lg rounded-sm">
                End
              </Button>
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
                    <div className="flex justify-center items-center space-x-2">
                      <span className="text-4xl font-bold">join</span>
                      <span className="text-4xl font-bold">my</span>
                      <span className="text-4xl font-bold">examify.com</span>
                    </div>
                  </Space>
                  <CopyButton text="https://github.com/hgbaodev" />
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
                      <span className="text-6xl font-bold">6</span>
                      <span className="text-6xl font-bold">6</span>
                      <span className="text-6xl font-bold">6</span>
                      <span className="text-6xl font-bold">6</span>
                      <span className="text-6xl font-bold">6</span>
                      <span className="text-6xl font-bold">6</span>
                    </div>
                  </Space>
                  <CopyButton text="https://github.com/hgbaodev" />
                </Space>
              </Flex>
              <Flex gap={2} className="p-4 bg-ds-light-500-20" style={{ borderRadius: '0 0 24px 24px' }} vertical>
                <Flex className="bg-white" vertical gap={4}>
                  <QRCode errorLevel="H" value="https://hgbaodev.id.vn/" size={130} />
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
                <Flex className="text-white text-xl" justify="space-between" align="center" gap={4}>
                  <Space size={'middle'}>
                    <ClockCircleOutlined />
                    <span className="text-lg font-bold">Auto start your quiz</span>
                  </Space>
                  <PlaySquareOutlined />
                </Flex>
              </Col>
              <Col span={12}>
                <Button
                  onClick={() => setIsStart(true)}
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
            {users.length > 0 &&
              users.map((user, index) => (
                <Space
                  key={index}
                  className="bg-ds-dark-500 p-2 rounded-full justify-center items-center bg-opacity-50"
                  gap={3}
                >
                  <Avatar src={user.image} alt={user.name} size={30} />
                  <span className="text-white text-lg">{user.name}</span>
                </Space>
              ))}
          </Flex>
        </Content>
      </Layout>
    );
  }
};

export default ManagerQuizPage;
