import { Flex } from "antd";
import TestCard from "~/features/quiz/components/admin/TestCard";

const TabContent = ({ data }) => (
  <Flex className="space-y-2" vertical>
    {data.map((item, index) => (
      <TestCard 
        key={index} 
        id={item.id}
        imgSrc={item.imgSrc} 
        title={item.title} 
        author={item.author} 
        date={item.date} 
        tags={item.tags} 
        details={item.details} 
      />
    ))}
  </Flex>
);

export default TabContent;