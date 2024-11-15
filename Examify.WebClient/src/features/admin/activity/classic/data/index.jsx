export const users = [
  {
    id: '1',
    name: 'lala',
    image: 'https://avatars.githubusercontent.com/u/120194990?v=4',
    score: 0,
    number_anwsered_correct: 0,
    number_anwsered_wrong: 0,
  },
  {
    id: '2',
    name: 'mono',
    image: 'https://avatars.githubusercontent.com/u/120194990?v=4',
    score: 3,
    number_anwsered_correct: 0,
    number_anwsered_wrong: 0,
  },
  {
    id: '3',
    name: 'hgbaodev',
    image: 'https://avatars.githubusercontent.com/u/120194990?v=4',
    score: 2,
    number_anwsered_correct: 0,
    number_anwsered_wrong: 0,
  },
];

export const questions = [
  {
    id: '1',
    question: 'What is the capital of Vietnam?',
    type: 'single_choice',
    number_answer_correct: 1,
    number_anwser_wrong: 3,
    answers: [
      { id: '1', answer: 'Hanoi', is_correct: true },
      { id: '2', answer: 'Ho Chi Minh City', is_correct: false },
      { id: '3', answer: 'Da Nang', is_correct: false },
      { id: '4', answer: 'Hue', is_correct: false },
    ],
  },
  {
    id: '2',
    question: 'What is the capital of Vietnam?',
    type: 'mutiple_choice',
    number_answer_correct: 1,
    number_anwser_wrong: 3,
    answers: [
      { id: '1', answer: 'Hanoi', is_correct: true },
      { id: '2', answer: 'Ho Chi Minh City', is_correct: false },
      { id: '3', answer: 'Da Nang', is_correct: false },
      { id: '4', answer: 'Hue', is_correct: false },
    ],
  }
]