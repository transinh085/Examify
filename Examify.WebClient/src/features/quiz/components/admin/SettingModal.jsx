import { DatePicker, Flex, Form, Input, Modal, Switch, TimePicker } from 'antd';
import { useForm } from 'antd/es/form/Form';
import dayjs from 'dayjs';
import { useState } from 'react';

const SettingModal = ({ data, open, onCancel }) => {
  const [form] = useForm();
  const [isSwitchOn, setIsSwitchOn] = useState([
    { isOn: false }, // Switch 0 - Start Time
    { isOn: false }, // Switch 1 - Deadline
    { isOn: false }, // Switch 2 - Shuffle questions
    { isOn: false }, // Switch 3 - Shuffle answer options
    { isOn: false }, // Switch 4 - Visible
  ]);

  // Xử lý bật/tắt switch
  const handleSwitchChange = (index, checked) => {
    const updatedSwitchStates = [...isSwitchOn];
    updatedSwitchStates[index].isOn = checked;
    setIsSwitchOn(updatedSwitchStates);
  };
  // const calculateTimeDifference = (selectedDateStart, selectedTimeStart) => {
  //   if (selectedDateStart && selectedTimeStart) {
  //     const selectedDateTime = dayjs(selectedDateStart)
  //       .hour(selectedTimeStart.hour())
  //       .minute(selectedTimeStart.minute());
  //     const now = dayjs();
  //     const diff = selectedDateTime.diff(now, 'minute');
  //     return diff > 0 ? `${diff} minutes from now` : 'Time has passed';
  //   }
  //   return null;
  // };
  return (
    <Modal open={open} onCancel={onCancel} width={600} title={data} onOk={form.submit} destroyOnClose centered>
      <Form form={form} layout="horizontal" variant="filled">
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
                <DatePicker disabled={!isSwitchOn[0].isOn} className="w-full" minDate={dayjs()} />
                <TimePicker format="hh:mm" disabled={!isSwitchOn[0].isOn} className="w-full" />
              </Flex>
              <div className="text-gray-600"></div>
            </div>
          )}
        </Form.Item>
        <Form.Item name="endTime">
          <Flex justify="space-between" align="center">
            <span>End Time</span>
            <Switch checked={isSwitchOn[1].isOn} onChange={(checked) => handleSwitchChange(1, checked)} />
          </Flex>
        </Form.Item>
        {isSwitchOn[1].isOn && (
          <div className="mt-4 space-y-2">
            <Flex className="space-x-2">
              <DatePicker disabled={!isSwitchOn[1].isOn} className="w-full" minDate={dayjs()} />
              <TimePicker format="hh:mm" disabled={!isSwitchOn[1].isOn} className="w-full" />
            </Flex>
            <div className="text-gray-600"></div>
          </div>
        )}
        <Form.Item name="randomQuestions">
          <Flex justify="space-between" align="center">
            <span>Random Questions</span>
            <Switch />
          </Flex>
        </Form.Item>
        <Form.Item name="randomOptions">
          <Flex justify="space-between" align="center">
            <span>Random Options</span>
            <Switch />
          </Flex>
        </Form.Item>
        <Form.Item name="visibility">
          <Flex justify="space-between" align="center">
            <span>Visibility</span>
            <Switch />
          </Flex>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default SettingModal;
