import { Button, Flex } from 'antd';
import { useSearchParams } from 'react-router-dom';
import successImage from '~/assets/images/account-verification-success.jpg';

const AccountVerificationSuccess = () => {
  const [searchParams] = useSearchParams();
  const email = searchParams.get('email');
  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px] bg-white "
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      <Flex vertical gap={10} align="center">
        <img src={successImage} alt="success" className="w-[240px] h-auto mx-auto" />
        <p className="text-base">
          Hello <span className="text-primary">{email}!</span>
        </p>
        <h1 className="text-center mb-2">
          Your account has been successfully verified. You can now login to your account
        </h1>
        <Button type="primary" href="/auth/login" className="w-full">
          Back to login
        </Button>
      </Flex>
    </div>
  );
};

export default AccountVerificationSuccess;
