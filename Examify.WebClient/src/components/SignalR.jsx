import { useEffect } from 'react';
import useAuthStore from '~/stores/auth-store';
import { useSignalRStore } from '~/stores/signalR-store';
const SignalR = () => {
  const { user } = useAuthStore();
  const { initializeSignalR, addSignalRHandler, removeSignalRHandler, sendSignalRMessage } = useSignalRStore();

  useEffect(() => {
    initializeSignalR('https://localhost:8386/notification-service/api/notification-hub');

    addSignalRHandler('JoinQuiz', (message) => {
      console.log('Received message:', message);
    });


    return () => {
      removeSignalRHandler('JoinQuiz');
    };

  }, [initializeSignalR, addSignalRHandler, removeSignalRHandler]);

  const handleSendMessage = () => {
    sendSignalRMessage('JoinQuizUser', "01937bf1-1ee0-7ea1-91db-12e61b1f40f0", user?.id);
  };

  return (
    <div>
      <button onClick={handleSendMessage}>Send Message</button>
    </div>
  );
};

export default SignalR;