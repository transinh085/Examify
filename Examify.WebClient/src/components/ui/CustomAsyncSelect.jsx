import { Select, Spin } from 'antd';
import { useEffect, useState } from 'react';
import { ROW_PER_PAGE } from '~/config/constants';
import useDebounce from '~/hooks/useDebounce';
import PropTypes from 'prop-types';

const { Option } = Select;

const CustomAsyncSelect = ({ loadQuery, setValue, config = { value: 'id', label: 'name' } }) => {
  const [options, setOptions] = useState([]);
  const [page, setPage] = useState(1);
  const [keyword, setKeyword] = useState('');
  const [hasMore, setHasMore] = useState(true);

  const debouncedKeyword = useDebounce(keyword, 500);

  const { data: seatTypes, isLoading } = loadQuery({
    page,
    keyword: debouncedKeyword,
    size: ROW_PER_PAGE,
  });

  useEffect(() => {
    if (seatTypes) {
      const newOptions = seatTypes.items.map((item) => {
        let option = {};
        Object.keys(config).forEach((key) => {
          option[key] = item[config[key]];
        });

        return option;
      });

      setOptions((prev) => (page === 1 ? newOptions : [...prev, ...newOptions]));
      setHasMore(seatTypes?.meta?.current_page < seatTypes?.meta?.total_pages);
    }
  }, [seatTypes, page, config]);

  const handleSearch = (value) => {
    setKeyword(value);
    setPage(1);
  };

  const handleScroll = (e) => {
    if (e.target.scrollTop + e.target.clientHeight > e.target.scrollHeight - 50 && hasMore) {
      setPage((prev) => prev + 1);
    }
  };

  const handleSelect = (_, value) => {
    setValue(value);
  };

  return (
    <Select
      showSearch
      onSearch={handleSearch}
      onPopupScroll={handleScroll}
      onSelect={handleSelect}
      filterOption={false}
      notFoundContent={isLoading ? <Spin size="small" /> : null}
    >
      {options.map((option, index) => (
        <Option key={index} {...option}>
          {option.label}
        </Option>
      ))}
    </Select>
  );
};

CustomAsyncSelect.propTypes = {
  loadQuery: PropTypes.func.isRequired,
  setValue: PropTypes.func,
  config: PropTypes.object,
};

export default CustomAsyncSelect;
