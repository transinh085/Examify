import { Flex } from 'antd';
import { Footer as FooterAnt } from 'antd/es/layout/layout';
const Footer = () => {
  return (
    <FooterAnt className="w-full p-0 m-0 border-t border-[#ccc] bg-white">
      <Flex align="center" justify="center" className="min-h-[80px]">
        <h1>This is footer</h1>
      </Flex>
    </FooterAnt>
  );
};

export default Footer;
