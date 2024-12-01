import { Space } from 'antd';
import { useState } from 'react';
import { useParams } from 'react-router-dom';
import QuizOverview from '~/features/admin/reports/components/QuizOverview';
import ResultsListSection from '~/features/admin/reports/components/ResultsListSection';
import UserResultsModal from '~/features/admin/reports/components/UserResultsModal';

const QuizReportDetail = () => {
  const { quizId } = useParams();
  const [openResultsModal, setOpenResultsModal] = useState(false);
  const [selectedUserId, setSelectedUserId] = useState(null);

  const handleOpenResultsModal = (userId) => {
    setSelectedUserId(userId);
    setOpenResultsModal(true);
  };

  const handleCloseResultsModal = () => setOpenResultsModal(false);

  return (
    <Space direction="vertical" size={16} className="w-full">
      <QuizOverview quizId={quizId} />
      <ResultsListSection quizId={quizId} handleViewDetails={handleOpenResultsModal} />
      <UserResultsModal
        open={openResultsModal}
        handleClose={handleCloseResultsModal}
        userId={selectedUserId}
        quizId={quizId}
      />
    </Space>
  );
};

export default QuizReportDetail;
