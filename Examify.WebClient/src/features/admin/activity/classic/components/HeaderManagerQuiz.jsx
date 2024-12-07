import { Button, Flex, Layout } from 'antd';
import { SoundFilled } from '@ant-design/icons';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import FullScreenButton from '~/features/admin/activity/classic/components/FullScreenButton';

const { Header } = Layout;

const HeaderManagerQuiz = () => {
  const { isPlayingSound, toggleSound, setOpenModalEnd } = useManagerQuizStore();

  const handleOpenModalEnd = () => {
    setOpenModalEnd(true);
  };

  return (
    <Header className="sticky top-0 z-10 bg-ds-dark-500 bg-opacity-50 px-4 border-b border-white/30">
      <Flex className="items-center h-full max-w-8xl mx-auto" justify="space-between">
        <h4 className="text-white font-bold text-3xl">Examify</h4>
        <Flex gap={10}>
          <Button
            type="primary"
            icon={isPlayingSound ? <SoundFilled className="text-white" /> : <SoundFilled className="text-white" />}
            className="bg-ds-light-500-20"
            onClick={toggleSound}
          />
          <FullScreenButton />
          <div className="w-[1px] bg-white mx-2 block" />
          <Button color="danger" variant="solid" onClick={handleOpenModalEnd}>
            End
          </Button>
        </Flex>
      </Flex>
    </Header>
  );
};

export default HeaderManagerQuiz;
