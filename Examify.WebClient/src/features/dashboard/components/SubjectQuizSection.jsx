import { Flex } from 'antd';
import QuizListBySubject from './QuizListBySubject';
import { useMemo } from 'react';
import RecentQuizList from './RecentQuizList';

const SubjectQuizSection = () => {
  const data = useMemo(
    () => [
      {
        id: 1,
        subjectName: 'Toán',
        quizzes: [
          {
            id: 1,
            title: 'The basis of NodeJS',
            description: 'Learn the basic of NodeJS',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/fb05126a-f901-4462-868f-f3451b582902?w=200&h=200',
            percent: 60,
            questions: 10,
          },
          {
            id: 2,
            title: 'The basis of JavaScript',
            description: 'Learn the basic of JavaScript',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/7153bf8a-7e06-4ccd-afa1-0ad73aa36c40?w=200&h=200',
            percent: 100,
            questions: 24,
          },
          {
            id: 3,
            title: 'The basis of Object Oriented Programming',
            description: 'Learn the basic of Object Oriented Programming',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/2da17524-b1e3-4126-be7d-0dbcd401a07b?w=200&h=200',
            percent: 100,
            questions: 8,
          },
          {
            id: 4,
            title: 'The basis of JavaScript',
            description: 'Learn the basic of JavaScript',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/a2c54d45-a4d2-494c-8734-0ea27b4992e2?w=200&h=200',
            percent: 100,
            questions: 16,
          },
        ],
      },
      {
        id: 2,
        subjectName: 'Tiếng Anh',
        quizzes: [
          {
            id: 1,
            title: 'The basis of NodeJS',
            description: 'Learn the basic of NodeJS',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/eb5f16ad-fc3e-41ea-824d-c11dd08cebb5?w=200&h=200',
            percent: 60,
            questions: 10,
          },
          {
            id: 2,
            title: 'The basis of JavaScript',
            description: 'Learn the basic of JavaScript',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/7a3e981b-8d06-4110-b375-25d53690695d?w=200&h=200',
            percent: 100,
            questions: 24,
          },
          {
            id: 3,
            title: 'The basis of Object Oriented Programming',
            description: 'Learn the basic of Object Oriented Programming',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/c098205b-98c5-4f86-bb67-9ec047a483f3?w=200&h=200',
            percent: 100,
            questions: 8,
          },
          {
            id: 4,
            title: 'The basis of JavaScript',
            description: 'Learn the basic of JavaScript',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/a2c54d45-a4d2-494c-8734-0ea27b4992e2?w=200&h=200',
            percent: 100,
            questions: 16,
          },
        ],
      },
      {
        id: 3,
        subjectName: 'Khoa học',
        quizzes: [
          {
            id: 1,
            title: 'The basis of NodeJS',
            description: 'Learn the basic of NodeJS',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/cb16fec9-951f-47ef-8f7c-afce45d579c8?w=200&h=200',
            percent: 60,
            questions: 10,
          },
          {
            id: 2,
            title: 'The basis of JavaScript',
            description: 'Learn the basic of JavaScript',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/7153bf8a-7e06-4ccd-afa1-0ad73aa36c40?w=200&h=200',
            percent: 100,
            questions: 24,
          },
          {
            id: 3,
            title: 'The basis of Object Oriented Programming',
            description: 'Learn the basic of Object Oriented Programming',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/a52bc8a9-f786-4355-81c0-69b501bcb6cf?w=200&h=200',
            percent: 100,
            questions: 8,
          },
          {
            id: 4,
            title: 'The basis of JavaScript',
            description: 'Learn the basic of JavaScript',
            image:
              'https://quizizz.com/media/resource/gs/quizizz-media/quizzes/a2c54d45-a4d2-494c-8734-0ea27b4992e2?w=200&h=200',
            percent: 100,
            questions: 16,
          },
        ],
      },
    ],
    [],
  );
  return (
    <Flex vertical className="w-full" gap={24}>
      <RecentQuizList />
      {data.map((subject) => (
        <QuizListBySubject key={subject.id} subjectName={subject.subjectName} quizzes={subject.quizzes} />
      ))}
    </Flex>
  );
};

export default SubjectQuizSection;
