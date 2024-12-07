import { Avatar, Button, Divider, Flex, Space } from 'antd';
import runningCatGift from '~/assets/images/running-cat.gif';
import { QUESTION_TYPE } from '~/config/enums';
import useDoQuizStore from '~/stores/do-quiz-store';

const GameFooter = ({ handleSubmit, loading }) => {
  const { questionResults, currentQuestion } = useDoQuizStore();
  return (
    <Flex justify="space-between" className="relative bg-[#3e084a] px-4 py-3">
      <div className="absolute top-0 right-0 translate-y-[-100%] animate-mewmew">
        <img src={runningCatGift} alt="" className="w-[40px] scale-x-[-1]" />
      </div>
      <Space>
        <Avatar size="large" src="https://avatars.githubusercontent.com/u/93178609?v=4" />
        <Space direction="vertical" size={0}>
          <h1 className="font-semibold">Phat Le</h1>
          <p className="opacity-80">lequanphat@gmail.com</p>
        </Space>
      </Space>

      <Space size={12}>
        <img
          src="https://cf.quizizz.com/game/img/powerups/icons/double-jeopardy.svg"
          alt=""
          className="w-[38px] h-[38px] border-2 border-green-400 rounded-full cursor-pointer"
        />
        <img
          src="https://cf.quizizz.com/game/img/powerups/icons/streak-booster.svg"
          alt=""
          className="w-[38px] h-[38px] border-2 border-orange-400 rounded-full cursor-pointer"
        />
        <img
          src="https://cf.quizizz.com/game/img/powerups/icons/2x.svg"
          alt=""
          className="w-[38px] h-[38px] border-2 border-purple-500 rounded-full cursor-pointer"
        />
        <Divider type="vertical" className="bg-gray-400 h-[34px]" />
        {(questionResults?.[currentQuestion]?.question?.type === QUESTION_TYPE.MULTIPLE_CHOICE ||
          questionResults?.[currentQuestion]?.question?.type === 'MultipleChoice') && (
          <Button onClick={handleSubmit} loading={loading}>
            Submit
          </Button>
        )}
      </Space>
    </Flex>
  );
};

export default GameFooter;
