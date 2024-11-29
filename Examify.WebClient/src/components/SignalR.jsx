import { useEffect } from 'react';
import { useSignalRStore } from '~/stores/signalR-store';
const SignalR = () => {
  const { initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage } = useSignalRStore();

  useEffect(() => {
    initializeSignalR('https://localhost:8386/notification-service/api/result-hub');
    const handleMessage = (message) => {
      console.log('Received message:', message);
    };
    addSignalRHandler('SendMessage', handleMessage);
    return () => {
      removeSignalRHandler('SendMessage');
    };
  }, [initializeSignalR, addSignalRHandler, removeSignalRHandler]);

  const handleSendMessage = () => {
    sendSignalRMessage('SendMessage', "Hello hgbaodev");
  };

  return (
    <div>
      <button onClick={handleSendMessage}>Send Message</button>
    </div>
  );
};

export default SignalR;
