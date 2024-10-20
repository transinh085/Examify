import { create } from 'zustand';

const useMenuStore = create((set) => ({
  siderVisible: false,
  setSiderVisible: (visible) => set({ siderVisible: visible }),
}));

export default useMenuStore;
