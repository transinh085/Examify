import { useEffect, useRef } from 'react';
import backgroundMusic from '~/assets/audios/background-music.mp3';
import useDoQuizStore from '~/stores/do-quiz-store';

const BackgroundAudio = () => {
  const { isPlayMusic } = useDoQuizStore();
  const audioRef = useRef(null);

  useEffect(() => {
    if (audioRef.current) {
      if (isPlayMusic) audioRef.current.play();
      else audioRef.current.pause();
    }
  }, [isPlayMusic]);

  return <audio ref={audioRef} src={backgroundMusic} loop controls={false} />;
};

export default BackgroundAudio;
