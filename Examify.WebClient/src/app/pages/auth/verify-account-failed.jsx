import { Button, Flex } from 'antd';
import failImage from '~/assets/images/account-verification-fail.webp';

const AccountVerificationFailed = () => {
  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px] bg-white "
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      <Flex vertical gap={10} align="center">
        <img src={failImage} alt="success" className="w-[240px] h-auto mx-auto" />
        <h1 className="text-center mb-2">Something went wrong</h1>
        <Button type="primary" href="/auth/register" className="w-full">
          Back to register
        </Button>
      </Flex>
    </div>
  );
};

export default AccountVerificationFailed;
