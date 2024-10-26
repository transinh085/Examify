import { Button, Card, Col, Flex, Form, Input, Row } from 'antd';
import SubjectQuizSection from '~/features/dashboard/components/SubjectQuizSection';
const { Search } = Input;
import giphy from '~/assets/images/giphy.webp';

const DashboardPage = () => {
  return (
    <div className="py-4">
      <Row gutter={[24, 24]}>
        <Col span={24}>
          <Card>
            <Flex vertical align="center" justify="center" className="px-4 pt-0 pb-4" gap={2}>
              <div className="w-max h-max pb-4">
                <img src={giphy} alt="" className="w-[280px] h-auto" />
              </div>
              <h1 className="text-[24px]">
                Xin chào, <strong>Quan Phat</strong>!
              </h1>
              <p className="text-lg text-gray-600">
                Hãy khám phá các bài kiểm tra thú vị và thử thách bản thân ngay hôm nay!
              </p>
              <p className="text-base  text-gray-500">
                Bạn đã sẵn sàng để bắt đầu chưa? Chọn một bài kiểm tra để tiếp tục hành trình học hỏi của mình.
              </p>
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
