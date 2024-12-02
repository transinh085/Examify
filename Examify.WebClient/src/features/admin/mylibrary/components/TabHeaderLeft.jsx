import { Select, Space } from 'antd';

const TabHeaderLeft = () => {
  return (
    <Space size={'middle'}>
      <Select defaultValue={'most_recent'} className="w-[140px]">
        <Select.Option value="most_recent">Most recent</Select.Option>
        <Select.Option vaue="least_recent">Least recent</Select.Option>
        <Select.Option vaue="alphabetical">Alphabetical</Select.Option>
      </Select>
    </Space>
  );
};

export default TabHeaderLeft;
