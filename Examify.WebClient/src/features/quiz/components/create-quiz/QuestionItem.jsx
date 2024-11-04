import { App, Button, Card, Col, Flex, Form, Popconfirm, Row, Select, Space, Tooltip } from 'antd';
import {
  CheckOutlined,
  CloseOutlined,
  CopyOutlined,
  DeleteOutlined,
  EditOutlined,
  HolderOutlined,
} from '@ant-design/icons';
import { timeOptions } from '~/features/quiz/constant/timeOptions';
import { pointOptions } from '~/features/quiz/constant/pointOptions';
import { questionTypesOptions } from '~/features/quiz/constant/questionTypesOptions';
import { useDeleteQuestion } from '~/features/quiz/api/questions/delete-question';
import { useDuplicateQuestion } from '~/features/quiz/api/questions/duplicate-question';
import { useEffect } from 'react';

const QuestionItem = ({ quizId, order, question, listener, setActivatorNodeRef }) => {
  const [form] = Form.useForm();
  const { id, content, options, points, duration } = question;
  const { message } = App.useApp();

  const deleteQuestionMutation = useDeleteQuestion({
    mutationConfig: {
      onSuccess: () => {
        message.success('Delete question successfully');
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const duplicateQuestionMutation = useDuplicateQuestion({
    mutationConfig: {
      onSuccess: () => {
        message.success('Duplicate question successfully');
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const handleDeleteQuestion = () => {
    deleteQuestionMutation.mutate({
      quizId: quizId,
      questionId: id,
    });
  };

  const handleDuplicateQuestion = () => {
    duplicateQuestionMutation.mutate({
      quizId: quizId,
      questionId: id,
    });
  };

  const handleValuesChange = (changedValues, allValues) => {
    console.log('changedValues', changedValues);
    console.log('allValues', allValues);
  };

  useEffect(() => {
    if (open) {
      form.setFieldsValue({ duration, points });
    }
  }, [duration, form, points]);

  return (
    <Card className="card-question">
      <Form
        form={form}
        initialValues={{
          duration,
          points,
        }}
        onValuesChange={handleValuesChange}
      >
        <Flex justify="space-between" className="mb-4">
          <Space align="center">
            <Button
              variant="filled"
              color="default"
              icon={<HolderOutlined />}
              size="small"
              className="cursor-move"
              ref={setActivatorNodeRef}
              {...listener}
            />
            <p className="inline-block bg-primary text-white px-3 py-[2px] rounded-full ">Câu {order}</p>
            <Button size="small">{questionTypesOptions[0].label}</Button>
            <Form.Item name="duration">
              <Select options={timeOptions} size="small" />
            </Form.Item>
            <Form.Item name="points">
              <Select options={pointOptions} size="small" style={{ width: 100 }} />
            </Form.Item>
          </Space>
          <Space>
            <Tooltip title="Edit this question">
              <Button icon={<EditOutlined />} size="small">
                Edit
              </Button>
            </Tooltip>
            <Tooltip title="Duplicate this question">
              <Button icon={<CopyOutlined />} size="small" onClick={handleDuplicateQuestion} />
            </Tooltip>
            <Popconfirm
              title="Are you sure to delete this question?"
              okText="Yes"
              cancelText="No"
              trigger={['hover']}
              placement="topRight"
              onConfirm={handleDeleteQuestion}
            >
              <Button variant="filled" color="danger" icon={<DeleteOutlined />} size="small" />
            </Popconfirm>
          </Space>
        </Flex>

        <p className="mb-3">{content}</p>

        <p className="text-sm text-[#666] font-semibold mb-2">Answer choices</p>

        <Row gutter={[16, 8]}>
          {options.map((option, index) => (
            <Col span={12} key={index}>
              <AnswerChoice text={option.content} isCorrect={option.is_correct} />
            </Col>
          ))}
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

export default QuestionItem;
