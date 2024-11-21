import { create } from 'zustand';

const useAuthStore = create((set) => ({
  isAuthenticated: false,
  user: null,
  setIsAuthenticated: (payload) => set({ isAuthenticated: payload }),
  setUser: (payload) => set({ user: payload, isAuthenticated: true }),
  resetUser: () => set({ user: null, isAuthenticated: false }),
  setUserProfile: ({ lastName, firstName }) => {
    set((state) => ({
      user: { ...state.user, lastName, firstName },
    }))
  }
}))





export default useAuthStore;
