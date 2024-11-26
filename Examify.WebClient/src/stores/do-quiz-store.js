import { create } from 'zustand';

const useDoQuizStore = create((set) => ({
  quiz: {
    id: '1-1-1',
    title: 'Quiz 1',
    description: 'This is quiz 1',
  },
  quizSetting: {
    useTimer: false,
    code: '',
  },
  questionResults: [],
  currentQuestion: 0,
  selectedOptions: [],
  correctOptions: [],
  waitingDuration: 0,
  isPlayMusic: false,
  isFinished: false,
  initDoQuizStore: ({ useTimer, currentQuestion, questionResults, quiz }) => {
    set({
      quiz,
      questionResults,
      currentQuestion,
      quizSetting: {
        useTimer,
        code: '',
      },
    });
  },
  setIsPlayMusic: (isPlayMusic) => set({ isPlayMusic }),
  setQuestionResults: (questionResults) => set({ questionResults }),
  nextQuestion: () => set((state) => ({ currentQuestion: state.currentQuestion + 1 })),
  setCurrentQuestion: (currentQuestion) => set({ currentQuestion }),
  setSelectedOptions: (selectedOptions) => set({ selectedOptions }),
  setCorrectOptions: (correctOptions) => set({ correctOptions }),
  addSelectedOption: (option) => set((state) => ({ selectedOptions: [...state.selectedOptions, option] })),
  removeSelectedOption: (option) =>
    set((state) => ({ selectedOptions: state.selectedOptions.filter((id) => id !== option) })),
  setWaitingDuration: (waitingDuration) => set({ waitingDuration }),
  setIsFinished: (isFinished) => set({ isFinished }),
}));

export default useDoQuizStore;
