import { useSortable } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import { memo } from 'react';
import QuestionItem from '~/features/quiz/components/create-quiz/QuestionItem';

const SortableQuestion = ({ id, ...props }) => {
  const { attributes, listeners, setNodeRef, setActivatorNodeRef, transform, transition, isDragging } = useSortable({
    id,
  });

  const style = {
    transform: CSS.Transform.toString(transform),
    transition,
    ...(isDragging
      ? {
          position: 'relative',
          zIndex: 99,
        }
      : {}),
  };

  return (
    <div ref={setNodeRef} style={style} {...attributes}>
      <QuestionItem {...props} listener={listeners} setActivatorNodeRef={setActivatorNodeRef} />
    </div>
  );
};

export default memo(SortableQuestion);
