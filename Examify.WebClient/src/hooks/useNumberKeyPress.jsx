import { useEffect } from 'react';

function useNumberKeyPress(callback) {
  useEffect(() => {
    const handleKeyPress = (event) => {
      if (event.key >= '1' && event.key <= '9') {
        callback(parseInt(event.key, 10));
      }
    };

    window.addEventListener('keydown', handleKeyPress);

    return () => {
      window.removeEventListener('keydown', handleKeyPress);
    };
  }, [callback]);
}

export default useNumberKeyPress;
