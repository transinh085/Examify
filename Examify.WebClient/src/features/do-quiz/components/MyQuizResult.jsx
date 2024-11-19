import { Avatar, Button, Card, Col, Flex, Row, Skeleton, Space } from 'antd';
import { Link } from 'react-router-dom';
import SoundIcon from '~/components/icons/SoundIcon';

const MyQuizResult = () => {
  return (
    <Flex justify="space-between" className="py-8">
      <Space direction="vertical" size={24} className="w-[540px] mx-auto">
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
          <Skeleton active />
        </Card>
      </Space>
    </Flex>
  );
};

export default MyQuizResult;
