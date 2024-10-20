import { Button, Flex } from 'antd';
import successImage from '~/assets/images/account-verification-success.jpg';
import failImage from '~/assets/images/account-verification-fail.webp';

export const AccountVerificationSuccess = ({ name }) => {
  return (
    <Flex vertical gap={10} align="center">
      <img src={successImage} alt="success" className="w-[240px] h-auto mx-auto" />
      <p className="text-[16px]">
        Xin chào <span className="text-primary">{name}</span> !
      </p>
      <h1 className="text-center mb-2">
        Chúc mừng bạn đã đăng xác nhận tài khoản thành công, giờ bạn đã có thể đăng nhập tài khoản của mình.
      </h1>
      <Button type="primary" href="/auth/login" className="w-full">
        Back to login
      </Button>
    </Flex>
  );
};

export const AccountVerificationFail = () => {
  return (
    <Flex vertical gap={10} align="center">
      <img src={failImage} alt="success" className="w-[240px] h-auto mx-auto" />
      <h1 className="text-center mb-2">Có vẻ như xác nhận tài khoản của bạn không thành công, vui lòng thử lại sau.</h1>
      <Button type="primary" href="/auth/register" className="w-full">
        Back to register
      </Button>
    </Flex>
  );
};
