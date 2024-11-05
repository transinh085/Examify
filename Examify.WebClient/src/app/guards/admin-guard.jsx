import { Navigate } from "react-router-dom";
import { useGetSeft } from "~/features/auth/api/self";

const AdminGuard = ({ children }) => {
  const { isError } = useGetSeft();

  if (isError) {
    return <Navigate to="/auth/login" replace />;
  }

  return children;
};

export default AdminGuard;