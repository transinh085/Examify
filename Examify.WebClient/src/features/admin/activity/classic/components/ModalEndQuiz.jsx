import { Button, Flex, Modal } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useEndQuiz } from '~/features/admin/activity/classic/api/end-quiz';
import useManagerQuizStore from '~/stores/admin/manager-quiz-store';

const ModalEndQuiz = () => {
  const { openModalEnd, setOpenModalEnd, quiz } = useManagerQuizStore();

  const navigate = useNavigate();

  const mutaEndQuiz = useEndQuiz({
    onSuccess: () => {
      setOpenModalEnd(false);
      navigate('/admin/my-library');
    },
  });

  const handleEndQuiz = () => {
    mutaEndQuiz.mutate({ id: quiz?.id });
  };

  const handleCancel = () => {
    setOpenModalEnd(false);
  };
  return (
    <Modal
      title={'End quiz'}
      open={openModalEnd}
      onCancel={handleCancel}
      footer={null}
      centered
      bodyStyle={{ backgroundColor: 'black', color: 'white' }}
      titleStyle={{ backgroundColor: 'black', color: 'white' }}
      style={{ backgroundColor: 'black', color: 'white' }}
    >
      <div className="p-4">
        <p className="text-xl text-center">Are you sure you want to end this quiz?</p>
        <Flex justify="center" className="mt-6">
          <Button color="danger" variant="solid" className="text-lg rounded-sm" onClick={handleEndQuiz} loading={mutaEndQuiz.isPending} >
            Yes
          </Button>
          <Button color="success" variant="solid" className="text-lg rounded-sm ml-4" onClick={handleCancel}>
            No
          </Button>
        </Flex>
      </div>
    </Modal>
  );
};

export default ModalEndQuiz;
