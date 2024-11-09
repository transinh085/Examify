import { Button, Flex, Input, Layout, Space } from 'antd';
import { Link, useNavigate } from 'react-router-dom';
import logo from '~/assets/examify-logo.png';

const { Header, Footer, Content } = Layout;

const JoinPage = () => {
  const navigate = useNavigate();

  return (
    <Layout className="relative bg-black min-h-screen overflow-hidden">
      <Header className="sticky top-0 bg-white shadow-md z-10">
        <Flex className="items-center" justify="space-between">
          <img src={logo} alt="logo" className="w-[100px]" />
          <Space size="middle">
            <Button
              onClick={() => navigate('/')}
              type="primary"
              className="cursor-pointer font-bold text-white px-4 py-2 hover:scale-110"
            >
              My dashboard
            </Button>
          </Space>
        </Flex>
      </Header>
      <div className="absolute inset-0 bg-lightning-pattern opacity-60"></div>
      <Content className="relative flex justify-center items-center z-10">
        <div className="w-[500px] bg-white p-8 rounded-lg shadow-lg transform transition duration-300 hover:scale-105">
          <Input
            className="max-w-2xl"
            placeholder="Enter your code"
            suffix={
              <Link to="/join/game/1">
                <Button type="primary">Join</Button>
              </Link>
            }
          />
        </div>
      </Content>
      <Footer className="flex justify-center bg-black text-white z-10">
        Ant Design ©{new Date().getFullYear()} Created by hgbaodev
      </Footer>
    </Layout>
  );
};

export default JoinPage;
