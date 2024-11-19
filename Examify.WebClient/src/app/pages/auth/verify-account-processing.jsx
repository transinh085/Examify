import { Spin } from 'antd';
import { useEffect, useRef } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useVerifyTokenMutation } from '~/features/auth/api/others';
import { LoadingOutlined } from '@ant-design/icons';

const AccountVerificationProcessing = () => {
  const navigate = useNavigate();
  const { token } = useParams();
  const isCalled = useRef(false);

  const mutation = useVerifyTokenMutation({
    mutationConfig: {
      onSuccess: (data) => {
        navigate(`/auth/verify-account/success?email=${data?.email}`);
      },
      onError: (error) => {
        console.log('error', error);
        navigate('/auth/verify-account/failed');
      },
    },
  });

  useEffect(() => {
    if (!isCalled.current && token) {
      isCalled.current = true;
      mutation.mutate({ data: { token } });
    }
  }, [token, mutation]);

  return (
    <div
      className="p-8 rounded-[8px] w-[90%] md:w-[460px]"
      style={{
        boxShadow: 'rgba(0, 0, 0, 0.15) 0px 2px 8px',
      }}
    >
      <Spin indicator={<LoadingOutlined spin />} size="small" />
    </div>
  );
};

export default AccountVerificationProcessing;
