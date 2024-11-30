import { Avatar, Button, Card, Progress, Space, Table } from 'antd';
import { useGetResultsOfQuiz } from '../api/get-results-of-quiz';
import { useMemo } from 'react';
import { Link } from 'react-router-dom';
import { MoreOutlined } from '@ant-design/icons';

const ResultsListSection = ({ quizId }) => {
  console.log({ quizId });
  const { data: quizResults } = useGetResultsOfQuiz({ quizId, queryOptions: { initialData: [], enabled: !!quizId } });

  const formattedQuizResults = useMemo(() => {
    if (quizResults) {
      const uniqueResults = [];
      const seenUserIds = new Set();

      quizResults
        .sort((a, b) => b?.totalPoints - a?.totalPoints)
        .forEach((result) => {
          if (!seenUserIds.has(result?.user?.id)) {
            uniqueResults.push(result);
            seenUserIds.add(result?.user?.id);
          }
        });

      return uniqueResults;
    }
  }, [quizResults]);

  const columns = [
    {
      title: 'Player',
      dataIndex: 'user',
      key: 'user',
      render: ({ name, avatar }) => (
        <Space>
          <Avatar src={avatar} />
          <h1 className="font-semibold">{name}</h1>
        </Space>
      ),
    },
    {
      title: 'Correct Rate',
      dataIndex: 'correctRate',
      key: 'correctRate',
      render: (correctRate) => <Progress type="circle" strokeColor="#00c985" percent={correctRate * 100} size={48} />,
    },
    {
      title: 'Points',
      dataIndex: 'totalPoints',
      key: 'totalPoints',
    },
    {
      title: 'Taken Time',
      dataIndex: 'timeTaken',
      key: 'timeTaken',
    },
    {
      title: 'Submitted At',
      dataIndex: 'submittedAt',
      key: 'submittedAt',
      render: (submittedAt) => new Date(submittedAt).toLocaleString(),
    },
    {
      title: 'Action',
      dataIndex: 'id',
      key: 'action',
      render: (quizResultId) => (
        <Link to={`results/${quizResultId}`}>
          <Button size="small" icon={<MoreOutlined />} />
        </Link>
      ),
    },
  ];

  return (
    <Card title="Results of players">
      <Table columns={columns} dataSource={formattedQuizResults} />
    </Card>
  );
};

export default ResultsListSection;
