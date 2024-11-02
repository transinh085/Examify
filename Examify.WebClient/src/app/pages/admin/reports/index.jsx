import { Select, Space, Typography } from 'antd';

const { Text } = Typography;

const ReportPage = () => {
  return (
    <div className="h-screen">
      <Space direction="horizontal" split={2}>
        <Text>Filter By</Text>
        <Select
          showSearch
          placeholder="Select a person"
          filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
          options={[
            { value: '1', label: 'All Games' },
            { value: '2', label: 'Lucy' },
            { value: '3', label: 'Tom' },
          ]}
        />
        <Select
          showSearch
          placeholder="Select a person"
          filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
          options={[
            { value: '1', label: 'All Games' },
            { value: '2', label: 'Lucy' },
            { value: '3', label: 'Tom' },
          ]}
        />
        <Select
          showSearch
          placeholder="Select a person"
          filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
          options={[
            { value: '1', label: 'All Games' },
            { value: '2', label: 'Lucy' },
            { value: '3', label: 'Tom' },
          ]}
        />
        <Select
          showSearch
          placeholder="Select a person"
          filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
          options={[
            { value: '1', label: 'All Games' },
            { value: '2', label: 'Lucy' },
            { value: '3', label: 'Tom' },
          ]}
        />  
      </Space>
    </div>
  );
};

export default ReportPage;
