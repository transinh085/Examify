import { Footer as FooterAnt } from 'antd/es/layout/layout';
const Footer = () => {
  return (
    <FooterAnt className='text-center'>
        Ant Design ©{new Date().getFullYear()} Created by <span className='font-bold'>Examify</span>
    </FooterAnt>
  );
};

export default Footer;
