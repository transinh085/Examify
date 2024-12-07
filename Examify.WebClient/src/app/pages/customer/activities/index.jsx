import { Flex, Segmented, Space, Typography } from 'antd';
import { useSearchParams } from 'react-router-dom';
import RecentQuizTable from '~/features/customer/acitivities/components/RecentQuizTable';

const Activities = () => {
  const [params, setParams] = useSearchParams();

  return (
    <Space size="middle" direction="vertical" className="mt-6 w-full">
      <Flex align="center" justify="space-between">
        <Typography.Title level={4} className="!mb-0">
          Recent activity
        </Typography.Title>
        <Segmented
          value={params.get('status') || 'all'}
          options={[
            { label: 'All', value: 'all' },
            { label: 'In complete', value: 'incomplete' },
            {
              label: 'Completed',
              value: 'completed',
            },
          ]}
          onChange={(value) => {
            params.set('status', value);
            params.set('pageNumber', 1);
            setParams(params);
          }}
        />
      </Flex>
      <RecentQuizTable params={params} setParams={setParams} />
    </Space>
  );
};

export default Activities;
