import { Avatar, Button, Col, Flex, Layout, QRCode, Row, Space } from 'antd';
import {
  ClockCircleOutlined,
  CloseCircleFilled,
  FireOutlined,
  PlaySquareOutlined,
  SoundFilled,
  UsergroupAddOutlined,
} from '@ant-design/icons';
import FullScreenButton from '~/features/admin/activity/classic/components/FullScreenButton';
import CopyButton from '~/components/share/Button/CopyButton';
import backgroundURL from '~/assets/svg/lobby_550.svg';
import { users } from '~/features/admin/activity/classic/data';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';

const { Header, Content } = Layout;

const ManagerQuizWait = () => {
  const { isPlayingSound, toggleSound, setIsStart } = useManagerQuizStore();
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
};

export default ManagerQuizWait;