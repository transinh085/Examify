export const MOCK_QUIZ = {
  id: 1,
  name: 'Javascript Quiz',
  use_timer: true,
  questions: [
    {
      id: 0,
      question: 'What is your favorite programming language?',
      type: 'SINGLE_CHOICE',
      duration: 10,
      options: [
        {
          id: 1,
          content: 'Javascript',
          isCorrect: false,
        },
        {
          id: 2,
          content: 'Java',
          isCorrect: false,
        },
        {
          id: 3,
          content: 'Python',
          isCorrect: true,
        },
        {
          id: 4,
          content: 'C#',
          isCorrect: false,
        },
      ],
    },
    {
      id: 1,
      question: 'Which is new features in ES6?',
      type: 'MULTIPLE_CHOICE',
      duration: 60,
      options: [
        {
          id: 1,
          content: 'arrow function',
          isCorrect: true,
        },
        {
          id: 2,
          content: 'destructuring',
          isCorrect: true,
        },
        {
          id: 3,
          content: 'rest parameter',
          isCorrect: true,
        },
        {
          id: 4,
          content: 'spread operator',
          isCorrect: true,
        },
      ],
    },

    {
      id: 2,
      question: 'What is your favorite backend framework?',
      type: 'SINGLE_CHOICE',
      duration: 100,
      options: [
        {
          id: 1,
          content: 'NestJS',
          isCorrect: false,
        },
        {
          id: 2,
          content: 'Spring Boot',
          isCorrect: false,
        },
        {
          id: 3,
          content: 'Django',
          isCorrect: true,
        },
        {
          id: 4,
          content: '.NET Core',
          isCorrect: false,
        },
      ],
    },
    {
      id: 3,
      question: 'How to print 2 in the console in Python',
      type: 'MULTIPLE_CHOICE',
      duration: 100,
      options: [
        {
          id: 1,
          content: 'console.log(2)',
          isCorrect: false,
        },
        {
          id: 2,
          content: 'print(2)',
          isCorrect: true,
        },
        {
          id: 3,
          content: 'print 2',
          isCorrect: false,
        },
        {
          id: 4,
          content: 'System.out.println(2)',
          isCorrect: false,
        },
      ],
    },
    {
      id: 4,
      question: 'I in SOLID stands for?',
      type: 'MULTIPLE_CHOICE',
      duration: 100,
      options: [
        {
          id: 1,
          content: 'Interface Segregation Principle',
          isCorrect: true,
        },
        {
          id: 2,
          content: 'Single Responsibility Principle',
          isCorrect: false,
        },
        {
          id: 3,
          content: 'Open/Closed Principle',
          isCorrect: false,
        },
        {
          id: 4,
          content: 'Liskov Substitution Principle',
          isCorrect: false,
        },
      ],
    },
    {
      id: 5,
      question: 'Which is new features in ES6?',
      type: 'MULTIPLE_CHOICE',
      duration: 100,
      options: [
        {
          id: 1,
          content: 'arrow function',
          isCorrect: true,
        },
        {
          id: 2,
          content: 'destructuring',
          isCorrect: true,
        },
        {
          id: 3,
          content: 'rest parameter',
          isCorrect: true,
        },
        {
          id: 4,
          content: 'spread operator',
          isCorrect: true,
        },
      ],
    },
  ],
};
