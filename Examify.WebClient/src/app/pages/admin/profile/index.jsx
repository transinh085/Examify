import { Avatar, Button, Card, Flex, Tabs, Upload, Space } from 'antd';
import { EditOutlined } from '@ant-design/icons';
import { useState } from 'react';
import useAuthStore from '~/stores/auth-store';
import { useNavigate } from 'react-router-dom';
import TabContent from '~/features/admin/mylibrary/components/TabContent';
import { useSearchParams } from 'react-router-dom';

const ProfilePage = () => {
  const { user, resetUser } = useAuthStore();
  const [imageUrl, setImageUrl] = useState(user.image);

  const navigate = useNavigate();

  const handleNavigate = () => {
    navigate('/admin/settings'); // Điều hướng tới trang /settings
  };
  const [params, setParams] = useSearchParams();
  const tabs = [
    { key: '1', label: 'Quiz', children: <TabContent params={params} setParams={setParams} isPublished /> },
    {
      key: '2',
      label: 'Collection',
      children: (
        <Flex justify="center">
          <img
            className="w-[200px] h-[200px]"
            src="https://img.freepik.com/free-vector/opening-soon-background-grunge-style_23-2147868024.jpg?semt=ais_hybrid"
            alt=""
          />
        </Flex>
      ),
    },
  ];

  return (
    <div>
      <Card className="grid max-w-screen-xl">
        <Flex className="relative" justify="space-between" align="flex-start">
          <Flex className="justify-between">
            <div className="relative inline-block">
              <Avatar
                size={{
                  xs: 24,
                  sm: 32,
                  md: 40,
                  lg: 64,
                  xl: 120,
                  xxl: 100,
                }}
                src={imageUrl}
                className="cursor-pointer"
              />
            </div>
            <Flex vertical className="ml-8 justify-between">
              <div>
                <Flex className="font-semibold text-neutral-800 items-center">
                  <p title="Bảo Nguyễn" className="truncate max-w-52 inline-block">
                    <span>
                      {user.firstName} {user.lastName}
                    </span>
                  </p>
                  <Flex className="inline-flex items-center text-xs font-semibold py-0.5 px-3 uppercase text-white bg-purple-500 ml-1 rounded-full">
                    <span>Học sinh</span>
                  </Flex>
                </Flex>
                <Flex align="center">
                  <span className="text-fuchsia-800 text-sm">{user.email}</span>
                </Flex>
              </div>
            </Flex>
          </Flex>
          <Flex align="end" className="h-[120px]">
            <Flex className="font-semibold">
              <Flex vertical className="items-center">
                <div className="text-black text-2xl">0</div>
                <div className="text-neutral-500 text-xs uppercase">QUIZ</div>
              </Flex>
              <Flex vertical className="items-center ml-8">
                <div className="text-black text-2xl">0</div>
                <div className="text-neutral-500 text-xs uppercase">BỘ SƯU TẬP</div>
              </Flex>
            </Flex>
          </Flex>
          <Flex gap="small" className="absolute top-4 right-4">
            <Space>
              <Button type="primary" onClick={handleNavigate} icon={<EditOutlined />}>
                Chỉnh sửa hồ sơ
              </Button>
            </Space>
          </Flex>
        </Flex>
      </Card>

      <Tabs
        defaultActiveKey={params.get('isPublished') == 'false' ? '2' : '1'}
        items={tabs}
        onChange={(key) => {
          params.set('isPublished', key == '1');
          params.set('pageNumber', 1);
          params.set('pageSize', 4);
          setParams(params);
        }}
      />
    </div>
  );
};

export default ProfilePage;
