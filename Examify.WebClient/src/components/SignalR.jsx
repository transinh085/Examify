import { useEffect } from 'react';
import useAuthStore from '~/stores/auth-store';
import { useSignalRStore } from '~/stores/signalR-store';
const SignalR = () => {
  const { initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage } = useSignalRStore();
  const { user } = useAuthStore();

  useEffect(() => {
    initializeSignalR('https://localhost:8386/notification-service/api/result-hub');

    addSignalRHandler('JoinQuiz', (message) => {
      console.log('Received message:', message);
    });

    return () => {
      removeSignalRHandler('JoinQuiz');
    };

  }, [initializeSignalR, addSignalRHandler, removeSignalRHandler]);

  const handleSendMessage = () => {
    sendSignalRMessage('JoinQuiz', "6a6b4473-4c45-4d58-9ed1-3fd85bfad462", user?.id);
  };

  return (
    <div>
      <button onClick={handleSendMessage}>Send Message</button>
    </div>
  );
};

export default SignalR;