import { Button, Flex, Layout, QRCode, Space } from 'antd';
import { useNavigate } from 'react-router-dom';
import { CopyOutlined } from '@ant-design/icons';
import bgContent from '~/assets/images/bg-hallowen.png';
import ghostImg3 from '~/assets/images/ghost3.png';
import ghostImg4 from '~/assets/images/ghost4.png';

const { Header, Footer, Content } = Layout;

const ManagerQuizPage = () => {
  const navigate = useNavigate();

  const StepCircle = ({ number }) => (
    <div className="flex items-center justify-center w-10 h-10 rounded-full bg-gray-200 text-gray-700 font-semibold">
      {number}
    </div>
  );

  return (
    <Layout className="relative min-h-screen overflow-hidden bg-black">
      <Header className="sticky top-0 z-10 bg-black shadow-lg border-b border-gray-800">
        <Flex className="items-center h-full max-w-7xl mx-auto px-4" justify="space-between">
          <h4 className="text-white font-bold text-xl tracking-wide">Examify</h4>
          <Space>
          <Button
            color='danger'
            variant='solid'
          >
            End
          </Button>
          <Button
            onClick={() => navigate('/')}
            type="primary"
          >
            My Dashboard
          </Button>
          </Space>
        </Flex>
      </Header>

      <Content
        className="relative"
        style={{
          backgroundImage: `url(${bgContent})`,
          backgroundSize: 'cover',
          backgroundPosition: 'center',
          minHeight: 'calc(100vh - 64px - 69px)',
        }}
      >
        <Flex justify="center">
          <Flex
            className="bg-black/90 backdrop-blur-sm rounded-xl shadow-2xl w-full max-w-4xl mx-4 p-6"
            gap={8}
            align="center"
          >
            <Flex className="flex-1 text-xl" vertical gap={4}>
              <Space className="w-full p-4 bg-white rounded-lg transition-all hover:shadow-md">
                <StepCircle number={1} />
                <span className="font-medium">Join using any device</span>
                <Button icon={<CopyOutlined />}></Button>
              </Space>

              <Space className="w-full p-4 bg-white rounded-lg transition-all hover:shadow-md">
                <StepCircle number={2} />
                <span className="font-medium">Enter the join code</span>
                <span className="font-mono font-bold text-lg">662833</span>
                <Button icon={<CopyOutlined />}></Button>
              </Space>
              <Button type='primary' size='large'>Start</Button>
            </Flex>

            <div className="p-4 bg-white rounded-lg shadow-md">
              <QRCode
                errorLevel="H"
                value="https://hgbaodev.id.vn/"
                size={200}
              />
            </div>
          </Flex>
        </Flex>
        <img
          src={ghostImg3}
          alt="Decorative ghost"
          className="absolute top-[20%] left-[10%] w-[120px] h-[180px] object-contain animate-bounce-up pointer-events-none
            lg:top-[30%] lg:left-[15%] lg:w-[140px] lg:h-[200px]"
        />
        <img
          src={ghostImg4}
          alt="Decorative ghost"
          className="absolute bottom-[20%] right-[10%] w-[120px] h-[180px] object-contain animate-bounce-down pointer-events-none
            lg:bottom-[30%] lg:right-[15%] lg:w-[140px] lg:h-[200px]"
        />
      </Content>

      <Footer className="flex justify-center items-center bg-black text-white/80 border-t border-gray-800">
        Ant Design ©{new Date().getFullYear()} Created by hgbaodev
      </Footer>
    </Layout>
  );
};

export default ManagerQuizPage;
