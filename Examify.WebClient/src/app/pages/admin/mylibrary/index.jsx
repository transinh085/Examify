import { Flex, Spin, Tabs } from 'antd';
import { useEffect } from 'react';
import { useGetQuizUser } from '~/features/quiz/api/quizzes/get-quiz-user';
import TabContent from '~/features/quiz/components/admin/TabContent';
import TabHeaderLeft from '~/features/quiz/components/admin/TabHeaderLeft';
import useMenuStore from '~/stores/menu-store';

const MyLibraryPage = () => {
  const { setSiderVisible } = useMenuStore();

  const {data: quizzes, isLoading } = useGetQuizUser();

  useEffect(() => {
    setSiderVisible(true);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  if(isLoading) return <Flex justify='center'>
    <Spin/>
  </Flex>;

  const tabs = [
    { key: '1', label: 'Published', children: <TabContent data={quizzes?.quizPulished} /> },
    { key: '2', label: 'Drafts', children: <TabContent data={quizzes?.quizUnpublished} /> },
  ];

  return <Tabs  defaultActiveKey="1" items={tabs} tabBarExtraContent={<TabHeaderLeft />} />;
};

export default MyLibraryPage;
