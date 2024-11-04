import { Navigate } from 'react-router-dom';
import useAuthStore from '~/stores/auth-store';

const PrivateGuard = ({ children }) => {
  const { isAuthenticated } = useAuthStore();
  return isAuthenticated ? children : <Navigate to="/" />;
};

export default PrivateGuard;
