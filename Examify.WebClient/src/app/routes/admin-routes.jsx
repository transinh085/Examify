<<<<<<< Updated upstream
=======
// import AdminGuard from '../guards/admin-guard';
>>>>>>> Stashed changes
import AdminLayout from '~/components/layouts/admin-layout';
import PrivateGuard from '../guards/private-guard';

// require authenticated to access admin routes
const AdminRoutes = {
  path: '/admin',
  element: (
<<<<<<< Updated upstream
    <PrivateGuard>
      <AdminLayout />
    </PrivateGuard>
=======
    // <AdminGuard>
      <AdminLayout />
    // </AdminGuard>
>>>>>>> Stashed changes
  ),
  children: [
    {
      path: '',
      lazy: async () => {
        const ExplorePage = await import('../pages/admin/explore');
        return { Component: ExplorePage.default };
      },
    },
    {
      path: 'my-library',
      lazy: async () => {
        const MyLibraryPage = await import('../pages/admin/mylibrary');
        return { Component: MyLibraryPage.default };
      },
    },
    {
      path: 'reports',
      lazy: async () => {
        const ReportPage = await import('../pages/admin/reports');
        return { Component: ReportPage.default };
      },
    },
    {
      path: 'settings',
      lazy: async () => {
        const SettingsPage = await import('../pages/admin/settings');
        return { Component: SettingsPage.default };
      },
    },
    {
      path: 'memes',
      lazy: async () => {
        const MemesPage = await import('../pages/admin/memes');
        return { Component: MemesPage.default };
      },
    },
    {
      path: 'collections',
      lazy: async () => {
        const CollectionsPage = await import('../pages/admin/collections');
        return { Component: CollectionsPage.default };
      },
    },
    {
      path: 'profile',
      lazy: async () => {
        const ProfilePage = await import('../pages/admin/profile');
        return { Component: ProfilePage.default };
      },
    },
  ],
};

export default AdminRoutes;
