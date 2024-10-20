import { useState, useMemo } from 'react';

export const useTable = ({ fetchData, defaultPageSize = 8, defaultPage = 1, columns }) => {
  const [page, setPage] = useState(defaultPage);
  const [pageSize, setPageSize] = useState(defaultPageSize);
  const [keyword, setKeyword] = useState('');

  const { data, isLoading, error } = fetchData({ page, pageSize, keyword });

  const handlePageChange = (newPage, newPageSize) => {
    setPage(newPage);
    setPageSize(newPageSize);
  };

  const handleSearch = (value) => {
    setKeyword(value);
    setPage(1);
  };

  const tableColumns = useMemo(() => columns, [columns]);

  const tableProps = {
    columns: tableColumns,
    dataSource: data?.items,
    loading: isLoading,
    pagination: {
      current: data?.meta?.current_page,
      pageSize: data?.meta?.per_page,
      total: data?.meta?.total_elements,
      onChange: handlePageChange,
    },
    size: 'middle',
  };

  return {
    tableProps,
    handleSearch,
    keyword,
    error,
  };
};
