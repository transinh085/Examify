import { Space } from 'antd';

import { useGetQuizUser } from '~/features/quiz/api/quizzes/get-quiz-user';
import QuizItem from './QuizItem';

const ReportList = () => {
  const { data: quizzes } = useGetQuizUser();

  return (
    <Space direction="vertical" size={20} className="w-full">
      {quizzes?.quizPulished?.map((item, index) => (
        <QuizItem
          key={index}
          id={item.id}
          imgSrc={item.cover}
          title={item.title}
          author={item.owner}
          questions={item.questions}
          date={item.createdDate}
          tags={item.gradeName}
          gradeName={item.gradeName}
          languageName={item.languageName}
        />
      ))}
    </Space>
  );
};

export default ReportList;
