import { Avatar, Button, Checkbox, Flex, Layout, Progress, Radio, Space } from 'antd';
import {
  CloseCircleFilled,
  CloseCircleOutlined,
  FireOutlined,
  SoundFilled,
  UsergroupAddOutlined,
} from '@ant-design/icons';
import FullScreenButton from '~/features/admin/activity/classic/components/FullScreenButton';
import CopyButton from '~/components/share/Button/CopyButton';
import backgroundURL2 from '~/assets/images/bg_image.jpg';
import videoRocket from '~/assets/mp4/rocket-powerup.mp4';
import AccuracyProgressBar from '~/features/admin/activity/classic/components/AccuracyProgressBar';
import { users } from '~/features/admin/activity/classic/data';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';

const { Header, Content } = Layout;

const ManagerQuizStart = () => {

  const { tab, setTab, isPlayingSound, toggleSound } = useManagerQuizStore();

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
                <Flex gap={10} className="mb-6 text-base font-medium text-white">
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
                <Flex justify="space-between" gap={10} className="mb-6 text-base font-medium text-white">
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
};

export default ManagerQuizStart;