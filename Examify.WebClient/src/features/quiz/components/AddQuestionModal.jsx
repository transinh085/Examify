import { Button, Checkbox, Empty, Flex, Form, Input, Modal, Popover, Select, Space, Tooltip } from 'antd';
import { CustomerServiceOutlined, DeleteOutlined, EditOutlined, OpenAIOutlined, PlusOutlined } from '@ant-design/icons';

const questionTypes = [
  { label: 'Multiple choice', value: 'multiple-choice' },
  { label: 'True or false', value: 'true-or-false' },
  { label: 'Fill in the blanks', value: 'fill-in-the-blanks' },
];

const timeOptions = [
  { label: '5 seconds', value: 5 },
  { label: '10 seconds', value: 10 },
  { label: '20 seconds', value: 20 },
  { label: '30 seconds', value: 30 },
  { label: '45 seconds', value: 45 },
];

const pointOptions = [
  { label: '1 point', value: 1 },
  { label: '2 points', value: 2 },
  { label: '3 points', value: 3 },
  { label: '4 points', value: 4 },
  { label: '5 points', value: 5 },
];

const AddQuestionModal = ({ open, onCancel }) => {
  const [form] = Form.useForm();

  const onFinish = (values) => {
    console.log('Received values:', values);
  };

  return (
    <Modal
      title="Add question"
      open={open}
      onCancel={onCancel}
      width={1200}
      className="add-question-modal"
      onOk={form.submit}
      maskClosable={false}
      centered
    >
      <Form
        form={form}
        initialValues={{
          question_type: 'multiple-choice',
          time: 10,
          point: 1,
          question: '',
        }}
        onFinish={onFinish}
        layout="vertical"
      >
        <Flex align="center" justify="space-between" className="mb-5">
          <Space>
            <p className="inline-block bg-primary text-white px-3 py-[2px] rounded-full ">Câu 1</p>
            <Tooltip title="Add voice">
              <Button shape="circle" size="small" variant="filled" color="primary" icon={<CustomerServiceOutlined />} />
            </Tooltip>
            <Popover content={<GenerativeAI />} title="Generative AI" trigger="click" placement="rightBottom">
              <Button shape="circle" size="small" variant="filled" color="primary" icon={<OpenAIOutlined />} />
            </Popover>
          </Space>
          <Space align="center">
            <Form.Item name="question_type">
              <Select options={questionTypes} size="small" style={{ width: 150 }} />
            </Form.Item>
            <Form.Item name="time">
              <Select options={timeOptions} size="small" />
            </Form.Item>
            <Form.Item name="point">
              <Select options={pointOptions} size="small" style={{ width: 90 }} />
            </Form.Item>
          </Space>
        </Flex>
        <Form.Item
          name="question"
          label="Question"
          rules={[
            {
              required: true,
              message: 'Missing question',
            },
          ]}
        >
          <Input.TextArea placeholder="Enter your question" rows={3} variant="filled" />
        </Form.Item>

        <Form.List name="options">
          {(fields, { add, remove }) => (
            <>
              <Flex className="my-4" justify="space-between" align="center">
                <p className="text-sm text-[#666] font-semibold mb-2">Answers</p>
                <Button variant="filled" color="primary" size="small" icon={<PlusOutlined />} onClick={() => add()}>
                  Add answers
                </Button>
              </Flex>
              <div className="h-[170px] overflow-y-auto">
                {fields.length == 0 ? (
                  <Empty image={Empty.PRESENTED_IMAGE_SIMPLE} description="No answers" />
                ) : (
                  fields.length > 0 &&
                  fields.map(({ key, ...restField }) => <AnswerOption key={key} field={restField} remove={remove} />)
                )}
              </div>
            </>
          )}
        </Form.List>
      </Form>
    </Modal>
  );
};

const AnswerOption = ({ field, remove }) => (
  <Flex key={field.key} align="center" className="mb-2" gap={20}>
    <Form.Item {...field} name={[field.name, 'is_correct']} valuePropName="checked" initialValue={false}>
      <Checkbox />
    </Form.Item>
    <Form.Item {...field} name={[field.name, 'content']} rules={[{ required: true, message: '' }]} className="flex-1">
      <Input placeholder="Enter option" variant="filled" />
    </Form.Item>
    <Button variant="filled" color="danger" icon={<DeleteOutlined />} onClick={() => remove(field.name)} />
  </Flex>
);

const GenerativeAI = () => {
  return (
    <Form layout="vertical">
      <Form.Item name="generative_ai">
        <Input.TextArea placeholder="Enter your question" rows={3} variant="filled" />
      </Form.Item>
      <Flex justify="end" gap={10}>
        <Button onClick={() => console.log('Cancel clicked')} size="small">
          Cancel
        </Button>
        <Button type="primary" onClick={() => console.log('Generate clicked')} size="small" icon={<EditOutlined />}>
          Generate
        </Button>
      </Flex>
    </Form>
  );
};

export default AddQuestionModal;
