const JoinRoutes = {
  path: '/join',
  lazy: async () => {
    const JoinPage = await import('../pages/customer/join');
    return { Component: JoinPage.default };
  }
}

export default JoinRoutes;

