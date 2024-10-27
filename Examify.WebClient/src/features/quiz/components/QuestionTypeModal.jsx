import { Col, Modal, Row } from 'antd';
import { CheckOutlined, DashOutlined, QuestionOutlined } from '@ant-design/icons';

const QuestionTypeModal = ({ open, onCancel }) => {
  return (
    <Modal title="Select type" width={800} open={open} onCancel={onCancel} footer={null} centered>
      <Row gutter={[16, 16]}>
        <Col span={8}>
          <QuestionTypeItem
            title="Multiple choice"
            description="Challenge students to think more critically by using visually interactive drag and drop questions."
            icon={<CheckOutlined />}
          />
        </Col>
        <Col span={8}>
          <QuestionTypeItem
            title="True or false"
            description="Test students' knowledge with true or false questions."
            icon={<QuestionOutlined />}
          />
        </Col>
        <Col span={8}>
          <QuestionTypeItem
            title="Fill in the blanks"
            description="Prompt your students for text and check if they remember the correct spelling of acommodate accomodate accommodate."
            icon={<DashOutlined />}
          />
        </Col>
      </Row>
    </Modal>
  );
};

const QuestionTypeItem = ({ title, description, icon, onClick }) => {
  return (
    <div
      onClick={onClick}
      className="p-4 border cursor-pointer rounded-xl hover:bg-neutral-100 flex flex-col items-center min-h-full"
    >
      <div className="bg-primary flex items-center justify-center w-[46px] h-[46px] text-white mb-4 rounded-xl shadow-xl">
        {icon}
      </div>
      <h3 className="text-base font-semibold text-center mb-2">{title}</h3>
      <p className="text-[11px] text-[#757575] text-center">{description}</p>
    </div>
  );
};

export default QuestionTypeModal;
