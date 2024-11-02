import { Flex } from 'antd';
import { Outlet, useNavigate } from 'react-router-dom';
import logo from '~/assets/examify-logo.png';

export default function AuthLayout() {
  const navigate = useNavigate();

  const moveToHome = () => {
    navigate('/');
  }

  return (
    <Flex vertical align="center" justify="center" className="w-[100vw] h-[100vh] relative">
      <AuthBackground />
      <img src={logo} alt="logo" className="w-[160px] h-auto mb-4 cursor-pointer" onClick={moveToHome} />
      <Outlet />
    </Flex>
  );
}

const AuthBackground = () => {
  return (
    <div className="absolute inset-0 z-[-1] blur-[70px] overflow-hidden">
      <div className="absolute top-0 right-0 w-[300px] h-[300px] bg-yellow-100 rounded-full opacity-100" />
      <div className="absolute bottom-[180px] w-[250px] h-[250px] bg-green-100 rounded-full ml-20 opacity-100" />
      <div className="absolute bottom-0 left-[-50px] w-[200px] h-[200px] bg-red-200 rounded-full opacity-100" />
    </div>
  );
};
