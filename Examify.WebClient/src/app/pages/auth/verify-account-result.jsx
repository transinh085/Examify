import { LoadingOutlined } from '@ant-design/icons';
import { Spin } from 'antd';
import { Navigate, useParams } from 'react-router-dom';
import { useVerifyAccount } from '~/features/auth/api/others';
import { AccountVerificationFail, AccountVerificationSuccess } from '~/features/auth/components/account-verification';

const AccountVerificationResult = () => {
  const { token } = useParams();

  const { data, isPending, isSuccess } = useVerifyAccount(token, {
    retry: false,
    enabled: !!token,
  });

  if (!token) {
    return <Navigate to="/404" replace />;
  }

  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px]"
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      {isPending ? (
        <Spin indicator={<LoadingOutlined spin />} size="small" />
      ) : isSuccess ? (
        <AccountVerificationSuccess name={data?.name || 'Anonymous'} />
      ) : (
        <AccountVerificationFail />
      )}
    </div>
  );
};

export default AccountVerificationResult;
