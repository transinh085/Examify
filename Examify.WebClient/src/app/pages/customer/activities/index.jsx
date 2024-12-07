import { Flex, Segmented, Typography } from 'antd';
import { useState } from 'react';

const Activities = () => {
  const [tab, setTab] = useState('ONGOING');

  return (
    <div className="mt-6">
      <Flex align="center" justify="space-between">
        <Typography.Title level={4} className="!mb-0">
          Recent activity
        </Typography.Title>
        <Segmented
          value={tab}
          options={[
            { label: 'Chưa hoàn thành', value: 'ONGOING' },
            {
              label: 'Hoàn thành',
              value: 'COMPLETED',
            },
          ]}
          onChange={(value) => {
            setTab(value);
          }}
        />
      </Flex>
    </div>
  );
};

export default Activities;
