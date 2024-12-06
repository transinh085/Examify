import { create } from 'zustand';

const useManagerQuizStore = create((set) => ({
  userJoin: [],
  users: [],
  quiz: null,
  isPlayingSound: false,
  isStart: false,
  tab: 1,
  openModalEnd: false,
  setOpenModalEnd: (payload) => set({ openModalEnd: payload }),
  addUserJoin: (payload) =>
    set((state) => {
      if (state.userJoin.find((user) => user.id === payload.id)) return state;
      return {
        userJoin: [...state.userJoin, payload],
      };
    }),
  setUserJoin: (payload) => set({ userJoin: payload }),
  setQuiz: (payload) => set({ quiz: payload }),
  toggleSound: () => set((state) => ({ isPlayingSound: !state.isPlayingSound })),
  setIsStart: (payload) => set({ isStart: payload }),
  setTab: (payload) => set({ tab: payload }),
}));

export default useManagerQuizStore;
