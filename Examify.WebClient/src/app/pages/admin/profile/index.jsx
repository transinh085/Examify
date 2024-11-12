import { Avatar, Button, Card, Flex, Modal, Tabs, Tag, Upload, Space, Input, Form, Checkbox, Row, Col } from 'antd';
import { EditOutlined, BookOutlined } from '@ant-design/icons';
import React, { useEffect, useMemo, useState } from 'react';
import useAuthStore from '~/stores/auth-store';

const ProfilePage = () => {
  const { user, resetUser } = useAuthStore();
  const [imageUrl, setImageUrl] = useState(user.image);
  useEffect(() => {
    if (imageUrl) {
      console.log('File URL:', imageUrl);
    }
  }, [imageUrl]);
  // Xử lý sự kiện tải lên
  const handleUpload = (info) => {
    console.log(info)
    const url = URL.createObjectURL(info.file); // Tạo URL tạm từ file đã tải lên
    setImageUrl(url);
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
    setActiveGrades([]); // Đặt lại tất cả button về false
    setActiveSubjects([]);
  };
  const tailFormItemLayout = {
    wrapperCol: {
      xs: {
        span: 24,
        offset: 0,
      },
      sm: {
        span: 16,
        offset: 8,
      },
    },
  };
  const [gradeList, setGradeList] = useState([]);
  useEffect(() => {
    const fetchGradetList = async () => {
      try {
        const response = await fetch('http://localhost:5084/grades?pageNumber=1&pageSize=13');
        const data = await response.json();
        setGradeList(data)
      } catch (error) {
        console.error('Error fetching subject list:', error);
      }
    };

    fetchGradetList();
  }, []);
  // State lưu trữ trạng thái background của button
  const [activeGrades, setActiveGrades] = useState([]);

  // Hàm thay đổi trạng thái khi button được nhấn
  const handleClick = (id) => {
    setActiveGrades((prev) => {
      const newSelection = prev.includes(id) ? prev.filter((item) => item !== id) : [...prev, id];
      form.setFieldsValue({ grade: newSelection });
      return newSelection;
    });
  };

  const [subjectList, setSubjectList] = useState([]);
  const [showAllSubjects, setShowAllSubjects] = useState(false);
  // Mảng chứa danh sách các button
  useEffect(() => {
    const fetchSubjectList = async () => {
      try {
        const response = await fetch('http://localhost:5084/subjects');
        const data = await response.json();
        setSubjectList(data)

      } catch (error) {
        console.error('Error fetching subject list:', error);
      }
    };

    fetchSubjectList();
  }, []);
  // State lưu trữ trạng thái background của button
  const [activeSubjects, setActiveSubjects] = useState([]);

  // Hàm thay đổi trạng thái khi button được nhấn
  const handleClickSubject = (id) => {
    setActiveSubjects((prev) => {
      const newSelection = prev.includes(id) ? prev.filter((item) => item !== id) : [...prev, id];
      form.setFieldsValue({ subject: newSelection });
      return newSelection;
    });
  };

  const toggleShowAllSubjects = () => {
    setShowAllSubjects(!showAllSubjects);
  };

  // Limit to 12 subjects unless showing all
  const displayedSubjects = useMemo(() => showAllSubjects ? subjectList : subjectList.slice(0, 11), [showAllSubjects, subjectList])

  const [form] = Form.useForm();
  const onFinish = (values) => {
    console.log('Received values of form: ', values);
    form.resetFields();
    setActiveGrades([]); // Đặt lại tất cả button về false
    setActiveSubjects([]);
  };
  return (
    <div>
      <Card className='grid max-w-screen-xl'>
        <Flex className="relative" justify="space-between" align="flex-start" >
          <Flex className='justify-between'>
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
            />
            <Upload
              showUploadList={false} // Ẩn danh sách file tải lên
              beforeUpload={() => false} // Ngăn việc tải lên ngay lập tức (tải lên phía client)
              onChange={handleUpload} // Xử lý sự kiện khi người dùng chọn file
            >
              {/* <Button icon={<UploadOutlined />}>Tải ảnh lên</Button> */}
            </Upload>
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
              <div className="text-sm">
                <div >
                  <BookOutlined />
                  <span className='ml-1'>Máy tính, Toán</span>
                </div>
                <div >
                  <Tag color="green" className='text-base'>Đại học</Tag>
                </div>
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
              <Button type="primary" onClick={showModal} icon={<EditOutlined />}>
                Chỉnh sửa hồ sơ
              </Button>
            </Space>
            <Modal
              open={open}
              title="Chỉnh sửa hồ sơ."
              onOk={handleOk}
              onCancel={handleCancel}
              width={650}
              footer={(_, { OkBtn, CancelBtn }) => (
                <>
                  <CancelBtn />
                  <OkBtn />
                </>
              )}
            >
              <Form
                form={form}
                name="profileupdate"
                onFinish={onFinish}
                style={{
                  maxWidth: 600,
                }}
                scrollToFirstError
                initialValues={{ firstName: user.firstName, lastName: user.lastName }}
              >
                <Flex gap={16} horizontal>
                  <Form.Item
                    name="firstName"
                    label="Tên"
                    rules={[
                      {
                        type: 'firstname',
                        message: 'The input is not valid Firstname!',
                      },
                      {
                        required: true,
                        message: 'Please input your Firstname!',
                      },
                    ]}
                  >
                    <Input />
                  </Form.Item>
                  <Form.Item
                    name="lastName"
                    label="Họ"
                    rules={[
                      {
                        type: 'lastname',
                        message: 'The input is not valid Lastname!',
                      },
                      {
                        required: true,
                        message: 'Please input your Lastname!',
                      },
                    ]}
                  >
                    <Input defaultValue={user.lastName} />
                  </Form.Item>
                </Flex>
                <Flex horizontal>
                  <Form.Item name="grade" label="Lớp">
                    <Flex gap="small" wrap>
                      {gradeList.map((grade) => (
                        <Button
                          key={grade.id}
                          color="default"
                          variant="filled"
                          onClick={() => handleClick(grade.id)}
                          style={{
                            margin: '5px',
                            backgroundColor: activeGrades.includes(grade.id) ? '#4CAF50' : '#fff',
                            color: activeGrades.includes(grade.id) ? '#fff' : '#000',
                          }}
                        >
                          {grade.name}
                        </Button>
                      ))}
                    </Flex>
                  </Form.Item>
                </Flex>
                <Flex horizontal>
                  <Form.Item name="subject" label="Môn học">
                    <Flex gap="small" wrap>
                      {displayedSubjects.map((subject) => (
                        <Button
                          key={subject.id}
                          color="default"
                          variant="filled"
                          onClick={() => handleClickSubject(subject.id)}
                          style={{
                            margin: '5px',
                            backgroundColor: activeSubjects.includes(subject.id) ? '#4CAF50' : '#fff',
                            color: activeSubjects.includes(subject.id) ? '#fff' : '#000',
                          }}
                        >
                          {subject.name}
                        </Button>
                      ))}
                      {subjectList.length > 11 && (
                        <Button onClick={toggleShowAllSubjects} style={{ margin: '5px' }}>
                          {showAllSubjects ? 'Show Less' : 'Show More'}
                        </Button>
                      )}
                    </Flex>
                  </Form.Item>
                </Flex>
              </Form>
            </Modal>
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
