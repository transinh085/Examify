import { Tabs } from 'antd';
import { useSearchParams } from 'react-router-dom';
import TabContent from '~/features/admin/mylibrary/components/TabContent';

const MyLibraryPage = () => {
  const [params, setParams] = useSearchParams();

  const tabs = [
    { key: '1', label: 'Published', children: <TabContent params={params} setParams={setParams} isPublished /> },
    { key: '2', label: 'Drafts', children: <TabContent params={params} setParams={setParams} /> },
  ];

  return (
    <Tabs
      defaultActiveKey={params.get('isPublished') == 'false' ? '2' : '1'}
      items={tabs}
      onChange={(key) => {
        params.set('isPublished', key == '1');
        params.set('pageNumber', 1);
        params.set('pageSize', 4);
        setParams(params);
      }}
    />
  );
};

export default MyLibraryPage;
