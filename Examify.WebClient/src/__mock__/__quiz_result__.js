const MOCK_QUIZ_RESULT = {
  id: 1,
  currentQuestion: 0,
  timeSpent: 100, // 100s
  // ...
  question_results: [
    {
      id: 1,
      // ...
      question: {
        id: 1,
        content: '1+1=?',
        duration: 60, // 60s
        type: 'SINGLE_CHOICE', // MULTIPLE_CHOICE
        point: 10,
        options: [
          {
            id: 1,
            content: '2',
          },
        ],
      },
    },
    // ...
  ],
};

export { MOCK_QUIZ_RESULT };
