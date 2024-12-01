const ManagaerQuizRoutes = {
  path: '/admin/activity/classic/:id',
  lazy: async () => {
    const ManagerQuizPage = await import('../pages/admin/activity/classic/[id]');
    return { Component: ManagerQuizPage.default };
  },
};

export default ManagaerQuizRoutes;
