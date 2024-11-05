import { Footer as FooterAnt } from 'antd/es/layout/layout';

const FooterAdmin = () => {
  return <FooterAnt className="text-center">Copyright © {new Date().getFullYear()} Examify</FooterAnt>;
};

export default FooterAdmin;
