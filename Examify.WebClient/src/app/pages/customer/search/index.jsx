import { Col, Pagination, Row } from 'antd';
import { useSearchParams } from 'react-router-dom';
import QuizItem from '~/components/ui/quizzes/QuizItem';
import QuizItemSkeleton from '~/components/ui/quizzes/QuizItemSkeleton';
import { useSearchQuiz } from '~/features/dashboard/api/get-quizzes-by-subject';

const SearchPage = () => {
  const [params, setParams] = useSearchParams();

  const {
    data: quizzes = {
      items: [],
    },
    isLoading,
  } = useSearchQuiz({
    keyword: params.get('keyword') || '',
    subjectId: params.get('subjectId'),
    pageNumber: params.get('pageNumber') || 1,
    pageSize: params.get('pageSize') || 4,
  });

  //   '2f921f98-5b80-4916-943c-31c6a88ca70e'

  return (
    <div className="py-4">
      {params.get('keyword') ? (
        <h1 className="text-lg mb-4">
          Search results for <strong>{params.get('keyword')}</strong>
        </h1>
      ) : params.get('subjectName') ? (
        <h1 className="text-lg mb-4">
          Popular quizzes for <strong>{params.get('subjectName')}</strong>
        </h1>
      ) : null}
      <Row gutter={[16, 16]}>
        {isLoading
          ? Array.from({ length: 8 }).map((_, index) => (
              <Col xs={24} sm={12} md={8} lg={6} key={index}>
                <QuizItemSkeleton />
              </Col>
            ))
          : quizzes.items.map((quiz) => (
              <Col xs={24} sm={12} md={8} lg={6} key={quiz.id}>
                <QuizItem {...quiz} />
              </Col>
            ))}
      </Row>
      <Pagination
        align="center"
        className="mt-6"
        style={{
          marginTop: '20px',
        }}
        total={quizzes?.meta?.totalCount}
        current={quizzes?.meta?.currentPage}
        pageSize={quizzes?.meta?.pageSize}
        onChange={(page, pageSize) => {
          params.set('pageNumber', page);
          params.set('pageSize', pageSize);
          setParams(params);
        }}
      />
    </div>
  );
};

export default SearchPage;
