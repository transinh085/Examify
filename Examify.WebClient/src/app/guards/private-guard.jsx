import { Navigate, useLocation } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';

const PrivateGuard = ({ children }) => {
  const location = useLocation();
  const { isAuthenticated } = useAuthStore();
  return isAuthenticated ? children : <Navigate to={`/auth/login?redirect=${location.pathname}`} />;
};

export default PrivateGuard;
