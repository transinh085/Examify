import { DatePicker, Flex, Form, Input, message, Modal, Switch, TimePicker } from 'antd';
import { useForm } from 'antd/es/form/Form';
import dayjs from 'dayjs';
import { useEffect, useState } from 'react';
import { useUpdateQuizNew } from '~/features/quiz/api/quizzes/update-quiz-modal';

const SettingModal = ({ id, data, open, onCancel, code, randomQuestions, randomOptions, startTime, endTime }) => {
  const [form] = useForm();
  const [isSwitchOn, setIsSwitchOn] = useState([
    { isOn: false }, // Switch 0 - Start Time
    { isOn: false }, // Switch 1 - Deadline
    { isOn: false }, // Switch 2 - Shuffle questions
    { isOn: false }, // Switch 3 - Shuffle answer options
  ]);

  const handleSwitchChange = (index, checked) => {
    const updatedSwitchStates = [...isSwitchOn];
    updatedSwitchStates[index].isOn = checked;
    setIsSwitchOn(updatedSwitchStates);
  };
  useEffect(() => {
    handleSwitchChange(2, randomQuestions); // Update shuffle questions switch
    handleSwitchChange(3, randomOptions); // Update shuffle options switch
    handleSwitchChange(0, startTime != null); // Update start time switch
    handleSwitchChange(1, endTime != null); // Update end time switch
  }, [randomQuestions, randomOptions, startTime, endTime]);

  const submitDateTime = (date, time) => {
    const combinedDateTime = dayjs(date).hour(dayjs(time).hour()).minute(dayjs(time).minute()).second(0);
    return combinedDateTime.toISOString().toString(); // Format as ISO 8601
  };

  const updateQuizNewMutation = useUpdateQuizNew({
    mutationConfig: {
      onSuccess: () => {
        onCancel();
        message.success('Quiz updated successfully');
      },
      onError: (error) => {
        message.error(error.message);
      },
    },
  });

  const handleSubmit = (values) => {
    // Process startTime and endTime. If they're missing, return null.
    const startTime = submitDateTime(values.startDate, values.startTime);
    const endTime = submitDateTime(values.endDate, values.endTime);

    console.log(
      'Quiz ID:',
      id,
      '\nStart Time:',
      startTime,
      '\nEnd Time:',
      endTime,
      '\nRandom Questions Enabled:',
      isSwitchOn[2].isOn,
      '\nRandom Options Enabled:',
      isSwitchOn[3].isOn,
    );
    const data = {
      startTime: startTime,
      endTime: endTime,
      randomQuestions: isSwitchOn[2].isOn,
      randomOptions: isSwitchOn[3].isOn,
    };

    // Only update quiz if startTime and endTime are valid (i.e., not null)
    updateQuizNewMutation.mutate({
      id: id,
      data: data,
    });
  };

  return (
    <Modal open={open} onCancel={onCancel} width={600} title={data} onOk={form.submit} destroyOnClose centered>
      <Form
        form={form}
        layout="horizontal"
        initialValues={{
          code: code,
          randomQuestions: randomQuestions,
          randomOptions: randomOptions,
          startDate: startTime ? dayjs(startTime) : null,
          startTimePicker: startTime ? dayjs(startTime) : null,
          endDate: endTime ? dayjs(endTime) : null,
          endTimePicker: endTime ? dayjs(endTime) : null,
        }}
        onFinish={handleSubmit}
      >
        <Form.Item label="Code to join" name="code" rules={[{ required: true, message: 'Code is required' }]}>
          <Input placeholder="123456" />
        </Form.Item>
        <Form.Item name="startTime">
          <Flex justify="space-between" align="center">
            <span>Start Time</span>
            <Switch checked={isSwitchOn[0].isOn} onChange={(checked) => handleSwitchChange(0, checked)} />
          </Flex>
          {isSwitchOn[0].isOn && (
            <div className="mt-4 space-y-2">
              <Flex className="space-x-2">
                <Form.Item name="startDate" noStyle>
                  <DatePicker className="w-full" disabled={!isSwitchOn[0].isOn} />
                </Form.Item>
                <Form.Item name="startTimePicker" noStyle>
                  <TimePicker className="w-full" disabled={!isSwitchOn[0].isOn} format="HH:mm" />
                </Form.Item>
              </Flex>
            </div>
          )}
        </Form.Item>
        <Form.Item name="endTime">
          <Flex justify="space-between" align="center">
            <span>End Time</span>
            <Switch checked={isSwitchOn[1].isOn} onChange={(checked) => handleSwitchChange(1, checked)} />
          </Flex>
          {isSwitchOn[1].isOn && (
            <div className="mt-4 space-y-2">
              <Flex className="space-x-2">
                <Form.Item name="endDate" noStyle>
                  <DatePicker className="w-full" disabled={!isSwitchOn[1].isOn} />
                </Form.Item>
                <Form.Item name="endTimePicker" noStyle>
                  <TimePicker className="w-full" disabled={!isSwitchOn[1].isOn} format="HH:mm" />
                </Form.Item>
              </Flex>
            </div>
          )}
        </Form.Item>
        <Form.Item name="randomQuestions">
          <Flex justify="space-between" align="center">
            <span>Random Questions</span>
            <Switch checked={isSwitchOn[2].isOn} onChange={(checked) => handleSwitchChange(2, checked)} />
          </Flex>
        </Form.Item>
        <Form.Item name="randomOptions">
          <Flex justify="space-between" align="center">
            <span>Random Options</span>
            <Switch checked={isSwitchOn[3].isOn} onChange={(checked) => handleSwitchChange(3, checked)} />
          </Flex>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default SettingModal;
