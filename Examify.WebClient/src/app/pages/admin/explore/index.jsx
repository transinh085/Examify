import { Flex, Typography, Input, Space, Row, Col, Button, Card } from 'antd';
import { RightOutlined, StarFilled } from '@ant-design/icons';

const { Title } = Typography;
const { Meta } = Card;

const listSubject = [
  {
    id: 1,
    name: 'Ice breaker',
    img: 'https://cf.quizizz.com/img/course-assets/title_imgs/bts_templates.png',
  },
  {
    id: 2,
    name: 'Math',
    img: 'https://cf.quizizz.com/image/subject-math.png',
  },
  {
    id: 3,
    name: 'English',
    img: 'https://cf.quizizz.com/image/subject-english.png',
  },
  {
    id: 4,
    name: 'Music',
    img: 'https://cf.quizizz.com/image/subject-arts-music.png',
  },
  {
    id: 5,
    name: 'Development',
    img: 'https://cf.quizizz.com/image/subject-career-ed-professional-development.png',
  },
  {
    id: 6,
    name: 'Computers',
    img: 'https://cf.quizizz.com/image/subject-computers.png',
  },
  {
    id: 7,
    name: 'Physical',
    img: 'https://cf.quizizz.com/image/subject-physical-ed.png',
  },
  {
    id: 8,
    name: 'Science',
    img: 'https://cf.quizizz.com/image/subject-science.png',
  },
];

const ExplorePage = () => {
  return (
    <Flex vertical justify="center" className="px-6">
      <Title level={2} className="text-center mt-5 lg:py-8">
        What will you teach today?
      </Title>
      <Flex justify="center" className="mb-8">
        <Input
          className="w-[800px] px-4 py-3"
          placeholder="Search for quizzes on any topic"
          suffix={<RightOutlined className="cursor-pointer" />}
        ></Input>
      </Flex>
      <Flex className="space-x-6 mb-8" justify="center">
        {listSubject.map((item) => (
          <Space key={item.id} direction="vertical" size={'small'} className="items-center cursor-pointer">
            <img
              className="bg-center bg-contain w-[50px] h-[50px]"
              src={item.img}
              aria-hidden="true"
              alt="Ice breaker_image"
            />
            <span className="font-bold text-xs">{item.name}</span>
          </Space>
        ))}
      </Flex>
      <Row gutter={16} className='mb-6'>
        <Col span={24}>
          <Flex justify="space-between" className='mb-4'>
            <Space size={'middle'}>
              <StarFilled className="text-yellow-500" style={{ fontSize: '24px' }} />
              <h3 className="font-bold text-lg">Ice breaker</h3>
            </Space>
            <Button type='primary' iconPosition="end" icon={<RightOutlined />}>
              See more
            </Button>
          </Flex>
        </Col>
        <Col className="gutter-row mb-2" xs={24} md={12} lg={8} xl={6}>
          <Card
          cover={<img alt="example" className='h-[200px]]' src="https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400" />}
          >
            <Meta title="Europe Street beat" description="www.instagram.com" />
          </Card>
        </Col>
        <Col className="gutter-row mb-2" xs={24} md={12} lg={8} xl={6}>
          <Card
          cover={<img alt="example" className='h-[200px]]' src="https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400" />}
          >
            <Meta title="Europe Street beat" description="www.instagram.com" />
          </Card>
        </Col>
        <Col className="gutter-row mb-2" xs={24} md={12} lg={8} xl={6}>
          <Card
          cover={<img alt="example" className='h-[200px]]' src="https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400" />}
          >
            <Meta title="Europe Street beat" description="www.instagram.com" />
          </Card>
        </Col>
        <Col className="gutter-row mb-2" xs={24} md={12} lg={8} xl={6}>
          <Card
          cover={<img alt="example" className='h-[200px]]' src="https://quizizz.com/media/resource/gs/quizizz-media/quizzes/4bec310a-4e33-412c-9279-559126f87136?w=400&h=400" />}
          >
            <Meta title="Europe Street beat" description="www.instagram.com" />
          </Card>
        </Col>
      </Row>
    </Flex>
  );
};

export default ExplorePage;
