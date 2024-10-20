import { Flex } from 'antd';
import { Footer as FooterAnt } from 'antd/es/layout/layout';
const Footer = () => {
  return (
    <FooterAnt className="w-full bg-slate-400 p-0 m-0">
      <Flex align="center" justify="center" className="text-center min-h-[80px]">
        <h1>This is footer</h1>
      </Flex>
    </FooterAnt>
  );
};

export default Footer;
