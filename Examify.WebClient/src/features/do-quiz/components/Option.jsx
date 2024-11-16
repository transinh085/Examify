import { Card, Flex, Tooltip } from 'antd';
import PropTypes from 'prop-types';
import { useMemo } from 'react';
import { IGNORED_OPTION_OPACITY, OPTION_COLOR_ARRAY, SELECTED_OPTION_COLOR_CONFIG } from '~/config/constants';
import { QUESTION_TYPE } from '~/config/enums';
import useDoQuizStore from '~/stores/do-quiz-store';

const Option = ({ type, number, id, content, isCorrect, handleSelect }) => {
  const { waitingDuration, selectedOptions } = useDoQuizStore();

  const optionStyles = useMemo(() => {
    const isSelected = selectedOptions.includes(id);

    let backgroundColor = OPTION_COLOR_ARRAY[(number - 1) % OPTION_COLOR_ARRAY.length];
    let opacity = 1;
    let animate = '';

    if (waitingDuration) {
      if (isSelected) {
        if (isCorrect) {
          backgroundColor = SELECTED_OPTION_COLOR_CONFIG.CORRECT;
        } else {
          backgroundColor = SELECTED_OPTION_COLOR_CONFIG.INCORRECT;
          animate = 'animate-shake';
        }
        opacity = 1;
      } else {
        if (isCorrect && type === QUESTION_TYPE.MULTIPLE_CHOICE) {
          backgroundColor = SELECTED_OPTION_COLOR_CONFIG.INCORRECT;
          animate = 'animate-shake';
        } else {
          opacity = IGNORED_OPTION_OPACITY;
        }
      }
    }

    return { backgroundColor, opacity, animate };
  }, [waitingDuration, isCorrect, selectedOptions, id, number, type]);

  return (
    <Card
      style={optionStyles}
      className={`border-none  cursor-pointer relative  ${optionStyles.animate}`}
      onClick={handleSelect}
    >
      <Tooltip title="Use your keyboard to choose" placement="top">
        <Flex
          flex={1}
          align="center"
          justify="center"
          className="absolute top-2 right-2 w-[34px] h-[34px] border border-[#ccc] rounded-md"
          style={{
            backgroundColor: selectedOptions.includes(id) ? 'white' : 'transparent',
          }}
        >
          <p
            style={{
              color: selectedOptions.includes(id) ? optionStyles.backgroundColor : 'white',
            }}
          >
            {number}
          </p>
        </Flex>
      </Tooltip>
      <Flex align="center" justify="center" className="flex-grow w-full lg:min-h-[240px]">
        <h1 className="text-white text-base lg:text-2xl font-medium text-center">{content}</h1>
      </Flex>
    </Card>
  );
};

Option.propTypes = {
  type: PropTypes.string,
  number: PropTypes.number,
  id: PropTypes.number,
  content: PropTypes.string,
  isCorrect: PropTypes.bool,
  handleSelect: PropTypes.func,
};

export default Option;
