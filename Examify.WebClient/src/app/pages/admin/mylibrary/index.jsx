import { Flex, Spin, Tabs } from 'antd';
import TabContent from '~/features/admin/mylibrary/components/TabContent';
import TabHeaderLeft from '~/features/admin/mylibrary/components/TabHeaderLeft';
import { useGetQuizUser } from '~/features/quiz/api/quizzes/get-quiz-user';


const MyLibraryPage = () => {
  const { data: quizzes, isLoading } = useGetQuizUser();

  if (isLoading) return <Flex justify='center'>
    <Spin />
  </Flex>;

  const tabs = [
    { key: '1', label: 'Published', children: <TabContent data={quizzes?.quizPulished} /> },
    { key: '2', label: 'Drafts', children: <TabContent data={quizzes?.quizUnpublished} /> },
  ];

  return <Tabs defaultActiveKey="1" items={tabs} tabBarExtraContent={<TabHeaderLeft />} />;
};

export default MyLibraryPage;
