import { App, Button, Checkbox, Empty, Flex, Form, Input, Modal, Popover, Select, Space, Tooltip } from 'antd';
import { CustomerServiceOutlined, DeleteOutlined, EditOutlined, OpenAIOutlined, PlusOutlined } from '@ant-design/icons';
import { useCreateQuestion } from '~/features/quiz/api/questions/create-question';
import { timeOptions } from '~/features/quiz/constant/timeOptions';
import { pointOptions } from '~/features/quiz/constant/pointOptions';

const AddQuestionModal = ({ quizId, open, onCancel, questionLength }) => {
  const [form] = Form.useForm();
  const { message } = App.useApp();

  const createQuestionMutation = useCreateQuestion({
    mutationConfig: {
      onSuccess: () => {
        onCancel();
        message.success('Question added successfully');
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const onFinish = (values) => {
    if (!values.options) {
      return message.error('Please add answers');
    }

    if (values.options.length < 2) {
      return message.error('Please add at least 2 answers');
    }

    if (!values.options.some((option) => option.is_correct)) {
      return message.error('Please select the correct answer');
    }

    createQuestionMutation.mutate({
      quizId,
      data: {
        type: values.options.filter((option) => option.is_correct).length > 1 ? 1 : 0,
        order: questionLength + 1,
        ...values,
      },
    });
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
      confirmLoading={createQuestionMutation.isLoading}
      destroyOnClose
      centered
    >
      <Form
        form={form}
        initialValues={{
          type: 0,
          duration: 10,
          points: 1,
          content: '',
        }}
        onFinish={onFinish}
        onFinishFailed={() => message.error('Please fill in all required fields')}
        layout="vertical"
      >
        <Flex align="center" justify="space-between" className="mb-5">
          <Space>
            <p className="inline-block bg-primary text-white px-3 py-[2px] rounded-full ">
              Question {questionLength + 1}
            </p>
            <Tooltip title="Add voice">
              <Button shape="circle" size="small" variant="filled" color="primary" icon={<CustomerServiceOutlined />} />
            </Tooltip>
            <Popover content={<GenerativeAI />} title="Generative AI" trigger="click" placement="rightBottom">
              <Button shape="circle" size="small" variant="filled" color="primary" icon={<OpenAIOutlined />} />
            </Popover>
          </Space>
          <Space align="center">
            <Form.Item name="duration">
              <Select options={timeOptions} size="small" style={{ width: 120 }} />
            </Form.Item>
            <Form.Item name="points">
              <Select options={pointOptions} size="small" style={{ width: 110 }} />
            </Form.Item>
          </Space>
        </Flex>
        <Form.Item
          name="content"
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
