import { SettingOutlined } from '@ant-design/icons';
import { Button, Col, Flex, Row, Space } from 'antd';
import { useEffect, useState } from 'react';
import { CountdownCircleTimer } from 'react-countdown-circle-timer';
import FullScreenButton from '~/features/do-quiz/components/FullScreenButton';
import Option from '~/features/do-quiz/components/Option';
import SettingDrawer from '~/features/do-quiz/components/SettingDrawer';
import { triggerConfetti } from '~/features/do-quiz/utils/helpers';
import lodash from 'lodash';
import { useParams } from 'react-router-dom';
import { MOCK_QUIZ } from '~/__mock__/__quiz__';
import { QUESTION_TYPE } from '~/config/enums';
import BackgroundAudio from '~/features/do-quiz/components/BackgroundAudio';
import CountUpSection from '~/features/do-quiz/components/CountUpSection';
import GameFooter from '~/features/do-quiz/components/GameFooter';
import useNumberKeyPress from '~/hooks/useNumberKeyPress';
import useDoQuizStore from '~/stores/do-quiz-store';
import MyQuizResult from '~/features/do-quiz/components/MyQuizResult';
import { useGetQuizResult } from '~/features/do-quiz/api/get-quiz-result';

const DoQuizPage = () => {
  const { result_id } = useParams();

  const {
    isFinished,
    useTimer,
    questions,
    waitingDuration,
    setIsFinished,
    setWaitingDuration,
    currentQuestion,
    initDoQuizStore,
    selectedOptions,
    setSelectedOptions,
    nextQuestion,
    addSelectedOption,
    removeSelectedOption,
  } = useDoQuizStore();

  const { data } = useGetQuizResult({ id: result_id });

  const [isOpenSettings, setIsOpenSettings] = useState(false);
  const [questionDuration, setQuestionDuration] = useState(0);

  useEffect(() => {
    initDoQuizStore({ useTimer: MOCK_QUIZ.use_timer, questions: MOCK_QUIZ.questions });
    setQuestionDuration(MOCK_QUIZ.questions?.[0]?.duration);
  }, [initDoQuizStore, setQuestionDuration]);

  useNumberKeyPress((key) => {
    const option = questions?.[currentQuestion]?.options?.[key - 1];
    if (!option) return;

    handleChooseOption(option.id);
  });

  const handleSubmitAnswer = (yourAnswers) => {
    const correctOptionsIds = questions[currentQuestion]?.options
      .filter((option) => option.isCorrect)
      .map((option) => option.id);
    1;

    if (lodash.isEqual(correctOptionsIds.sort(), yourAnswers.sort())) {
      triggerConfetti();
    }
    setWaitingDuration(3);
    setQuestionDuration(0);
    // call api here
    console.log('call api with data', {
      question_id: questions[currentQuestion]?.id,
      yourAnswers,
    });
  };

  const handleChooseOption = (optionId) => {
    if (waitingDuration) return;

    if (selectedOptions?.includes(optionId)) {
      removeSelectedOption(optionId);
      return;
    }
    addSelectedOption(optionId);
    if (questions?.[currentQuestion]?.type === QUESTION_TYPE.SINGLE_CHOICE) {
      handleSubmitAnswer([...selectedOptions, optionId]);
    }
  };

  const handleSubmitMultipleChoice = () => {
    handleSubmitAnswer(selectedOptions);
  };

  const handleNextQuestion = () => {
    if (currentQuestion === questions.length - 1) {
      // trigger completed game
      setIsFinished(true);
      return;
    }
    setQuestionDuration(questions[currentQuestion + 1]?.duration);
    nextQuestion();
    setSelectedOptions([]);
    setWaitingDuration(0);
  };

  if (isFinished) {
    return <MyQuizResult />;
  }

  return (
    <Flex vertical justify="space-between" className="w-full h-full text-white">
      <Flex justify="space-between" align="start" className="p-4">
        <CountUpSection />
        <div className="bg-[#3e084a] md:text-base lg:text-lg font-semibold py-2 px-4 rounded-lg text-center">
          TypeScript Basic Test {result_id} {questionDuration}
        </div>
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
          className="bg-[#2a0830] rounded-full py-4 px-12 lg:py-10 lg:px-12 lg:min-w-[800px] relative"
        >
          <div className="bg-[#2a0830] absolute top-0 left-[50%] border border-[#333] rounded-full px-8 py-1 translate-x-[-50%] translate-y-[-50%]">
            {currentQuestion + 1}/{questions.length}
          </div>
          <h1 className="text-lg lg:text-2xl font-semibold text-center">{questions?.[currentQuestion]?.question}</h1>
          {waitingDuration > 0 && (
            <CountdownCircleTimer
              isPlaying
              duration={waitingDuration}
              colors="#00a2ae"
              trailColor="#d9d9d9"
              onComplete={handleNextQuestion}
              size={50}
              strokeWidth={6}
            >
              {({ remainingTime }) => <p>{remainingTime}s</p>}
            </CountdownCircleTimer>
          )}
          {useTimer && questionDuration > 0 && (
            <CountdownCircleTimer
              isPlaying
              duration={questionDuration}
              colors="#00a2ae"
              trailColor="#d9d9d9"
              onComplete={handleNextQuestion}
              size={50}
              strokeWidth={6}
            >
              {({ remainingTime }) => <p>{remainingTime}s</p>}
            </CountdownCircleTimer>
          )}
        </Flex>
        <Row gutter={[24, 24]} className="w-full p-2 lg:p-4">
          {questions?.[currentQuestion]?.options?.map((option, index) => (
            <Col key={option.id} xs={24} sm={12} lg={6}>
              <Option
                type={questions?.[currentQuestion]?.type}
                number={index + 1}
                {...option}
                handleSelect={() => {
                  handleChooseOption(option?.id);
                }}
              />
            </Col>
          ))}
        </Row>
      </Flex>
      <GameFooter handleSubmit={handleSubmitMultipleChoice} />
      <SettingDrawer open={isOpenSettings} setOpen={setIsOpenSettings} />
      <BackgroundAudio />
    </Flex>
  );
};

export default DoQuizPage;
