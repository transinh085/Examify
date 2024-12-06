import { Button, Flex, Input, Layout, message } from 'antd';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useUserJoin } from '~/features/customer/join/api/user-join';

const { Content } = Layout;

const JoinPage = () => {
  const navigate = useNavigate();
  const [code, setCode] = useState('');

  const mutaUserJoin = useUserJoin({ mutationConfig: {
    onSuccess: (data) => {
      navigate(`/join/wait/${data.code}`);
    },
    onError: (error) => {
      console.log(error);
      message.error('Code is invalid');
    },
  } });

 const handleUserJoin = () => {
  mutaUserJoin.mutate({ code });
 }

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
        <Input value={code} onChange={(e) => setCode(e.target.value)} className="max-w-2xl" placeholder="Enter your code" suffix={<Button onClick={handleUserJoin} type="primary">Join</Button>} />
      </Content>
    </Layout>
  );
};

export default JoinPage;
