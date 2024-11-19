import { create } from 'zustand';

const useDoQuizStore = create((set) => ({
  questions: [],
  currentQuestion: 0,
  selectedOptions: [],
  waitingDuration: 0,
  useTimer: false,
  isPlayMusic: false,
  isFinished: false,
  initDoQuizStore: ({ useTimer, questions }) => {
    set({
      questions,
      useTimer,
    });
  },
  setIsPlayMusic: (isPlayMusic) => set({ isPlayMusic }),
  setQuestions: (questions) => set({ questions }),
  nextQuestion: () => set((state) => ({ currentQuestion: state.currentQuestion + 1 })),
  setCurrentQuestion: (currentQuestion) => set({ currentQuestion }),
  setSelectedOptions: (selectedOptions) => set({ selectedOptions }),
  addSelectedOption: (option) => set((state) => ({ selectedOptions: [...state.selectedOptions, option] })),
  removeSelectedOption: (option) =>
    set((state) => ({ selectedOptions: state.selectedOptions.filter((id) => id !== option) })),
  setWaitingDuration: (waitingDuration) => set({ waitingDuration }),
  setIsFinished: (isFinished) => set({ isFinished }),
}));

export default useDoQuizStore;
