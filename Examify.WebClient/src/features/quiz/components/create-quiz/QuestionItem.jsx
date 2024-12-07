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
import { useDeleteQuestion } from '~/features/quiz/api/questions/delete-question';
import { useDuplicateQuestion } from '~/features/quiz/api/questions/duplicate-question';
import { useEffect } from 'react';
import { usePatchQuestion } from '~/features/quiz/api/questions/patch-question';
import UpdateQuestionModal from '~/features/quiz/components/question/UpdateQuestionModal';
import { useBoolean } from '~/hooks/useBoolean';

const QuestionItem = ({ quizId, order, question, listener, setActivatorNodeRef }) => {
  const { value: isModalVisible, setFalse: hideModal, setTrue: showModal } = useBoolean();
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

  const patchQuestionMutation = usePatchQuestion({
    mutationConfig: {
      onSuccess: () => {
        message.success('Update question successfully');
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
    patchQuestionMutation.mutate({
      id,
      duration: allValues.duration,
      points: allValues.points,
    });
  };

  useEffect(() => {
    if (open) {
      form.setFieldsValue({ duration, points });
    }
  }, [duration, form, points]);

  return (
    <>
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
              <p className="inline-block bg-primary text-white px-3 py-[2px] rounded-full ">Ques. {order}</p>
              <Form.Item name="duration">
                <Select options={timeOptions} size="small" style={{ width: 120 }} />
              </Form.Item>
              <Form.Item name="points">
                <Select options={pointOptions} size="small" style={{ width: 100 }} />
              </Form.Item>
            </Space>
            <Space>
              <Tooltip title="Edit this question">
                <Button icon={<EditOutlined />} size="small" onClick={showModal}>
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
      <UpdateQuestionModal open={isModalVisible} onCancel={hideModal} question={question} quizId={quizId} />
    </>
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
