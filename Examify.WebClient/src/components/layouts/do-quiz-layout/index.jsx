import { Outlet } from 'react-router-dom';

export default function DoQuizLayout() {
  return (
    <div
      className="w-[100vw] h-[100vh] bg-cover bg-center"
      style={{ backgroundImage: 'url(https://cf.quizizz.com/themes/v2/classic/bg_image.jpg)' }}
    >
      <Outlet />
    </div>
  );
}
