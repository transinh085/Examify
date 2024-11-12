import { ConfigProvider, Grid, Menu } from 'antd';
import { Footer as FooterAnt } from 'antd/es/layout/layout';
import { useCallback, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { adminMenu } from '~/config/menu';

const FooterAdmin = () => {
  const breakpoint = Grid.useBreakpoint();
  const isMobile = typeof breakpoint.lg === 'undefined' ? false : !breakpoint.lg;
  const navigate = useNavigate();

  const handleMenuClick = useCallback(
    (e) => {
      navigate(e.item.props.path);
    },
    [isMobile, navigate],
  );
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
  return (
    <>
      {isMobile ? (
        <FooterAnt className="sticky bottom-0 z-50">
          <ConfigProvider
            theme={{
              token: {
                controlHeight: 32,
              },
            }}
          >
            <Menu
              mode="horizontal"
              theme={'light'}
              selectedKeys={selectedKeys}
              items={adminMenu}
              rootClassName="!border-none flex"
              onClick={handleMenuClick}
            />
          </ConfigProvider>
        </FooterAnt>
      ) : (
        <FooterAnt className="text-center">Copyright © {new Date().getFullYear()} Examify</FooterAnt>
      )}
    </>
  );
};

export default FooterAdmin;
