import { SettingOutlined } from '@ant-design/icons';
import { Avatar, Button, Col, Divider, Flex, Row, Space } from 'antd';
import { useEffect, useMemo, useState } from 'react';
import { CountdownCircleTimer } from 'react-countdown-circle-timer';
import { MOCK_QUESTIONS } from '~/features/do-quiz/__mock__/data';
import FullScreenButton from '~/features/do-quiz/components/FullScreenButton';
import Option from '~/features/do-quiz/components/Option';
import SettingDrawer from '~/features/do-quiz/components/SettingDrawer';
import { triggerConfetti } from '~/features/do-quiz/utils/helpers';

const DoQuizPage = () => {
  const [isOpenSettings, setIsOpenSettings] = useState(false);
  const [currentQuestion, setCurrentQuestion] = useState(0);
  const [countdown, setCountdown] = useState(null);

  const questions = useMemo(() => MOCK_QUESTIONS, []);

  const handleChooseOption = (isCorrect) => {
    if (isCorrect) {
      triggerConfetti();
    }
    setCountdown(5);
  };

  return (
    <Flex vertical justify="space-between" className="w-full h-full text-white">
      <Flex justify="space-between" align="start" className="p-4">
        <CountDownSection />
        <div className="bg-[#3e084a] text-lg font-semibold py-2 px-4 rounded-lg">TypeScript Basic Test 1</div>
        <Space size={20}>
          <Button
            type="primary"
            shape="default"
            icon={<SettingOutlined />}
            className="!bg-[#6d387d] !hover:bg-[red]"
            onClick={() => {
              setIsOpenSettings(true);
            }}
          />
          <FullScreenButton />
        </Space>
      </Flex>
      <Flex vertical align="center" justify="center" gap={48} className="w-full">
        <Flex
          align="center"
          justify="center"
          gap={20}
          className="bg-[#2a0830] rounded-full py-10 px-12 min-w-[800px] relative"
        >
          <div className="bg-[#2a0830] absolute top-0 left-[50%] border border-[#333] rounded-full px-8 py-1 translate-x-[-50%] translate-y-[-50%]">
            {currentQuestion + 1}/{questions.length}
          </div>
          <h1 className="text-2xl font-semibold text-center">{questions[currentQuestion].question}</h1>
          {countdown > 0 && (
            <CountdownCircleTimer
              isPlaying
              duration={countdown}
              colors="#00a2ae"
              trailColor="#d9d9d9"
              onComplete={() => {
                setCurrentQuestion((prev) => (prev + 1 >= questions.length ? 0 : prev + 1));
                setCountdown(0);
              }}
              size={50}
              strokeWidth={6}
            >
              {({ remainingTime }) => <p>{remainingTime}s</p>}
            </CountdownCircleTimer>
          )}
        </Flex>
        <Row gutter={[24, 24]} className="w-full p-4 ">
          {questions[currentQuestion].options.map((option, index) => (
            <Col key={option.id} span={6}>
              <Option number={index + 1} content={option.content} {...option} handleSelect={handleChooseOption} />
            </Col>
          ))}
        </Row>
      </Flex>
      <Flex justify="space-between" className="bg-[#3e084a] px-4 py-3">
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
          <Button>Submit</Button>
        </Space>
      </Flex>

      <SettingDrawer open={isOpenSettings} setOpen={setIsOpenSettings} />
    </Flex>
  );
};

const CountDownSection = () => {
  const [timeLeft, setTimeLeft] = useState(600);

  useEffect(() => {
    if (timeLeft === 0) return;

    const timer = setInterval(() => {
      setTimeLeft((prevTime) => prevTime - 1);
    }, 1000);

    return () => clearInterval(timer);
  }, [timeLeft]);

  const minutes = Math.floor(timeLeft / 60);
  const seconds = timeLeft % 60;
  return (
    <div className="bg-[#3e084a] p-4 rounded-lg">
      <h1 className="text-3xl">{`${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`}</h1>
    </div>
  );
};
export default DoQuizPage;
