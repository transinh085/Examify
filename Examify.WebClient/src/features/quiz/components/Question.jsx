import { Button, Card, Col, Flex, Form, Row, Select, Space, Tooltip } from 'antd';
import {
  CheckOutlined,
  CloseOutlined,
  CopyOutlined,
  DeleteOutlined,
  EditOutlined,
  HolderOutlined,
} from '@ant-design/icons';

const Question = () => {
  return (
    <Card className="card-question">
      <Form
        initialValues={{
          question_type: 'multiple-choice',
          time: 10,
          point: 1,
        }}
      >
        <Flex justify="space-between" className="mb-4">
          <Space align="center">
            <Button variant="filled" color="default" icon={<HolderOutlined />} size="small" className="cursor-move" />
            <p className="inline-block bg-primary text-white px-3 py-[2px] rounded-full ">Câu 1</p>
            <Form.Item name="question_type">
              <Select
                options={[
                  { label: 'Multiple choice', value: 'multiple-choice' },
                  { label: 'True or false', value: 'true-or-false' },
                  { label: 'Fill in the blanks', value: 'fill-in-the-blanks' },
                ]}
                size="small"
              />
            </Form.Item>
            <Form.Item name="time">
              <Select
                options={[
                  { label: '5 seconds', value: 5 },
                  { label: '10 seconds', value: 10 },
                  { label: '20 seconds', value: 20 },
                  { label: '30 seconds', value: 30 },
                  { label: '45 seconds', value: 45 },
                ]}
                size="small"
              />
            </Form.Item>
            <Form.Item name="point">
              <Select
                options={[
                  { label: '1 point', value: 1 },
                  { label: '2 points', value: 2 },
                  { label: '3 points', value: 3 },
                  { label: '4 points', value: 4 },
                  { label: '5 points', value: 5 },
                ]}
                size="small"
              />
            </Form.Item>
          </Space>
          <Space>
            <Tooltip title="Edit this question">
              <Button icon={<EditOutlined />} size="small">
                Edit
              </Button>
            </Tooltip>
            <Tooltip title="Duplicate this question">
              <Button icon={<CopyOutlined />} size="small" />
            </Tooltip>
            <Tooltip title="Delete this question">
              <Button icon={<DeleteOutlined />} size="small" />
            </Tooltip>
          </Space>
        </Flex>

        <p className="mb-3">
          It looks like you may not have tests set up in this repository yet. Would you like to set them up?
        </p>

        <p className="text-sm text-[#666] font-semibold mb-2">Answer choices</p>

        <Row gutter={[16, 8]}>
          <Col span={12}>
            <AnswerChoice
              text="It looks like you may not have tests set up in this repository yet. Would you like to set them up?"
              isCorrect
            />
          </Col>
          <Col span={12}>
            <AnswerChoice
              text="It looks like you may not have tests set up in this repository yet. Would you like to set them up?"
              isCorrect
            />
          </Col>
          <Col span={12}>
            <AnswerChoice text="It looks like you may not have tests set up in this repository yet. Would you like to set them up?" />
          </Col>
          <Col span={12}>
            <AnswerChoice text="It looks like you may not have tests set up in this repository yet. Would you like to set them up?" />
          </Col>
        </Row>
      </Form>
    </Card>
  );
};

const AnswerChoice = ({ text, isCorrect = false }) => {
  return (
    <Space align="start">
      {isCorrect ? <CheckOutlined className="text-green-700" /> : <CloseOutlined className="text-red-700" />}
      <p className="text-sm">{text}</p>
    </Space>
  );
};

export default Question;
