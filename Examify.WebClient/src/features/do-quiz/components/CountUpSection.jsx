import { useEffect } from 'react';
import useDoQuizStore from '~/stores/do-quiz-store';

const CountUpSection = () => {
  const { timeTaken, setTimeTaken } = useDoQuizStore();

  useEffect(() => {
    const timer = setInterval(() => {
      setTimeTaken(timeTaken + 1);
    }, 1000);

    return () => clearInterval(timer);
  }, [setTimeTaken, timeTaken]);

  const minutes = Math.floor(timeTaken / 60);
  const seconds = timeTaken % 60;

  return (
    <div className="bg-[#3e084a] p-4 rounded-lg">
      <h1 className="md:text-base lg:text-3xl">{`${minutes.toString().padStart(2, '0')}:${seconds
        .toString()
        .padStart(2, '0')}`}</h1>
    </div>
  );
};

export default CountUpSection;
