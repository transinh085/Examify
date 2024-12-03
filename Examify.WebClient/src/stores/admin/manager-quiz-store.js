import { create } from 'zustand';

const useManagerQuizStore = create((set) => ({
  users: [],
  quiz: null,
  isPlayingSound: false,
  isStart: false,
  tab: 1,
  addUser: (payload) =>
    set((state) => {
      if (state.users.find((user) => user.id === payload.id)) return state;
      return {
        users: [...state.users, { ...payload, score: 0, number_anwsered_correct: 0, number_anwsered_wrong: 0 }],
      };
    }),
  setQuiz: (payload) => set({ quiz: payload }),
  toggleSound: () => set((state) => ({ isPlayingSound: !state.isPlayingSound })),
  setIsStart: (payload) => set({ isStart: payload }),
  setTab: (payload) => set({ tab: payload }),
}));

export default useManagerQuizStore;
