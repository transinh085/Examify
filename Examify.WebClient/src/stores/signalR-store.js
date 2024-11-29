import { create } from 'zustand';
import SignalRService from '~/lib/SignalRService';

export const useSignalRStore = create((set, get) => ({
  signalRService: null,

  initializeSignalR: (url) => {
    const service = new SignalRService(url);
    set({ signalRService: service });
    service.startConnection();
  },

  disconnectSignalR: async () => {
    const { signalRService } = get();
    if (signalRService) {
      await signalRService.stopConnection();
      set({ signalRService: null });
    }
  },

  addSignalRHandler: (eventName, callback) => {
    const { signalRService } = get();
    if (signalRService) {
      signalRService.addHandler(eventName, callback);
    }
  },

  removeSignalRHandler: (eventName) => {
    const { signalRService } = get();
    if (signalRService) {
      signalRService.removeHandler(eventName);
    }
  },

  sendSignalRMessage: async (methodName, ...args) => {
    const { signalRService } = get();
    if (signalRService) {
      await signalRService.sendMessage(methodName, ...args);
    }
  },

  checkConnection: () => {
    const { signalRService } = get();
    return signalRService?.isConnected() || false;
  },
}));
