function convertToAbbreviation(phrase) {
  const words = phrase.split(' ').filter((word) => word.trim() !== '');
  const abbreviation = words.map((word) => word[0].toUpperCase()).join('');
  return abbreviation;
}
export { convertToAbbreviation };
