import { App, Button, Card, Form, Select } from 'antd';
import { useBulkUpdateQuestion } from '~/features/quiz/api/questions/bulk-update-question';
import { pointOptions } from '~/features/quiz/constant/pointOptions';
import { timeOptions } from '~/features/quiz/constant/timeOptions';
import { EditOutlined } from '@ant-design/icons';

const QuizBulkUpdateForm = ({ quizId, questions }) => {
  const [form] = Form.useForm();
  const { message } = App.useApp();

  const bulkUpdateQuestionMutation = useBulkUpdateQuestion({
    mutationConfig: {
      onSuccess: () => {
        message.success('Bulk update successfully');
        form.resetFields();
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const onFinish = ({ duration, points }) => {
    if (!questions.length) {
      return message.error('No questions to update');
    }

    if (!duration && !points) {
      return message.error('Please select time or points to update');
    }

    bulkUpdateQuestionMutation.mutate({
      quizId,
      data: { duration, points },
    });
  };

  return (
    <Card title="Bulk update">
      <Form form={form} layout="vertical" onFinish={onFinish} variant='filled'>
        <Form.Item name="duration" label="Time">
          <Select placeholder="Select time" options={timeOptions} />
        </Form.Item>
        <Form.Item name="points" label="Points">
          <Select placeholder="Select points" options={pointOptions} />
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit" icon={<EditOutlined />} block>
            Update
          </Button>
        </Form.Item>
      </Form>
    </Card>
  );
};

export default QuizBulkUpdateForm;
