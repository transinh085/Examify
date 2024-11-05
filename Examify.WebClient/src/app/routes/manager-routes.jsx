const ManagaerQuizRoutes = {
  path: '/manager-quiz', 
  lazy: async () => {
    const ManagerQuizPage = await import('../pages/admin/manager-quiz');
    return { Component: ManagerQuizPage.default };
  }
}

export default ManagaerQuizRoutes;