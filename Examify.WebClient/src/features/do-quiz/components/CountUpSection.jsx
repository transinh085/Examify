import { useState, useEffect } from 'react';

const CountUpSection = () => {
  const [timeElapsed, setTimeElapsed] = useState(0);

  useEffect(() => {
    const timer = setInterval(() => {
      setTimeElapsed((prevTime) => prevTime + 1);
    }, 1000);

    return () => clearInterval(timer);
  }, []);

  const minutes = Math.floor(timeElapsed / 60);
  const seconds = timeElapsed % 60;

  return (
    <div className="bg-[#3e084a] p-4 rounded-lg">
      <h1 className="md:text-base lg:text-3xl">{`${minutes.toString().padStart(2, '0')}:${seconds
        .toString()
        .padStart(2, '0')}`}</h1>
    </div>
  );
};

export default CountUpSection;
