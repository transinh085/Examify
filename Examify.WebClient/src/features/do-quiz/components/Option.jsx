import { useEffect, useState } from 'react';
import { OPTION_COLOR_ARRAY } from '../utils/constant';
import { Card, Flex, Tooltip } from 'antd';

const Option = ({ number, content, handleSelect, isCorrect }) => {
  const [backgroundColor, setBackgroundColor] = useState(null);

  useEffect(() => {
    setBackgroundColor(OPTION_COLOR_ARRAY[(number - 1) % OPTION_COLOR_ARRAY.length]);
  }, [content, number]);

  return (
    <Card
      style={{ backgroundColor }}
      className="border-none  cursor-pointer relative"
      onClick={() => {
        handleSelect(isCorrect);
        setBackgroundColor(isCorrect ? '#4cd137' : '#ff0000');
      }}
    >
      <Tooltip title="Use your keyboard to choose">
        <Flex
          flex={1}
          align="center"
          justify="center"
          className="absolute top-2 right-2 w-[34px] h-[34px] border border-[#ccc] rounded-md"
        >
          <p className="text-[#ccc]">{number}</p>
        </Flex>
      </Tooltip>
      <Flex align="center" justify="center" className="flex-grow w-full min-h-[240px]">
        <h1 className="text-white text-2xl font-medium text-center">{content}</h1>
      </Flex>
    </Card>
  );
};

export default Option;
