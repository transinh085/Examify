import { closestCenter, DndContext } from '@dnd-kit/core';
import { restrictToVerticalAxis } from '@dnd-kit/modifiers';
import { arrayMove, SortableContext, verticalListSortingStrategy } from '@dnd-kit/sortable';
import { Space } from 'antd';
import { useEffect, useState } from 'react';
import SortableQuestion from '~/features/quiz/components/create-quiz/SortableQuestion';

const QuestionList = ({ quizId, questions }) => {
  const [items, setItems] = useState(questions);

  useEffect(() => {
    console.log('questions', questions);
    setItems(questions);
  }, [questions]);

  const handleDragEnd = (event) => {
    const { active, over } = event;

    if (active.id !== over.id) {
      const oldIndex = items.findIndex((item) => item.id === active.id);
      const newIndex = items.findIndex((item) => item.id === over.id);
      setItems(arrayMove(items, oldIndex, newIndex));
    }
  };

  return (
    <div className="draggable-container">
      <DndContext modifiers={[restrictToVerticalAxis]} collisionDetection={closestCenter} onDragEnd={handleDragEnd}>
        <SortableContext items={items} strategy={verticalListSortingStrategy}>
          <Space direction="vertical" size={16} className="w-full mb-7">
            {items.map((question, index) => (
              <SortableQuestion
                key={question.id}
                order={index + 1}
                quizId={quizId}
                id={question.id}
                question={question}
              />
            ))}
          </Space>
        </SortableContext>
      </DndContext>
    </div>
  );
};
export default QuestionList;
