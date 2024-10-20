import { Avatar, Flex } from 'antd';
import logo from '~/assets/quiz-logo.png';

const Header = () => {
  return (
    <Flex justify="space-between" align="center" className="min-h-[60px] border-b border-[#ccc] px-4">
      <div>
        <img src={logo} alt="logo" className="h-[40px] w-auto" />
      </div>

      <div>
        <Avatar>P</Avatar>
      </div>
    </Flex>
  );
};
export default Header;
