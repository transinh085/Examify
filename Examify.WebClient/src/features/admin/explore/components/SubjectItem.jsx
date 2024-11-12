import { Space } from "antd";

const SubjectItem = ({ img, name }) => (
  <Space direction="vertical" size="small" className="items-center cursor-pointer">
    <img
      className="bg-center bg-contain w-12 h-12 sm:w-[50px] sm:h-[50px]"
      src={img}
      loading="lazy"
      alt={`${name}_image`}
    />
    <span className="font-bold text-xs">{name}</span>
  </Space>
);

export default SubjectItem;