import { useParams } from 'react-router-dom';
import { Button, Col, Flex, Layout, Row, Space } from 'antd';
import { EditOutlined, ScheduleOutlined } from '@ant-design/icons';

const { Content } = Layout;

const PlayerPage = () => {
  const { id } = useParams();
  console.log(id);
  return (
    <Content>
      <Flex justify="space-between" align="center" className='mb-3'>
        <Space>
          <h1 className='font-bold'>Test name</h1>
          <Button icon={<EditOutlined />}></Button>
          <div className="bg-white flex space-x-1 items-center px-2 py-1 rounded-md">
            <span className="bg-red-500 rounded-full size-2"></span>
            <span>Completed</span>
          </div>
        </Space>
        <Space>
          <Button type='primary'>Live Dashboard</Button>
          <Button type='primary'>Assign homework</Button>
        </Space>
      </Flex>
      <Flex gap={2} align='center' className='mb-6'>
        <ScheduleOutlined />
        <span className='text-xs'>Started :  Nov 02, 2024, 04:01 PM (9 days ago)</span>
      </Flex>
      <section className='p-4 bg-white'>
        <Row gutter={16}>
          <Col span={6}>
            Accuracy
          </Col>
          <Col span={6}>
            Accuracy
          </Col>
          <Col span={6}>
            Accuracy
          </Col>
          <Col span={6}>
            Accuracy
          </Col>
        </Row>
      </section>
    </Content>
  );
};

export default PlayerPage;
