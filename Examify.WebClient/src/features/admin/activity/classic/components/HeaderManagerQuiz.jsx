import { Button, Flex, Space, Layout } from 'antd';
import React from 'react';
import { FireOutlined, SoundFilled } from '@ant-design/icons';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import FullScreenButton from '~/features/admin/activity/classic/components/FullScreenButton';

const { Header } = Layout;

const HeaderManagerQuiz = () => {
  const { isPlayingSound, toggleSound, setOpenModalEnd } = useManagerQuizStore();

  const handleOpenModalEnd = () => {
    setOpenModalEnd(true);
  };

  return (
    <Header className="sticky top-0 z-10 bg-ds-dark-500 bg-opacity-50 px-4 border-b border-white/30 mb-6">
      <Flex className="items-center h-full max-w-8xl mx-auto" justify="space-between">
        <h4 className="text-white font-bold text-3xl">Examify</h4>
        <Space size="small">
          <Button type="primary" icon={<FireOutlined />} className="bg-ds-light-500-20" />
          <Button
            type="primary"
            icon={isPlayingSound ? <SoundFilled className="text-white" /> : <SoundFilled className="text-white" />}
            className="bg-ds-light-500-20"
            onClick={toggleSound}
          />
          <FullScreenButton />
          <div className="w-[1px] bg-white h-6 mx-2" />
          <Button color="danger" variant="solid" className="text-lg rounded-sm" onClick={handleOpenModalEnd}>
            End
          </Button>
        </Space>
      </Flex>
    </Header>
  );
};

export default HeaderManagerQuiz;
