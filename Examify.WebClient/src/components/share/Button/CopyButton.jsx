import { Button, message } from 'antd';
import { CopyFilled } from '@ant-design/icons';

const CopyButton = ({ text, type = 'primary', label = '', icon = <CopyFilled />, className = '', ...buttonProps }) => {
  const [messageApi, contextHolder] = message.useMessage();
  const handleCopy = () => {
    navigator.clipboard
      .writeText(text)
      .then(() => {
        messageApi.success('Copied to clipboard');
      })
      .catch((error) => {
        console.error('Failed to copy text:', error);
      });
  };

  return (
    <>
      {contextHolder}
      <Button
        type={type}
        icon={icon}
        onClick={handleCopy}
        className={`!bg-ds-light-500-20 ${className}`}
        {...buttonProps}
      >
        {label}
      </Button>
    </>
  );
};

export default CopyButton;
