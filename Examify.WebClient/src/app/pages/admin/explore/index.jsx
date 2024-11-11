import { useCallback, useMemo } from 'react';
import { Flex, Typography, Row, Col } from 'antd';
import { StarFilled } from '@ant-design/icons';
import SearchBar from '~/features/admin/explore/components/SearchBar';
import SubjectItem from '~/features/admin/explore/components/SubjectItem';
import SectionHeader from '~/features/admin/explore/components/SectionHeader';
import QuizCard from '~/features/admin/explore/components/QuizCard';
import { subjects } from '~/features/admin/explore/data';

const { Title } = Typography;

const ExplorePage = () => {

  const handleSearch = useCallback((value) => {
    console.log('Search:', value);
  }, []);

  const handleSeeMore = useCallback(() => {
    console.log('See more clicked');
  }, []);

  const quizzes = useMemo(() => [
    {
      id: 1,
      imageUrl: 'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400',
      title: 'Europe Street beat',
      description: 'www.instagram.com'
    },
    {
      id: 2,
      imageUrl: 'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400',
      title: 'Europe Street beat',
      description: 'www.instagram.com'
    },
    {
      id: 3,
      imageUrl: 'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400',
      title: 'Europe Street beat',
      description: 'www.instagram.com'
    },
    {
      id: 4,
      imageUrl: 'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400',
      title: 'Europe Street beat',
      description: 'www.instagram.com'
    }
  ], []);

  return (
    <Flex vertical className="px-4 sm:px-6 w-full">
      <Title level={2} className="text-center mt-4 sm:mt-5 lg:py-8 text-xl sm:text-2xl">
        What will you teach today?
      </Title>

      <Flex justify="center" className="mb-6 sm:mb-8">
        <SearchBar onSearch={handleSearch} />
      </Flex>

      <div className="mb-6 sm:mb-8 overflow-x-auto">
        <Flex className="space-x-4 sm:space-x-6 min-w-min" justify="center">
          {subjects.map((item) => (
            <SubjectItem key={item.id} {...item} />
          ))}
        </Flex>
      </div>

      <section className="mb-6">
        <SectionHeader
          icon={<StarFilled className="text-yellow-500 text-xl sm:text-2xl" />}
          title="Ice breaker"
          onSeeMore={handleSeeMore}
        />

        <Row gutter={[16, 16]}>
          {quizzes.map((quiz) => (
            <Col key={quiz.id} xs={24} sm={12} lg={8} xl={6}>
              <QuizCard {...quiz} />
            </Col>
          ))}
        </Row>
      </section>
    </Flex>
  );
};

export default ExplorePage;
