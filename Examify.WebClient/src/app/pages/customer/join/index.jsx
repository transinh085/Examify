import { Button, Flex, Input, Layout } from 'antd';

const { Content } = Layout;

const JoinPage = () => {
  return (
    <Layout className="relative bg-black min-h-screen overflow-hidden">
      <Content
        className="relative flex flex-col justify-center items-center z-10"
        style={{
          backgroundImage: `url(https://cf.quizizz.com/themes/v2/classic/lobby_550.svg)`,
          backgroundSize: 'cover',
          backgroundPosition: 'center',
        }}
      >
        <Flex justify="center" align="center">
          <h1 className="text-3xl font-bold text-white mb-6">Examify</h1>
        </Flex>
        <Input className="max-w-2xl" placeholder="Enter your code" suffix={<Button type="primary">Join</Button>} />
      </Content>
    </Layout>
  );
};

export default JoinPage;
