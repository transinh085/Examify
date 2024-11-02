import { Tabs } from 'antd';
import { draftsData, publishedData } from '~/features/quiz/components/admin/data';
import TabContent from '~/features/quiz/components/admin/TabContent';
import TabHeaderLeft from '~/features/quiz/components/admin/TabHeaderLeft';

const MyLibraryPage = () => {
  const tabs = [
    { key: '1', label: 'Published', children: <TabContent data={publishedData} /> },
    { key: '2', label: 'Drafts', children: <TabContent data={draftsData} /> },
  ];

  return <Tabs defaultActiveKey="1" items={tabs} tabBarExtraContent={<TabHeaderLeft />} />;
};

export default MyLibraryPage;
