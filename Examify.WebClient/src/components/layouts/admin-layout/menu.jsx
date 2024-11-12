import { Button, ConfigProvider, Flex, Menu, message } from 'antd';
import SimpleBar from 'simplebar-react';
import 'simplebar-react/dist/simplebar.min.css';
import { useLocation, useNavigate } from 'react-router-dom';
import { useCallback, useMemo } from 'react';
import { adminMenu } from '~/config/menu';
import { PlusOutlined } from '@ant-design/icons';
import { useCreateQuiz } from '~/features/quiz/api/quizzes/create-quiz';

const MenuCustom = ({ isMobile, onClose, theme = 'light', siderVisible, ...props }) => {
  const navigate = useNavigate();
  const location = useLocation();
  const createQuizMutation = useCreateQuiz({
    mutationConfig: {
      onSuccess: (data) => {
        console.log('data', data);
        navigate(`/admin/quiz/${data.id}`);
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const createQuizHandler = () => {
    createQuizMutation.mutate();
  };

  const findItemByPath = useCallback((items, path) => {
    for (const item of items) {
      if (item.path && item.path.includes(path)) {
        return item;
      }
      if (item.children) {
        const child = findItemByPath(item.children, path);
        if (child) return child;
      }
    }
  }, []);

  const selectedKeys = useMemo(() => {
    const item = findItemByPath(adminMenu, location.pathname);
    return item ? [item.key] : [];
  }, [location.pathname, findItemByPath]);

  const handleMenuClick = useCallback(
    (e) => {
      if (isMobile) {
        onClose();
      }
      navigate(e.item.props.path);
    },
    [isMobile, onClose, navigate],
  );

  return (
    <ConfigProvider
      theme={{
        token: {
          controlHeight: 32,
        },
      }}
    >
      <SimpleBar style={{ maxHeight: 'calc(100vh - 80px)' }}>
        <Flex justify="center" className={`h-[50px] w-full p-1`}>
          <Button
            onClick={createQuizHandler}
            icon={<PlusOutlined />}
            style={{ minWidth: '100%' }}
            className="w-full h-full px-4 py-2 text-base"
            type="primary"
            iconPosition={!siderVisible ? 'start' : undefined}
            loading={createQuizMutation.isPending}
          >
            {!siderVisible && 'Create'}
          </Button>
        </Flex>
        <Menu
          mode="vertical"
          theme={theme}
          selectedKeys={selectedKeys}
          items={adminMenu}
          rootClassName="!border-none w-full"
          onClick={handleMenuClick}
          {...props}
        />
      </SimpleBar>
    </ConfigProvider>
  );
};

export default MenuCustom;
