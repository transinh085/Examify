import { create } from "zustand";

const useManagerQuizStore = create((set) => ({
  quiz: null,
  isPlayingSound: false,
  isStart: false,
  tab: 1,
  setQuiz: (payload) => set({ quiz: payload}),
  toggleSound: () => set((state) => ({ isPlayingSound: !state.isPlayingSound })),
  setIsStart: (payload) => set({ isStart: payload}),
  setTab: (payload) => set({ tab: payload})
}));

export default useManagerQuizStore;