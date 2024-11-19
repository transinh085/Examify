import { Avatar, Button, Card, Flex, Modal, Tabs, Tag, Upload, Space, Input, Form, Checkbox, Row, Col } from 'antd';
import { EditOutlined, BookOutlined, UploadOutlined } from '@ant-design/icons';
import React, { useEffect, useMemo, useState } from 'react';
import useAuthStore from '~/stores/auth-store';
import { useNavigate } from 'react-router-dom';

const ProfilePage = () => {
  const { user, resetUser } = useAuthStore();
  const [imageUrl, setImageUrl] = useState(user.image);
  useEffect(() => {
    if (imageUrl) {
      console.log('File URL:', imageUrl);
    }
  }, [imageUrl]);

  const handleUpload = (info) => {
    const file = info.file.originFileObj || info.file; // Sử dụng originFileObj hoặc fallback về file
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        setImageUrl(reader.result);
      };
      reader.readAsDataURL(file); // Đọc file
    } else {
      console.error("Không thể đọc file");
    }
  };
  const [open, setOpen] = useState(false);
  const showModal = () => {
    setOpen(true);
  };
  const handleOk = () => {
    form.submit();
  };
  const handleCancel = () => {
    setOpen(false);
    form.resetFields();
  };
  const navigate = useNavigate();

  const handleNavigate = () => {
    navigate("/admin/settings"); // Điều hướng tới trang /settings
  };
  const [form] = Form.useForm();
  const onFinish = (values) => {
    console.log('Received values of form: ', values);
    form.resetFields();
  };
  return (
    <div>
      <Card className='grid max-w-screen-xl'>
        <Flex className="relative" justify="space-between" align="flex-start" >
          <Flex className='justify-between'>
            <div className="relative inline-block">
              <Upload
                showUploadList={false} // Ẩn danh sách file tải lên
                beforeUpload={() => false} // Ngăn việc tải lên ngay lập tức (tải lên phía client)
                onChange={handleUpload} // Xử lý sự kiện khi người dùng chọn file
              >
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
              </Upload>
            </div>
            <Flex vertical className="ml-8 justify-between">
              <div >
                <Flex className="font-semibold text-neutral-800 items-center">
                  <p title="Bảo Nguyễn" className="truncate max-w-52 inline-block">
                    <span>{user.firstName} {user.lastName}</span>
                  </p>
                  <Flex className="inline-flex items-center text-xs font-semibold py-0.5 px-3 uppercase text-white bg-purple-500 ml-1 rounded-full">
                    <span>Học sinh</span>
                  </Flex>
                </Flex>
                <Flex align='center'>
                  <span className="text-fuchsia-800 text-sm">{user.email}</span>
                </Flex>
              </div>
            </Flex>
          </Flex>
          <Flex align='end' className='h-[120px]'>
            <Flex className='font-semibold'>
              <Flex vertical className='items-center'>
                <div className="text-black text-2xl">0</div>
                <div class="text-neutral-500 text-xs uppercase">QUIZ</div>
              </Flex>
              <Flex vertical className='items-center ml-8'>
                <div className="text-black text-2xl">0</div>
                <div class="text-neutral-500 text-xs uppercase">BỘ SƯU TẬP</div>
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

      <Tabs size={'large'} className='px-8'>
        <Tabs.TabPane tab={<span style={{ fontSize: '16px', fontWeight: 'bold' }}>Thư viện</span>} key="tab 1">

        </Tabs.TabPane>
        <Tabs.TabPane tab={<span style={{ fontSize: '16px', fontWeight: 'bold' }}>Bộ sưu tập</span>} key="tab 2">

        </Tabs.TabPane>
      </Tabs>
    </div >

  );
};

export default ProfilePage;
