import { create } from 'zustand';

const useAuthStore = create((set) => ({
  isAuthenticated: false,
  user: null,
  setIsAuthenticated: (payload) => set({ isAuthenticated: payload }),
  setUser: (payload) => set({ user: payload, isAuthenticated: true }),
  resetUser: () => set({ user: null, isAuthenticated: false }),
}));

export default useAuthStore;
