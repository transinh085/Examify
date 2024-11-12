import { Input } from "antd";
import { RightOutlined } from "@ant-design/icons";

const SearchBar = ({ onSearch }) => (
  <Input
    className="w-full max-w-[800px] px-4 py-2 sm:py-3"
    placeholder="Search for quizzes on any topic"
    suffix={
      <RightOutlined 
        className="cursor-pointer" 
        onClick={onSearch}
      />
    }
  />
);

export default SearchBar;