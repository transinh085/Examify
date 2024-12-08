import { App, Button, Checkbox, Empty, Flex, Form, Input, Modal, Select, Space, Tooltip } from 'antd';
import { pointOptions } from '~/features/quiz/constant/pointOptions';
import { timeOptions } from '~/features/quiz/constant/timeOptions';
import { PlusOutlined, CustomerServiceOutlined, DeleteOutlined } from '@ant-design/icons';
import { useEffect } from 'react';
import { useUpdateQuestion } from '~/features/quiz/api/questions/update-question';
import { v4 as uuidv4 } from 'uuid';

const UpdateQuestionModal = ({ open, onCancel, question, quizId }) => {
  const { id, content, options, points, duration, order, type } = question;
  const [form] = Form.useForm();
  const { message } = App.useApp();

  const updateQuestionMutation = useUpdateQuestion({
    mutationConfig: {
      onSuccess: () => {
        message.success('Question updated successfully');
        onCancel();
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

    updateQuestionMutation.mutate({
      id,
      data: {
        ...values,
        quizId,
        type: values.options.filter((option) => option.is_correct).length > 1 ? 1 : 0,
      },
    });
  };

  useEffect(() => {
    form.setFieldsValue({
      id,
      content,
      duration,
      points,
      options,
      type,
      order,
    });
  }, [content, duration, form, id, options, order, points, quizId, type]);

  return (
    <Modal
      title="Update question"
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
        onFinish={onFinish}
        onFinishFailed={() => message.error('Please fill in all required fields')}
        layout="vertical"
      >
        <Form.Item name="id" hidden>
          <Input />
        </Form.Item>
        <Form.Item name="type" hidden>
          <Input />
        </Form.Item>
        <Form.Item name="order" hidden>
          <Input />
        </Form.Item>
        <Flex align="center" justify="space-between" className="mb-5">
          <Space>
            <p className="inline-block bg-primary text-white px-3 py-[2px] rounded-full ">Question {order}</p>
            <Tooltip title="Add voice">
              <Button shape="circle" size="small" variant="filled" color="primary" icon={<CustomerServiceOutlined />} />
            </Tooltip>
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
    <Form.Item {...field} name={[field.name, 'id']} initialValue={uuidv4()} hidden>
      <Input />
    </Form.Item>
    <Form.Item {...field} name={[field.name, 'is_correct']} valuePropName="checked" initialValue={false}>
      <Checkbox />
    </Form.Item>
    <Form.Item {...field} name={[field.name, 'content']} rules={[{ required: true, message: '' }]} className="flex-1">
      <Input placeholder="Enter option" variant="filled" />
    </Form.Item>
    <Button variant="filled" color="danger" icon={<DeleteOutlined />} onClick={() => remove(field.name)} />
  </Flex>
);
export default UpdateQuestionModal;
