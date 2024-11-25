import { useQueryClient } from '@tanstack/react-query';
import { Button, DatePicker, Flex, message, Modal, Switch, TimePicker, Typography } from 'antd';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useCreateQuiz } from '~/features/quiz/api/quizzes/create-quiz';
import TestCard from '~/features/quiz/components/admin/TestCard';
import dayjs from "dayjs";


const TabContent = ({ data }) => {
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [titleQuiz, setTitleQuiz] = useState("")
  const handleOk = () => {
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const createQuizMutation = useCreateQuiz({
    mutationConfig: {
      onSuccess: (data) => {
        queryClient.invalidateQueries('quiz-user');
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
  if (data.length === 0)
    return (
      <Flex className="space-y-3" vertical>
        <Flex justify="center">
          <img className="w-[200px] h-[200px]" src="https://cf.quizizz.com/image/emptystate-letscreate-v5.png" alt="" />
        </Flex>
        <Typography.Text className="text-center font-bold">Create your first quiz or lesson</Typography.Text>
        <Typography.Text className="text-center">
          Pull in questions from the Quizizz library or make your own. It’s quick and easy!
        </Typography.Text>
        <Flex justify="center">
          <Button
            loading={createQuizMutation.isPending}
            type="primary"
            className="font-bold text-lg"
            onClick={createQuizHandler}
            size="large"
          >
            Create a quiz
          </Button>
        </Flex>
      </Flex>
    );
  const [isSwitchOn, setIsSwitchOn] = useState([
    { isOn: false }, // Switch 0 - Start Time
    { isOn: false }, // Switch 1 - Deadline
    { isOn: false }, // Switch 2 - Shuffle questions
    { isOn: false }, // Switch 3 - Shuffle answer options
    { isOn: false }, // Switch 4 - Visible
  ]);

  const [selectedDateStart, setSelectedDateStart] = useState(null);
  const [selectedTimeStart, setSelectedTimeStart] = useState(null);
  const [startStatus, setStartStatus] = useState("");

  const [selectedDateEnd, setSelectedDateEnd] = useState(null);
  const [selectedTimeEnd, setSelectedTimeEnd] = useState(null);
  const [endStatus, setEndStatus] = useState("");

  // Xử lý bật/tắt switch
  const handleSwitchChange = (index, checked) => {
    const updatedSwitchStates = [...isSwitchOn];
    updatedSwitchStates[index].isOn = checked;
    setIsSwitchOn(updatedSwitchStates);

    // Reset giá trị nếu Switch tắt
    if (!checked) {
      if (index === 0) {
        setSelectedTimeEnd(null);
        setSelectedTimeStart(null);
        setStartStatus("");
      } else if (index === 1) {
        setSelectedDateEnd(null);
        setSelectedTimeEnd(null);
        setEndStatus("");
      }
    }
  };

  // Xử lý thay đổi Start Time
  const handleStartTimeChange = (selectedDateStart, selectedTimeStart) => {
    if (selectedDateStart && selectedTimeStart) {
      const selectedDateTime = dayjs(selectedDateStart)
        .hour(selectedTimeStart.hour())
        .minute(selectedTimeStart.minute());
      const now = dayjs();

      // Kiểm tra Start Time có lớn hơn thời gian hiện tại không
      if (selectedDateTime.isBefore(now)) {
        setStartStatus("error");
        message.error("Thời gian bắt đầu phải lớn hơn thời gian hiện tại", 10)
      } else {
        setStartStatus("");
      }
    }
  };

  // Xử lý thay đổi Deadline
  const handleDeadlineChange = (date, time) => {
    if (date && time) {
      const selectedStartDateTime = selectedDateStart
        ? dayjs(selectedDateStart)
          .hour(selectedTimeStart?.hour() || 0)
          .minute(selectedTimeStart?.minute() || 0)
        : null;

      const selectedDeadline = dayjs(date)
        .hour(time.hour())
        .minute(time.minute());

      // Kiểm tra nếu Deadline nhỏ hơn Start Time
      if (selectedStartDateTime && selectedDeadline.isBefore(selectedStartDateTime)) {
        setEndStatus("error")
        message.error("Deadline must be greater than or equal to Start time!");
        setSelectedDateEnd(null);
        setSelectedTimeEnd(null);
      } else {
        setEndStatus("")
      }
    }
  };

  const calculateTimeDifference = () => {
    if (selectedDateStart && selectedTimeStart) {
      const selectedDateTime = dayjs(selectedDateStart)
        .hour(selectedTimeStart.hour())
        .minute(selectedTimeStart.minute());
      const now = dayjs();
      const diff = selectedDateTime.diff(now, "minute");
      return diff > 0 ? `${diff} minutes from now` : "Time has passed";
    }
    return null;
  };

  useEffect(() => {
    calculateTimeDifference();
    handleStartTimeChange(selectedDateStart, selectedTimeStart)
  }, [selectedDateStart, selectedTimeStart])
  useEffect(() => {
    handleDeadlineChange(selectedDateEnd, selectedTimeEnd)
  }, [selectedDateEnd, selectedTimeEnd])

  return (
    <Flex className="space-y-2" vertical>
      {data.map((item, index) => (
        <TestCard
          key={index}
          id={item.id}
          imgSrc={item.cover}
          title={item.title}
          author={item.owner}
          questions={item.questions}
          date={item.createdDate}
          tags={item.gradeName}
          gradeName={item.gradeName}
          languageName={item.languageName}
          setIsModalVisible={setIsModalVisible}
          setTitleQuiz={setTitleQuiz}
        />
      ))}
      <Modal
        title={titleQuiz}
        open={isModalVisible}
        onOk={handleOk}
        onCancel={handleCancel}
      >
        <div className="p-4">
          {/* Switch 0 - Start Time */}
          <div className="mb-6">
            <Flex justify='space-between' align='center'>
              <span>Set a start time for activity</span>
              <Switch
                checked={isSwitchOn[0].isOn}
                onChange={(checked) => handleSwitchChange(0, checked)}
                className="mr-2"
              />
            </Flex>

            {isSwitchOn[0].isOn && (
              <div className="mt-4 space-y-2">
                <div className="flex space-x-2">
                  <DatePicker
                    onChange={(date) =>
                      setSelectedDateENd(date)
                    }
                    disabled={!isSwitchOn[0].isOn}
                    status={startStatus}
                    className="w-full"
                  />
                  <TimePicker
                    use12Hours
                    format="hh:mm A"
                    onChange={(time) =>
                      setSelectedTimeEnd(time)
                    }
                    disabled={!isSwitchOn[0].isOn}
                    className="w-full"
                    status={startStatus}
                  />
                </div>
                <div className="text-gray-600">
                  {calculateTimeDifference(selectedDateStart, selectedTimeStart)}
                </div>
              </div>
            )}
          </div>

          {/* Switch 1 - Deadline */}
          <div className="mb-6">
            <Flex justify='space-between' align='center'>
              <span>Deadline</span>
              <Switch
                checked={isSwitchOn[1].isOn}
                onChange={(checked) => handleSwitchChange(1, checked)}
                className="mr-2"
              />
            </Flex>

            {isSwitchOn[1].isOn && (
              <div className="mt-4 space-y-2">
                <div className="flex space-x-2">
                  <DatePicker
                    onChange={(date) =>
                      setSelectedDateEnd(date)
                    }
                    disabled={!isSwitchOn[1].isOn}
                    status={endStatus}
                    className="w-full"
                  />
                  <TimePicker
                    use12Hours
                    format="hh:mm A"
                    onChange={(time) =>
                      setSelectedTimeEnd(time)
                    }
                    disabled={!isSwitchOn[1].isOn}
                    className="w-full"
                    status={endStatus}
                  />
                </div>
              </div>
            )}
          </div>

          <div className="mb-6">
            <Flex justify='space-between' align='center'>
              <span>Shuffle questions</span>
              <Switch
                checked={isSwitchOn[2].isOn}
                onChange={(checked) => handleSwitchChange(2, checked)}
                className="mr-2"
              />
            </Flex>
          </div>
          <div className="mb-6">
            <Flex justify='space-between' align='center'>
              <span>Shuffle answer options</span>
              <Switch
                checked={isSwitchOn[3].isOn}
                onChange={(checked) => handleSwitchChange(3, checked)}
                className="mr-2"
              />
            </Flex>
          </div>
          <div>
            <Flex justify='space-between' align='center'>
              <span>Visible</span>
              <Switch
                checked={isSwitchOn[4].isOn}
                onChange={(checked) => handleSwitchChange(4, checked)}
                className="mr-2"
              />
            </Flex>
          </div>
        </div>
      </Modal>
    </Flex>
  );
};

export default TabContent;
