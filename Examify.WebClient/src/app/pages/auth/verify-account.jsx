import { Button, Flex } from 'antd';
import { useLocation } from 'react-router-dom';
import emailImage from '~/assets/images/email.png';

const AccountVerification = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const email = queryParams.get('email');
  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px]"
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      <Flex vertical gap={20}>
        <img src={emailImage} alt="email" className="w-[100px] h-auto mx-auto" />
        <h1 className="text-center text-[15px]">
          Chúng tôi đã gửi email xác nhận đến địa chỉ <p className="text-primary">{email}</p>
        </h1>
        <h1 className="text-center text-[15px]">Vui lòng kiểm tra email của bạn để xác nhận tài khoản</h1>
        <Button type="primary" href="https://mail.google.com/">
          Open Mail
        </Button>
      </Flex>
    </div>
  );
};

export default AccountVerification;
