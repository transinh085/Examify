import { Avatar, Card, Col, Drawer, Flex, Row, Space, Switch } from 'antd';
import useDoQuizStore from '~/stores/do-quiz-store';
import SoundIcon from '~/components/icons/SoundIcon';
import KeyboardIcon from '~/components/icons/KeyboardIcon';
import MagicIcon from '~/components/icons/MagicIcon';

const SettingDrawer = ({ open, setOpen }) => {
  const { isPlayMusic, setIsPlayMusic } = useDoQuizStore();

  return (
    <Drawer
      placement={'top'}
      closable={false}
      onClose={() => {
        setOpen(false);
      }}
      open={open}
      styles={{
        wrapper: {
          backgroundColor: 'rgba(0, 0, 0, 0.4)',
        },
        content: {
          backgroundColor: 'transparent',
        },
      }}
      height={window.innerHeight - 200}
      closeIcon={<>123</>}
    >
      <div className="max-w-[540px] mx-auto">
        <Space direction="vertical" size={20} className="w-full">
          <Card className="bg-[#2a0830] border-none">
            <Space>
              <Avatar size="large" src="https://avatars.githubusercontent.com/u/93178609?v=4" />
              <Space direction="vertical" size={0}>
                <h1 className="font-semibold text-white">Phat Le</h1>
                <p className="opacity-80 text-white">lequanphat@gmail.com</p>
              </Space>
            </Space>
          </Card>
          <Space direction="vertical" className="w-full">
            <h1 className="text-white text-base font-semibold">Settings</h1>
            <Card className="bg-[#2a0830] border-none">
              <Space direction="vertical" className="w-full" size={24}>
                <Flex align="center" justify="space-between">
                  <Space size={4}>
                    <SoundIcon /> <h2 className="font-semibold text-white">Sound effects</h2>
                  </Space>
                  <Switch
                    checked={isPlayMusic}
                    onChange={() => {
                      setIsPlayMusic(!isPlayMusic);
                    }}
                  />
                </Flex>
                <Flex align="center" justify="space-between">
                  <Space size={4}>
                    <KeyboardIcon /> <h2 className="font-semibold text-white">Use keyboard to choose</h2>
                  </Space>
                  <Switch checked={true} onChange={null} />
                </Flex>
                <Flex align="center" justify="space-between">
                  <Space size={4}>
                    <MagicIcon /> <h2 className="font-semibold text-white">Auto select option when question due</h2>
                  </Space>
                  <Switch checked={true} onChange={null} />
                </Flex>
              </Space>
            </Card>
          </Space>
          <Space direction="vertical" className="w-full">
            <h1 className="text-white text-base font-semibold">Themes</h1>
            <Card className="bg-[#2a0830] border-none">
              <Row gutter={[24, 24]}>
                <Col span={6}>
                  <Card styles={{ body: { padding: 8 } }}>
                    <img src="https://cf.quizizz.com/themes/classic/classic_icon.png" alt="" />
                  </Card>
                </Col>
                <Col span={6}>
                  <Card styles={{ body: { padding: 8 } }}>
                    <img src="https://cf.quizizz.com/themes/cosmicPicnic/cosmicAvatar.png" alt="" />
                  </Card>
                </Col>
                <Col span={6}>
                  <Card styles={{ body: { padding: 8 } }}>
                    <img src="https://cf.quizizz.com/themes/classic/classic_icon.png" alt="" />
                  </Card>
                </Col>
                <Col span={6}>
                  <Card styles={{ body: { padding: 8 } }}>
                    <img src="https://cf.quizizz.com/themes/cosmicPicnic/cosmicAvatar.png" alt="" />
                  </Card>
                </Col>
              </Row>
            </Card>
          </Space>
        </Space>
      </div>
    </Drawer>
  );
};

export default SettingDrawer;
