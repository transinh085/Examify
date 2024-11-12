import { Button, DatePicker, Dropdown, Flex, Layout, Menu, Progress, Select, Space, Table, Tag, Typography } from 'antd';
import { DeleteOutlined, DownloadOutlined, EditOutlined, MoreOutlined } from '@ant-design/icons';
import moment from 'moment';

const { Content } = Layout;
const { Text } = Typography;

const columns = [
  {
    title: 'Type',
    dataIndex: 'type',
    key: 'type',
    render: (text) => <Tag color="blue">{text}</Tag>,
  },
  {
    title: 'Quiz Name',
    dataIndex: 'name',
    key: 'name',
  },
  {
    title: 'Total Participants',
    dataIndex: 'totalParticipants',
    key: 'totalParticipants',
  },
  {
    title: 'Accuracy',
    key: 'accuracy',
    dataIndex: 'accuracy',
    render: (_, { accuracy }) => (
      <Space>
        <Progress type="circle" percent={accuracy} size={20} />
        <Text className="font-semibold">{accuracy}%</Text>
      </Space>
    ),
  },
  {
    title: 'Code',
    key: 'code',
    dataIndex: 'code',
  },
  {
    title: 'Action',
    key: 'action',
    render: (_, record) => (
      <Dropdown overlay={menu(record)} trigger={['click']}>
        <Button icon={<MoreOutlined />} />
      </Dropdown>
    ),
  },
];

const data = [
  {
    key: '1',
    type: 'Math',
    name: 'Algebra Basics',
    totalParticipants: 120,
    accuracy: 85,
    code: 'MATH123',
  },
  {
    key: '2',
    type: 'Science',
    name: 'Physics Fundamentals',
    totalParticipants: 98,
    accuracy: 90,
    code: 'SCI456',
  },
  {
    key: '3',
    type: 'History',
    name: 'World War II',
    totalParticipants: 75,
    accuracy: 78,
    code: 'HIST789',
  },
  {
    key: '4',
    type: 'Geography',
    name: 'Geography of Europe',
    totalParticipants: 60,
    accuracy: 82,
    code: 'GEO101',
  },
  {
    key: '5',
    type: 'Literature',
    name: 'Shakespearean Plays',
    totalParticipants: 45,
    accuracy: 88,
    code: 'LIT202',
  },
];

const ReportPage = () => {
  const onChange = (date) => {
    if (date) {
      console.log('Date: ', date);
    } else {
      console.log('Clear');
    }
  };
  return (
    <Content>
      <Flex gap={'middle'} align="center" className="mb-6">
        <Text className="font-bold">Filter By :</Text>
        <Space size={'small'}>
          <Select
            filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
            defaultValue={'1'}
            options={[
              { value: '1', label: 'All Games' },
              { value: '2', label: 'Lucy' },
              { value: '3', label: 'Tom' },
            ]}
          />
          <Select
            defaultValue={'1'}
            options={[
              { value: '1', label: 'All Reports' },
              { value: '2', label: 'Lucy' },
              { value: '3', label: 'Tom' },
            ]}
          />
          <Select
            defaultValue={'1'}
            options={[
              { value: '1', label: 'All Class' },
              { value: '2', label: 'Lucy' },
              { value: '3', label: 'Tom' },
            ]}
          />
          <DatePicker
            placeholder='Filter by Date'
            presets={[
              {
                label: 'Yesterday',
                value: moment().add(-1, 'd'),
              },
              {
                label: 'Last Week',
                value: moment().add(-7, 'd'),
              },
              {
                label: 'Last Month',
                value: moment().add(-1, 'month'),
              },
            ]}
            onChange={onChange}
          />
        </Space>
      </Flex>
      <Table
        rowKey={(record) => record.key}
        rowSelection={{
          type: 'checkbox',
          onChange: (selectedRowKeys, selectedRows) => {
            console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
          },
        }}
        columns={columns}
        dataSource={data}
        pagination={{
          position: ['bottomCenter'],
        }}
      />
    </Content>
  );
};

const handleMenuClick = (e, record) => {
  switch (e.key) {
    case 'delete':
      console.log('Delete', record);
      break;
    case 'rename':
      console.log('Rename', record);
      break;
    case 'export':
      console.log('Export', record);
      break;
    default:
      break;
  }
};

const menu = (record) => (
  <Menu onClick={(e) => handleMenuClick(e, record)}>
    <Menu.Item icon={<DownloadOutlined />} key="delete">
      Download Excel
    </Menu.Item>
    <Menu.Item icon={<EditOutlined />} key="rename">
      Rename report
    </Menu.Item>
    <Menu.Item icon={<DeleteOutlined />} key="export">
      Delete report
    </Menu.Item>
  </Menu>
);

export default ReportPage;
