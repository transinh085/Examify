import { App, Col, Form, Input, Modal, Row, Select } from 'antd';
import { useForm } from 'antd/es/form/Form';
import { useGetGrades } from '~/features/quiz/api/get-grades';
import { useGetSubjects } from '~/features/quiz/api/get-subjects';
import { useGetLanguages } from '~/features/quiz/api/get-languages';
import UploadCover from '~/features/quiz/components/question/UploadCover';
import { useEffect } from 'react';
import { useUpdateQuiz } from '~/features/quiz/api/quizzes/update-quiz';

const QuizSettingModal = ({ data, open, onCancel }) => {
  const [form] = useForm();
  const { message } = App.useApp();

  const { data: grades } = useGetGrades();
  const { data: subjects } = useGetSubjects();
  const { data: languages } = useGetLanguages();
  const updateQuizMutation = useUpdateQuiz({
    mutationConfig: {
      onSuccess: () => {
        onCancel();
        message.success('Quiz updated successfully');
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  useEffect(() => {
    if (open) {
      form.setFieldsValue(data);
    }
  }, [form, open, data]);

  const onFinish = (values) => {
    updateQuizMutation.mutate({ id: data.id, data: values });
  };

  return (
    <Modal
      open={open}
      onCancel={onCancel}
      width={800}
      title="Quiz settings"
      onOk={form.submit}
      confirmLoading={updateQuizMutation.isPending}
      destroyOnClose
      centered
    >
      <Form form={form} onFinish={onFinish} layout="vertical" variant="filled">
        <Row gutter={[16, 16]}>
          <Col span={12}>
            <Form.Item label="Title" name="title" rules={[{ required: true, message: 'Title is required' }]}>
              <Input placeholder="Untitled Quiz" />
            </Form.Item>
            <Form.Item label="Subject" name="subjectId">
              <Select placeholder="Select a subject" options={subjects} fieldNames={{ label: 'name', value: 'id' }} />
            </Form.Item>
            <Form.Item label="Grade" name="gradeId">
              <Select placeholder="Select a grade" options={grades} fieldNames={{ label: 'name', value: 'id' }} />
            </Form.Item>
            <Form.Item label="Langaue" name="languageId">
              <Select placeholder="Select a language" options={languages} fieldNames={{ label: 'name', value: 'id' }} />
            </Form.Item>
            <Form.Item label="Visibility" name="visibility">
              <Select
                placeholder="Select visibility"
                options={[
                  { label: 'Public', value: 1 },
                  { label: 'Private', value: 0 },
                ]}
              />
            </Form.Item>
          </Col>
          <Col span={12}>
            <Form.Item label="Description" name="description">
              <Input.TextArea rows={4} placeholder="Description" />
            </Form.Item>
            <Form.Item label="Cover" name="cover">
              <UploadCover url={data.cover} setFieldsValue={(value) => form.setFieldsValue({ cover: value })} />
            </Form.Item>
          </Col>
        </Row>
      </Form>
    </Modal>
  );
};

export default QuizSettingModal;
