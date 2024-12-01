import { create } from 'zustand';

const useDoQuizStore = create((set) => ({
  quiz: {
    id: '',
    title: '',
    description: '',
    code: '',
    useTimer: false,
  },
  questionResults: [],
  currentQuestion: -1,
  timeTaken: 0,
  totalPoints: 0,
  selectedOptions: [],
  correctOptions: [],
  waitingDuration: 0,
  isPlayMusic: false,
  isFinished: false,
  initDoQuizStore: ({ currentQuestion, timeTaken, totalPoints, questionResults, quiz }) => {
    const isFinished = currentQuestion >= questionResults.length;
    set({
      quiz,
      questionResults,
      currentQuestion,
      timeTaken,
      totalPoints,
      isFinished,
      waitingDuration: 0,
      selectedOptions: [],
      correctOptions: [],
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
  setTimeTaken: (timeTaken) => set({ timeTaken }),
}));

export default useDoQuizStore;
