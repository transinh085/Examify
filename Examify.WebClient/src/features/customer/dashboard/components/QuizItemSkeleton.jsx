import { Skeleton } from 'antd';

const QuizItemSkeleton = () => {
  return (
    <div className="bg-white shadow-sm overflow-hidden rounded-md">
      <div>
        <Skeleton.Image className="!w-full !h-[120px]" active />
      </div>
      <div className="p-4">
        <Skeleton active paragraph={{ rows: 2 }} />
      </div>
    </div>
  );
};

export default QuizItemSkeleton;
