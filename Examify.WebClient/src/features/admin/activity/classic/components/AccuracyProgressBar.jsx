import { useMemo } from 'react';
import { Flex } from "antd";

const AccuracyProgressBar = ({ number_correct = 0, number_wrong = 0 }) => {
  const total = useMemo(() => number_correct + number_wrong, [number_correct, number_wrong]);

  const accuracyPercentage = useMemo(() => {
    if (total === 0) return 0;
    return Math.round((number_correct / total) * 100);
  }, [number_correct, number_wrong, total]);

  return (
    <Flex justify="center" align="center" className="mb-12">
      <div className="relative max-w-4xl w-full bg-ds-dark-500-70 h-16 rounded-lg bg-opacity-50">
        {/* Thanh màu xanh lá - Correct */}
        <div
          className="absolute left-0 top-0 h-full rounded-lg bg-gradient-to-r from-green-400 to-green-400/50 transition-all duration-500"
          style={{ width: total !== 0 ? `${accuracyPercentage}%` : '0%' }}
        />
        {/* Thanh màu đỏ - Wrong */}
        <div
          className="absolute right-0 top-0 h-full rounded-lg bg-gradient-to-r from-red-400/50 to-red-400 transition-all duration-500"
          style={{ width: total !== 0 ? `${100 - accuracyPercentage}%` : '0%' }}
        />
        {/* Số câu đúng */}
        <div className="absolute left-0 top-1/2 -translate-y-1/2 ml-2 h-8 w-2">
          <div className="absolute -top-10 left-1/2 -translate-x-1/2 text-green-400 text-sm font-medium">
            {number_correct}
          </div>
        </div>
        {/* Số câu sai */}
        <div className="absolute right-0 top-1/2 -translate-y-1/2 mr-2 h-8 w-2">
          <div className="absolute -top-10 left-1/2 -translate-x-1/2 text-red-400 text-sm font-medium">
            {number_wrong}
          </div>
        </div>
        {/* Vòng tròn hiển thị chính giữa */}
        <div className="absolute left-1/2 top-1/2 -translate-x-1/2 -translate-y-1/2">
          <div className="bg-white rounded-full h-[90px] w-[90px] flex flex-col items-center justify-center shadow-lg outline outline-8 outline-ds-light-500-20">
            <span className="text-black font-bold text-lg">{accuracyPercentage}%</span>
            <span className="text-gray-500 text-[10px] text-center leading-tight">
              Class<br />accuracy
            </span>
            <span className="text-gray-400 text-[10px]">
              {total} answers
            </span>
          </div>
        </div>
      </div>
    </Flex>
  );
};

export default AccuracyProgressBar;
