import { Flex } from 'antd';
import QuizListBySubject from './QuizListBySubject';
import { useMemo } from 'react';
import RecentQuizList from './RecentQuizList';

const subjects = [
  {
    id: '2f921f98-5b80-4916-943c-31c6a88ca70e',
    name: 'Programming',
  },
  {
    id: '59820f61-ada9-44e8-9a45-790981fe05f0',
    name: 'Math',
  },
  {
    id: 'f9c0f102-9fab-4f11-a76c-33efd4439af0',
    name: 'English',
  },
];

const SubjectQuizSection = () => {
  const data = useMemo(
    () => [
      {
        id: '2f921f98-5b80-4916-943c-31c6a88ca70e',
        name: 'Programming',
      },
      {
        id: '59820f61-ada9-44e8-9a45-790981fe05f0',
        name: 'Math',
      },
      {
        id: 'f9c0f102-9fab-4f11-a76c-33efd4439af0',
        name: 'English',
      },
    ],
    [],
  );
  return (
    <Flex vertical className="w-full" gap={24}>
      <RecentQuizList />
      {data.map((subject) => (
        <QuizListBySubject key={subject.id} id={subject.id} name={subject.name} />
      ))}
    </Flex>
  );
};

export default SubjectQuizSection;
