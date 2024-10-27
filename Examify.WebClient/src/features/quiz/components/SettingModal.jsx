import { App, Col, Form, Input, Modal, Row, Select } from 'antd';
import { useForm } from 'antd/es/form/Form';
import { InboxOutlined } from '@ant-design/icons';
import { Upload } from 'antd';
const { Dragger } = Upload;

const SettingModal = ({ open, onCancel }) => {
  const [form] = useForm();
  const { message } = App.useApp();

  const onFinish = (values) => {
    console.log(values);
  };

  const props = {
    name: 'file',
    multiple: false,
    action: 'https://660d2bd96ddfa2943b33731c.mockapi.io/api/upload',
    onChange(info) {
      const { status } = info.file;
      if (status !== 'uploading') {
        console.log(info.file, info.fileList);
      }
      if (status === 'done') {
        message.success(`${info.file.name} file uploaded successfully.`);
      } else if (status === 'error') {
        message.error(`${info.file.name} file upload failed.`);
      }
    },
    onDrop(e) {
      console.log('Dropped files', e.dataTransfer.files);
    },
  };

  return (
    <Modal open={open} onCancel={onCancel} width={800} title="Quiz settings">
      <Form form={form} onFinish={onFinish} layout="vertical">
        <Row gutter={[16, 16]}>
          <Col span={12}>
            <Form.Item label="Name" name="name">
              <Input placeholder="Untitled Quiz" />
            </Form.Item>
            <Form.Item label="Subject" name="subject">
              <Select
                placeholder="Select a subject"
                options={[
                  { label: 'Mathematics', value: 'mathematics' },
                  { label: 'Physics', value: 'physics' },
                  { label: 'Chemistry', value: 'chemistry' },
                  { label: 'Biology', value: 'biology' },
                  { label: 'Computer Science', value: 'computer-science' },
                  { label: 'English', value: 'english' },
                  { label: 'History', value: 'history' },
                  { label: 'Geography', value: 'geography' },
                  { label: 'Economics', value: 'economics' },
                  { label: 'Civics', value: 'civics' },
                ]}
              />
            </Form.Item>
            <Form.Item label="Grade" name="grade">
              <Select
                placeholder="Select a grade"
                options={[
                  { label: 'Grade 1', value: 'grade-1' },
                  { label: 'Grade 2', value: 'grade-2' },
                  { label: 'Grade 3', value: 'grade-3' },
                  { label: 'Grade 4', value: 'grade-4' },
                  { label: 'Grade 5', value: 'grade-5' },
                  { label: 'Grade 6', value: 'grade-6' },
                  { label: 'Grade 7', value: 'grade-7' },
                  { label: 'Grade 8', value: 'grade-8' },
                  { label: 'Grade 9', value: 'grade-9' },
                  { label: 'Grade 10', value: 'grade-10' },
                  { label: 'Grade 11', value: 'grade-11' },
                  { label: 'Grade 12', value: 'grade-12' },
                ]}
              />
            </Form.Item>
            <Form.Item label="Langaue" name="language">
              <Select
                placeholder="Select a language"
                options={[
                  { label: 'English', value: 'english' },
                  { label: 'Hindi', value: 'hindi' },
                  { label: 'Tamil', value: 'tamil' },
                  { label: 'Telugu', value: 'telugu' },
                  { label: 'Kannada', value: 'kannada' },
                  { label: 'Malayalam', value: 'malayalam' },
                  { label: 'Bengali', value: 'bengali' },
                  { label: 'Gujarati', value: 'gujarati' },
                  { label: 'Marathi', value: 'marathi' },
                  { label: 'Punjabi', value: 'punjabi' },
                  { label: 'Odia', value: 'odia' },
                  { label: 'Assamese', value: 'assamese' },
                  { label: 'Urdu', value: 'urdu' },
                  { label: 'Sanskrit', value: 'sanskrit' },
                ]}
              />
            </Form.Item>
            <Form.Item label="Visibility" name="visibility">
              <Select
                placeholder="Select visibility"
                options={[
                  { label: 'Public', value: 'public' },
                  { label: 'Private', value: 'private' },
                ]}
              />
            </Form.Item>
          </Col>
          <Col span={12}>
            <Form.Item label="Cover" name="cover">
              <Dragger {...props}>
                <p className="ant-upload-drag-icon">
                  <InboxOutlined />
                </p>
                <p className="ant-upload-text">Click or drag file to this area to upload</p>
                <p className="ant-upload-hint">
                  Support for a single or bulk upload. Strictly prohibited from uploading company data or other banned
                  files.
                </p>
              </Dragger>
            </Form.Item>
          </Col>
        </Row>
      </Form>
    </Modal>
  );
};

export default SettingModal;
