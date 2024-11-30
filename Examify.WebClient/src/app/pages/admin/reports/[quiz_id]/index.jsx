import { Space } from 'antd';
import { useParams } from 'react-router-dom';
import QuizOverview from '~/features/admin/reports/components/QuizOverview';
import ResultsListSection from '~/features/admin/reports/components/ResultsListSection';

const QuizReportDetail = () => {
  const { quizId } = useParams();
  return (
    <Space direction="vertical" size={16} className="w-full">
      <QuizOverview quizId={quizId} />
      <ResultsListSection quizId={quizId} />
    </Space>
  );
};

export default QuizReportDetail;
