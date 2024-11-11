import { Button, Flex, Space } from "antd";
import { RightOutlined } from "@ant-design/icons";

const SectionHeader = ({ icon, title, onSeeMore }) => (
  <Flex justify="space-between" align="center" className="mb-4 px-2">
    <Space size="middle">
      {icon}
      <h3 className="font-bold text-base sm:text-lg">{title}</h3>
    </Space>
    <Button 
      type="primary" 
      onClick={onSeeMore}
      className="text-xs sm:text-sm"
      icon={<RightOutlined />}
    >
      See more
    </Button>
  </Flex>
);

export default SectionHeader;