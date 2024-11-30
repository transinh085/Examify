import { App, Button, Layout, Space } from 'antd';
import { useNavigate } from 'react-router-dom';
import { EyeOutlined, LeftOutlined, SaveOutlined, SettingOutlined } from '@ant-design/icons';
import { useBoolean } from '~/hooks/useBoolean';
import QuizSettingModal from '~/features/quiz/components/create-quiz/QuizSettingModal';
import { usePublishQuiz } from '~/features/quiz/api/quizzes/publish-quiz';
const { Header } = Layout;

const QuizEditorHeader = ({ quizData }) => {
  const { message } = App.useApp();
  const navigate = useNavigate();
  const { value: isSettingModalOpen, setTrue: openSettingModal, setFalse: closeSettingModal } = useBoolean();

  const publishQuizMutation = usePublishQuiz({
    mutationConfig: {
      onSuccess: () => {
        message.success('Quiz published successfully');
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const handlePublish = () => {
    publishQuizMutation.mutate({ id: quizData.id });
  };

  return (
    <Header className="sticky top-0 z-50 flex items-center justify-between bg-white border-b border-1 px-4 shadow-sm">
      <Space>
        <Button icon={<LeftOutlined />} onClick={() => navigate("/admin/my-library")} />
        <Button type="text" onClick={openSettingModal}>
          {quizData?.title}
        </Button>
      </Space>
      <Space>
        <Button icon={<SettingOutlined />} onClick={openSettingModal}>
          Setting
        </Button>
        <Button icon={<EyeOutlined />}>Preview</Button>
        {!quizData?.isPublished ? (
          <Button
            type="primary"
            icon={<SaveOutlined />}
            onClick={handlePublish}
            loading={publishQuizMutation.isPending}
          >
            Publish
          </Button>
        ) : (
          <Button type="primary" icon={<SaveOutlined />} loading={publishQuizMutation.isPending}>
            Update
          </Button>
        )}
      </Space>
      <QuizSettingModal data={quizData} open={isSettingModalOpen} onCancel={closeSettingModal} />
    </Header>
  );
};

export default QuizEditorHeader;
