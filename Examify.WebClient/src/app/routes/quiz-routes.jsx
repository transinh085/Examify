const QuizRoutes = {
  path: 'create-quiz',
  lazy: async () => {
    const CreateQuizPage = await import('../pages/quiz/create-quiz');
    return { Component: CreateQuizPage.default };
  },
};

export default QuizRoutes;
