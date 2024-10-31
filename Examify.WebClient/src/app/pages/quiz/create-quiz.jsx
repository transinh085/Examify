import { Button, Card, Col, Flex, Form, Layout, Row, Select, Space } from 'antd';
import {
  EditOutlined,
  EyeOutlined,
  LeftOutlined,
  PlusOutlined,
  SaveOutlined,
  SettingOutlined,
} from '@ant-design/icons';
import { useBoolean } from '~/hooks/useBoolean';
import SettingModal from '~/features/quiz/components/SettingModal';
import Question from '~/features/quiz/components/Question';
import AddQuestionModal from '~/features/quiz/components/AddQuestionModal';
import { useLoaderData, useNavigate } from 'react-router-dom';
import { getQuizQueryOptions } from '~/features/quiz/api/get-quiz';
const { Header, Content } = Layout;

export const CreateQuizLoader =
  (queryClient) =>
  async ({ params }) => {
    const query = getQuizQueryOptions(params.quizId);
    return queryClient.getQueryData(query.queryKey) ?? (await queryClient.fetchQuery(query));
  };

const CreateQuizPage = () => {
  const quizData = useLoaderData();

  const { title } = quizData;

  const navigate = useNavigate();
  const { value: isSettingModalOpen, setTrue: openSettingModal, setFalse: closeSettingModal } = useBoolean();
  const {
    value: isAddQuestionModalOpen,
    setTrue: openAddQuestionModal,
    setFalse: closeAddQuestionModal,
  } = useBoolean();

  return (
    <Layout className="bg-[#f2f2f2] min-h-screen">
      <Header className="sticky top-0 z-50 flex items-center justify-between bg-white border-b border-1 px-4 shadow-sm">
        <Space>
          <Button icon={<LeftOutlined />} onClick={() => navigate(-1)} />
          <Button type="text" onClick={openSettingModal}>
            {title}
          </Button>
        </Space>
        <Space>
          <Button icon={<SettingOutlined />} onClick={openSettingModal}>
            Setting
          </Button>
          <Button icon={<EyeOutlined />}>Preview</Button>
          <Button type="primary" icon={<SaveOutlined />}>
            Publish
          </Button>
        </Space>
      </Header>
      <Content className="w-full md:w-[95%] xl:w-[1280px] 2xl:w-[1280px] mx-auto mt-4 flex-grow">
        <Row gutter={[16]}>
          <Col span={6}>
            <Card title="Bulk update">
              <Form layout="vertical" variant="filled">
                <Form.Item name="time" label="Time">
                  <Select
                    placeholder="Select time"
                    options={[
                      {
                        label: '5 seconds',
                        value: 5,
                      },
                      {
                        label: '10 seconds',
                        value: 10,
                      },

                      {
                        label: '20 seconds',
                        value: 20,
                      },
                      {
                        label: '30 seconds',
                        value: 30,
                      },
                      {
                        label: '45 seconds',
                        value: 45,
                      },
                    ]}
                  />
                </Form.Item>
                <Form.Item name="points" label="Points">
                  <Select
                    placeholder="Select points"
                    options={[
                      {
                        label: '1 point',
                        value: 1,
                      },
                      {
                        label: '2 points',
                        value: 2,
                      },

                      {
                        label: '3 points',
                        value: 3,
                      },
                      {
                        label: '4 points',
                        value: 4,
                      },
                      {
                        label: '5 points',
                        value: 5,
                      },
                    ]}
                  />
                </Form.Item>
                <Form.Item>
                  <Button type="primary" htmlType="submit" icon={<EditOutlined />} block>
                    Update
                  </Button>
                </Form.Item>
              </Form>
            </Card>
          </Col>
          <Col span={18}>
            <Flex align="center" justify="space-between" className="mb-4">
              <Space className="text-lg">
                <span className="font-semibold">3 questions</span>
                <span>(18 points)</span>
              </Space>
              <Button color="primary" variant="filled" icon={<PlusOutlined />} onClick={openAddQuestionModal}>
                Add question
              </Button>
            </Flex>
            <Question />
          </Col>
        </Row>
      </Content>
      <SettingModal data={quizData} open={isSettingModalOpen} onCancel={closeSettingModal} />
      <AddQuestionModal open={isAddQuestionModalOpen} onCancel={closeAddQuestionModal} />
    </Layout>
  );
};

export default CreateQuizPage;
