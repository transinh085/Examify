import { create } from "zustand";

const useManagerQuizStore = create((set) => ({
  isPlayingSound: false,
  isStart: false,
  tab: 1,
  toggleSound: () => set((state) => ({ isPlayingSound: !state.isPlayingSound })),
  setIsStart: (payload) => set({ isStart: payload}),
  setTab: (payload) => set({ tab: payload})
}));

export default useManagerQuizStore;