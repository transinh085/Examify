import { Button, Flex, Popconfirm, Progress, Space, Table, Tag, Typography } from 'antd';
import dayjs from 'dayjs';
import { Link } from 'react-router-dom';
import { useDeleteQuizResult } from '~/features/customer/acitivities/api/delete-quiz-result';
import { useGetRecentActivity } from '~/features/customer/dashboard/api/get-recent-activity';

const RecentQuizTable = ({ params, setParams }) => {
  const {
    data = {
      items: [],
      meta: { currentPage: 1, pageSize: 6, totalCount: 0 },
    },
    isLoading,
  } = useGetRecentActivity({
    pageNumber: params.get('pageNumber') || 1,
    pageSize: params.get('pageSize') || 6,
    status: params.get('status') || 'all',
  });

  const deleteQuizResultMutation = useDeleteQuizResult({
    params: {
      status: params.get('status') || 'all',
      pageNumber: params.get('pageNumber') || 1,
      pageSize: params.get('pageSize') || 6,
    },
  });

  const columns = [
    {
      title: 'Title',
      dataIndex: 'title',
      key: 'title',
      render: (text, record) => (
        <Flex align="center" gap={20}>
          <img src={record.cover} alt={record.title} className="w-14 h-14 object-cover rounded-md" />
          <Space direction="vertical" size="small">
            <Typography.Text>{text}</Typography.Text>
            <Tag color="cyan">{record.questionCount} questions</Tag>
          </Space>
        </Flex>
      ),
    },
    {
      title: 'Attempted',
      dataIndex: 'attemptedNumber',
      key: 'attemptedNumber',
      align: 'center',
    },
    {
      title: 'Date',
      dataIndex: 'createdDate',
      key: 'createdDate',
      render: (text) => dayjs(text).format('HH:mm / DD MMM YYYY'),
    },
    {
      title: 'Status',
      dataIndex: 'currentProgress',
      key: 'currentProgress',
      render: (text) => <Progress type="circle" percent={text} size={45} status="active" />,
    },
    {
      title: 'Action',
      dataIndex: 'action',
      key: 'action',
      render: (text, record) => (
        <Space>
          <Link to={`/join/game/${record.id}`}>
            <Button size="small">View</Button>
          </Link>
          <Popconfirm
            title="Delete the result"
            description="Are you sure to delete this result?"
            okText="Yes"
            cancelText="No"
            onConfirm={() => {
              deleteQuizResultMutation.mutate({ id: record.id });
            }}
          >
            <Button size="small" danger>
              Delete
            </Button>
          </Popconfirm>
        </Space>
      ),
      float: 'right',
    },
  ];

  return (
    <Table
      rowKey={(record) => record.id}
      columns={columns}
      dataSource={data.items}
      loading={isLoading}
      pagination={{
        current: data?.meta.currentPage,
        pageSize: data?.meta.pageSize,
        total: data?.meta.totalCount,
        onChange: (page, pageSize) => {
          params.set('pageNumber', page);
          params.set('pageSize', pageSize);
          setParams(params);
        },
      }}
    />
  );
};

export default RecentQuizTable;
