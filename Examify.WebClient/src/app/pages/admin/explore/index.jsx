import { useCallback } from 'react';
import { Flex, Typography } from 'antd';
import SearchBar from '~/features/admin/explore/components/SearchBar';
import SubjectItem from '~/features/admin/explore/components/SubjectItem';
import { subjects } from '~/features/admin/explore/data';
import RecentQuizList from '~/features/customer/dashboard/components/RecentQuizList';

const { Title } = Typography;

const ExplorePage = () => {
  const handleSearch = useCallback((value) => {
    console.log('Search:', value);
  }, []);

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
        <RecentQuizList />
      </section>
    </Flex>
  );
};

export default ExplorePage;
