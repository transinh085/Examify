import { Button, Card, Col, Flex, Form, Input, Row } from 'antd';
import SubjectQuizSection from '~/features/dashboard/components/SubjectQuizSection';
const { Search } = Input;
import useAuthStore from '~/stores/auth-store';

import leftGif from '~/assets/gif/a.gif';
import rightGif from '~/assets/gif/d.gif';

const DashboardPage = () => {
  const { user } = useAuthStore();
  return (
    <div className="py-4">
      <Row gutter={[24, 24]}>
        <Col span={24}>
          <Card>
            <Flex vertical align="center" justify="center" className="pb-4" gap={2}>
              <Flex gap={20}>
                <img src={leftGif} alt="" className="w-[220px] h-auto" />
                <img src={rightGif} alt="" className="w-[210px] h-auto" />
              </Flex>

              <div className="py-4">
                <h1 className="text-[20px] text-center">
                  Welcome back, <strong className="text-primary text-[24px]">{user?.firstName || 'Chill Guy'}</strong>!
                </h1>
                <p className="text-center text-lg text-gray-600">
                  Let us help you to improve your knowledge and skills
                </p>
              </div>
            </Flex>
            <Form onFinish={null} layout="inline">
              <Form.Item style={{ flex: 1 }}>
                <Search placeholder="Tìm kiếm bài kiểm tra..." onSearch={() => {}} />
              </Form.Item>
              <Form.Item
                name="username"
                rules={[
                  {
                    required: true,
                    message: 'Nhập mã tham gia',
                  },
                ]}
              >
                <Input placeholder="Nhập mã tham gia" />
              </Form.Item>
              <Form.Item>
                <Button type="primary" htmlType="submit">
                  Tham gia
                </Button>
              </Form.Item>
            </Form>
          </Card>
        </Col>
        <Col span={24}>
          <SubjectQuizSection />
        </Col>
      </Row>
    </div>
  );
};

export default DashboardPage;
