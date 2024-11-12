import { Avatar, Card, Drawer, Space } from 'antd';

const SettingDrawer = ({ open, setOpen }) => {
  return (
    <Drawer
      placement={'top'}
      closable={false}
      onClose={() => {
        setOpen(false);
      }}
      open={open}
      styles={{
        body: {
          backgroundColor: 'black',
        },
      }}
    >
      <div className="max-w-[540px] mx-auto">
        <Space direction="vertical" size={20} className="w-full">
          <Card className="bg-[#1a1a1a] border-none">
            <Space>
              <Avatar size="large" src="https://avatars.githubusercontent.com/u/93178609?v=4" />
              <Space direction="vertical" size={0}>
                <h1 className="font-semibold text-white">Phat Le</h1>
                <p className="opacity-80 text-white">lequanphat@gmail.com</p>
              </Space>
            </Space>
          </Card>
        </Space>
      </div>
    </Drawer>
  );
};

export default SettingDrawer;
