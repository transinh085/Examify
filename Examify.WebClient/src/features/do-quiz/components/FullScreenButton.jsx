import { Button } from 'antd';
import { useState } from 'react';
import { CompressOutlined, ExpandOutlined } from '@ant-design/icons';

const FullScreenButton = () => {
  const [isFullScreen, setIsFullScreen] = useState(false);

  const toggleFullScreen = () => {
    if (!document.fullscreenElement) {
      document.documentElement.requestFullscreen();
      setIsFullScreen(true);
    } else if (document.exitFullscreen) {
      document.exitFullscreen();
      setIsFullScreen(false);
    }
  };

  return (
    <Button
      type="primary"
      shape="default"
      icon={isFullScreen ? <CompressOutlined /> : <ExpandOutlined />}
      className="!bg-[#6d387d] !hover:bg-[red]"
      onClick={toggleFullScreen}
    />
  );
};

export default FullScreenButton;
