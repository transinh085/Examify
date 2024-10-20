const removeVietnameseTones = (str) => {
  str = str.toLowerCase();
  str = str.normalize('NFD').replace(/[\u0300-\u036f]/g, ''); // Normalize và loại bỏ dấu
  str = str.replace(/đ/g, 'd'); // Đổi chữ đ thành d
  str = str.replace(/[^a-z0-9\s]/g, ''); // Loại bỏ ký tự đặc biệt
  return str;
};

export const searchWithoutDiacritics = (string, searchTerm) => {
  const normalizedString = removeVietnameseTones(string);
  const normalizedSearchTerm = removeVietnameseTones(searchTerm);

  return normalizedString.includes(normalizedSearchTerm);
};
