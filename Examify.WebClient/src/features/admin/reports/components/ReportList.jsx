import { Col, Flex, Pagination, Row, Space, Spin } from 'antd';

import { useGetQuizUser } from '~/features/quiz/api/quizzes/get-quiz-user';
import QuizItem from './QuizItem';
import { useSearchParams } from 'react-router-dom';

const ReportList = () => {
  const [params, setParams] = useSearchParams();
  const {
    data: quizzes = {
      items: [],
    },
    isLoading,
  } = useGetQuizUser({
    isPublished: true,
    pageNumber: params.get('pageNumber') || 1,
    pageSize: params.get('pageSize') || 8,
  });

  if (isLoading)
    return (
      <Flex align="center" justify="center" className="h-[120px]">
        <Spin />
      </Flex>
    );

  return (
    <Space direction="vertical" size={20} className="w-full">
      <Row gutter={[16, 16]}>
        {quizzes?.items?.map((item, index) => (
          <Col key={index} span={12}>
            <QuizItem
              id={item.id}
              title={item.title}
              cover={item.cover}
              subject={item.subject}
              grade={item.grade}
              owner={item.owner}
              questionCount={item.questionCount}
              createDate={item.createdDate}
            />
          </Col>
        ))}
      </Row>
      <Pagination
        align="center"
        total={quizzes.meta.totalCount}
        current={quizzes.meta.currentPage}
        pageSize={quizzes.meta.pageSize}
        onChange={(page, pageSize) => {
          params.set('pageNumber', page);
          params.set('pageSize', pageSize);
          setParams(params);
        }}
      />
    </Space>
  );
};

export default ReportList;
