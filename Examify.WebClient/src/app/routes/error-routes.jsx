const ErrorRoutes = {
  path: '*',
  lazy: async () => {
    let NotFoundRoute = await import('../pages/not-found');
    return { Component: NotFoundRoute.default };
  },
};

export default ErrorRoutes;
