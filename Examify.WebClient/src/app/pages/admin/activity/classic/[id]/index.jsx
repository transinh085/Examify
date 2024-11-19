import ManagerQuizWait from '~/features/admin/activity/classic/components/ManagerQuizWait';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';
import ManagerQuizStart from '~/features/admin/activity/classic/components/ManagerQuizStart';

const ManagerQuizPage = () => {
  const { isStart } = useManagerQuizStore();

  return isStart ? <ManagerQuizStart /> : <ManagerQuizWait />;
};

export default ManagerQuizPage;
