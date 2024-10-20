import { Navigate } from 'react-router-dom';
import { USER_ROLES } from '~/config/constants';
import useAuthStore from '~/stores/auth-store';

const AdminGuard = ({ children }) => {
  // const { user } = useAuthStore();
  // return user?.userRole === USER_ROLES.ADMIN ? children : <Navigate to="/auth/login" />;

  return children;
};

export default AdminGuard;
