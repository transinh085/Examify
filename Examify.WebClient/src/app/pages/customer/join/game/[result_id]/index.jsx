import { SettingOutlined } from '@ant-design/icons';
import { Button, Col, Flex, Row, Space } from 'antd';
import { useEffect, useState } from 'react';
import { CountdownCircleTimer } from 'react-countdown-circle-timer';
import FullScreenButton from '~/features/do-quiz/components/FullScreenButton';
import Option from '~/features/do-quiz/components/Option';
import SettingDrawer from '~/features/do-quiz/components/SettingDrawer';
import { triggerConfetti } from '~/features/do-quiz/utils/helpers';
import { useParams } from 'react-router-dom';
import { QUESTION_TYPE } from '~/config/enums';
import BackgroundAudio from '~/features/do-quiz/components/BackgroundAudio';
import CountUpSection from '~/features/do-quiz/components/CountUpSection';
import GameFooter from '~/features/do-quiz/components/GameFooter';
import useNumberKeyPress from '~/hooks/useNumberKeyPress';
import useDoQuizStore from '~/stores/do-quiz-store';
import MyQuizResult from '~/features/do-quiz/components/MyQuizResult';
import { useGetQuizResult } from '~/features/do-quiz/api/get-quiz-result';
import { useSubmitAnswersMutation } from '~/features/do-quiz/api/submit-answer';

const DoQuizPage = () => {
  const { result_id } = useParams();

  const {
    timeTaken,
    quiz,
    isFinished,
    questionResults,
    waitingDuration,
    setIsFinished,
    setWaitingDuration,
    currentQuestion,
    setCorrectOptions,
    initDoQuizStore,
    selectedOptions,
    setSelectedOptions,
    nextQuestion,
    addSelectedOption,
    removeSelectedOption,
  } = useDoQuizStore();

  const { data: quizResult, refetch } = useGetQuizResult(
    { id: result_id },
    {
      enabled: !!result_id,
      initialData: {
        quizSetting: {},
        quiz: {},
        questionResults: [],
      },
    },
  );

  const submitAnswersMutation = useSubmitAnswersMutation({
    mutationConfig: {},
  });

  const [isOpenSettings, setIsOpenSettings] = useState(false);
  const [questionDuration, setQuestionDuration] = useState(0);
  const [timeTakenOfCurrentQuestion, setTimeTakenOfCurrentQuestion] = useState(0);

  useEffect(() => {
    initDoQuizStore({
      quiz: quizResult?.quiz,
      questionResults: quizResult?.questionResults,
      currentQuestion: quizResult?.currentQuestion,
      timeTaken: quizResult?.timeTaken,
      totalPoints: quizResult?.totalPoints,
    });
    setQuestionDuration(quizResult?.questionResults?.[0]?.question?.duration);
  }, [initDoQuizStore, setQuestionDuration, quizResult]);

  // Count up time taken of the current question
  useEffect(() => {
    const timer = setInterval(() => {
      setTimeTakenOfCurrentQuestion(timeTakenOfCurrentQuestion + 1);
    }, 1000);

    return () => clearInterval(timer);
  }, [setTimeTakenOfCurrentQuestion, timeTakenOfCurrentQuestion]);

  useEffect(() => {
    setQuestionDuration(questionResults[currentQuestion]?.question?.duration);
  }, [setQuestionDuration, questionResults, currentQuestion]);

  useNumberKeyPress((key) => {
    const option = questionResults?.[currentQuestion]?.options?.[key - 1];
    if (!option) return;

    handleChooseOption(option.id);
  });

  const handleSubmitAnswer = async (yourAnswers) => {
    // call api to submit your answers

    const mutationResponse = await submitAnswersMutation.mutateAsync({
      Answers: yourAnswers,
      TimeTaken: timeTakenOfCurrentQuestion, // timeTaken of the current question
      TimeSpent: timeTaken, // timeTaken of the whole quiz
      questionResultId: questionResults[currentQuestion]?.id,
    });
    if (mutationResponse?.isCorrect) triggerConfetti();
    setCorrectOptions(mutationResponse?.correctOptions);
  };

  const handleChooseOption = (optionId) => {
    if (waitingDuration) return;

    if (selectedOptions?.includes(optionId)) {
      removeSelectedOption(optionId);
      return;
    }
    addSelectedOption(optionId);
    if (questionResults?.[currentQuestion]?.type === QUESTION_TYPE.SINGLE_CHOICE) {
      handleSubmitAnswer([...selectedOptions, optionId]);
      setWaitingDuration(3);
      setQuestionDuration(0);
    }
  };

  const handleSubmitMultipleChoice = () => {
    handleSubmitAnswer(selectedOptions);
    setWaitingDuration(3);
    setQuestionDuration(0);
  };

  const handleNextQuestion = () => {
    if (currentQuestion === questionResults.length - 1) {
      // trigger completed game
      refetch();
      setIsFinished(true);
      return;
    }
    nextQuestion();
    setSelectedOptions([]);
    setWaitingDuration(0);
    setTimeTakenOfCurrentQuestion(0);
  };

  console.log('timer', { questionDuration, timeTakenOfCurrentQuestion });

  if (isFinished) {
    return <MyQuizResult />;
  }

  return (
    <Flex vertical justify="space-between" className="w-full h-full text-white">
      <Flex justify="space-between" align="start" className="p-4">
        <CountUpSection />
        <div className="bg-[#3e084a] md:text-base lg:text-lg font-semibold py-2 px-4 rounded-lg text-center">
          {quiz?.title}
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
            {currentQuestion + 1}/{questionResults.length}
          </div>
          <h1 className="text-lg lg:text-2xl font-semibold text-center">
            {questionResults?.[currentQuestion]?.question?.content}
          </h1>
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
          {quiz?.useTimer && questionDuration > 0 && (
            <CountdownCircleTimer
              isPlaying
              duration={questionDuration}
              colors="#00a2ae"
              trailColor="#d9d9d9"
              onComplete={() => {
                handleSubmitAnswer(selectedOptions);
                handleNextQuestion();
              }}
              size={50}
              strokeWidth={6}
            >
              {({ remainingTime }) => <p>{remainingTime}s</p>}
            </CountdownCircleTimer>
          )}
        </Flex>
        <Row gutter={[24, 24]} className="w-full p-2 lg:p-4">
          {questionResults?.[currentQuestion]?.answerResults?.map((answerResult, index) => (
            <Col key={answerResult.id} xs={24} sm={12} lg={6}>
              <Option
                number={index + 1}
                {...answerResult}
                handleSelect={() => {
                  handleChooseOption(answerResult?.option?.id);
                }}
                pending={submitAnswersMutation.isPending}
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
