import { App, Button, Layout, Space } from 'antd';
import { useNavigate } from 'react-router-dom';
import { EyeOutlined, LeftOutlined, SaveOutlined, SettingOutlined } from '@ant-design/icons';
import { useBoolean } from '~/hooks/useBoolean';
import QuizSettingModal from '~/features/quiz/components/create-quiz/QuizSettingModal';
import { usePublishQuiz } from '~/features/quiz/api/quizzes/publish-quiz';
import { useQueryClient } from '@tanstack/react-query';
const { Header } = Layout;

const QuizEditorHeader = ({ quizData }) => {
  const { message } = App.useApp();
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const { value: isSettingModalOpen, setTrue: openSettingModal, setFalse: closeSettingModal } = useBoolean();

  const publishQuizMutation = usePublishQuiz({
    mutationConfig: {
      onSuccess: () => {
        queryClient.invalidateQueries('quiz-user');
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
        <Button icon={<LeftOutlined />} onClick={() => navigate(-1)} />
        <Button type="text" onClick={openSettingModal}>
          {quizData?.title}
        </Button>
      </Space>
      <Space>
        <Button icon={<SettingOutlined />} onClick={openSettingModal}>
          Setting
        </Button>
        <Button icon={<EyeOutlined />}>Preview</Button>
        <Button type="primary" icon={<SaveOutlined />} onClick={handlePublish} loading={publishQuizMutation.isPending}>
          Publish
        </Button>
      </Space>
      <QuizSettingModal data={quizData} open={isSettingModalOpen} onCancel={closeSettingModal} />
    </Header>
  );
};

export default QuizEditorHeader;
