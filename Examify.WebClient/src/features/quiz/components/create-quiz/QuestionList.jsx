import { closestCenter, DndContext } from '@dnd-kit/core';
import { restrictToVerticalAxis } from '@dnd-kit/modifiers';
import { arrayMove, SortableContext, verticalListSortingStrategy } from '@dnd-kit/sortable';
import { useQueryClient } from '@tanstack/react-query';
import { Space } from 'antd';
import { useCallback, useEffect, useState } from 'react';
import { getQuestionByQuizIdQueryOptions } from '~/features/quiz/api/questions/get-question-by-quiz-id';
import { useOrderQuestion } from '~/features/quiz/api/questions/order-question';
import SortableQuestion from '~/features/quiz/components/create-quiz/SortableQuestion';

const QuestionList = ({ quizId, questions }) => {
  const [questionList, setQuestionList] = useState(questions);
  const queryClient = useQueryClient();
  const orderQuestionMutation = useOrderQuestion();

  useEffect(() => {
    setQuestionList(questions);
  }, [questions]);

  const handleDragEnd = useCallback(
    (event) => {
      const { active, over } = event;

      if (active.id !== over.id) {
        const oldIndex = questionList.findIndex((item) => item.id === active.id);
        const newIndex = questionList.findIndex((item) => item.id === over.id);

        orderQuestionMutation.mutate({ questionId: active.id, order: newIndex });
        setQuestionList(arrayMove(questionList, oldIndex, newIndex));
        queryClient.setQueryData(getQuestionByQuizIdQueryOptions(quizId).queryKey, (oldData) => {
          const newData = [...oldData];
          return arrayMove(newData, oldIndex, newIndex);
        });
      }
    },
    [questionList, orderQuestionMutation, queryClient, quizId],
  );

  return (
    <div className="draggable-container">
      <DndContext modifiers={[restrictToVerticalAxis]} collisionDetection={closestCenter} onDragEnd={handleDragEnd}>
        <SortableContext items={questionList} strategy={verticalListSortingStrategy}>
          <Space direction="vertical" size={16} className="w-full mb-7">
            {questionList.map((question, index) => (
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
