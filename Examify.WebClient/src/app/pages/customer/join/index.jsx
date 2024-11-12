import { Button, Input, Layout } from 'antd';
import { Link } from 'react-router-dom';

const { Content } = Layout;

const JoinPage = () => {

  return (
    <Layout className="relative bg-black min-h-screen overflow-hidden">
      <Content
        className="relative flex justify-center items-center z-10"
        style={{
          backgroundImage: `url(https://cf.quizizz.com/themes/v2/classic/lobby_550.svg)`,
          backgroundSize: 'cover',
          backgroundPosition: 'center',
        }}
      >
        <Input
          className="max-w-2xl"
          placeholder="Enter your code"
          suffix={
            <Link to="/join/game/1">
              <Button type="primary">Join</Button>
            </Link>
          }
        />
      </Content>
    </Layout>
  );
};

export default JoinPage;
