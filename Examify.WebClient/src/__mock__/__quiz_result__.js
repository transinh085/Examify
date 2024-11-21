const MOCK_QUIZ_RESULT = {
  id: '96616d04-435f-42a2-9073-497267b1ec5a',
  quiz: {
    title: 'Quiz 1',
    description: 'This is quiz 1',
  },
  quizSetting: {
    id: '1-1-1',
    useTimer: true,
    code: '123456',
  },
  currentQuestion: 0,
  questionResults: [
    {
      id: '057ddbba-f200-4a31-82f2-786a5f456ae4',
      isCorrect: false,
      question: {
        id: '9e38bb87-8e8e-4cdb-bf38-807be216a1ed',
        content: 'what is your favorite programing language ?',
        duration: 10,
        points: 0,
      },
      answerResults: [
        {
          id: '2295202d-4341-475c-9e96-869935bbdaf9',
          isSelected: false,
          options: {
            id: 'a64c561a-c42c-4c7e-b177-78bee14e5c50',
            content: 'Java',
            isCorrect: false,
          },
        },
        {
          id: '3322374d-5b41-43e2-acb0-cb61b349d863',
          isSelected: false,
          options: {
            id: '74be6ab7-2ed6-45c5-aa31-5b37a60bc62c',
            content: 'Python',
            isCorrect: true,
          },
        },
        {
          id: '65360efe-5c30-4baa-b531-7a1695f9ba85',
          isSelected: false,
          options: {
            id: '8d3d1778-058a-4152-b91e-b660f0342709',
            content: 'PHP',
            isCorrect: false,
          },
        },
        {
          id: 'ed7c7f0d-7a13-4efd-aa03-0961f336ef63',
          isSelected: false,
          options: {
            id: 'fbcf43cb-939f-4a14-b51a-31cfda7149c2',
            content: 'C#',
            isCorrect: false,
          },
        },
      ],
    },
    {
      id: 'bf13cf9c-8935-4ee4-b22c-df9b60eb5433',
      isCorrect: false,
      question: {
        id: 'ea1a3f3b-701f-4ce2-8d36-110f4b081e2c',
        content: 'Are you gay ?',
        duration: 10,
        points: 0,
      },
      answerResults: [
        {
          id: '8eef391b-ed18-456c-9a98-34566b0a9827',
          isSelected: false,
          options: {
            id: 'c7fdab2d-6e88-440d-aadb-a2c67cb1b825',
            content: 'Yes',
            isCorrect: false,
          },
        },
        {
          id: 'dfe769d6-4d15-458c-9593-bb293c0cd03d',
          isSelected: false,
          options: {
            id: '0dc62bb6-8dd4-4e13-8be9-ed0e38917707',
            content: 'No',
            isCorrect: true,
          },
        },
      ],
    },
    {
      id: 'c9c7e823-9002-4ace-a98f-42ee89400f8e',
      isCorrect: false,
      question: {
        id: '4d28b45c-d502-4eb6-83ed-b8f0f83162b3',
        content: 'let me know 1 + 1 = ?',
        duration: 10,
        points: 0,
      },
      answerResults: [
        {
          id: '2310a0cf-4430-4ebc-a62b-56fd16b16bb2',
          isSelected: false,
          options: {
            id: 'feab9126-2b4b-4084-9b1e-5f4ace7fdf13',
            content: '4',
            isCorrect: false,
          },
        },
        {
          id: '6ab9c4fa-3980-4f4a-a1b3-eac571a71898',
          isSelected: false,
          options: {
            id: 'e546f0a6-8ceb-41cb-8f4e-d9c9492701a4',
            content: '3',
            isCorrect: false,
          },
        },
        {
          id: 'bb9e0459-8902-4eb2-957d-b19383cd1c47',
          isSelected: false,
          options: {
            id: 'f0124fb7-4f7e-47db-9c70-98fe5bf191fa',
            content: '1',
            isCorrect: false,
          },
        },
        {
          id: 'd9e45cdc-5378-4127-99d7-a9fe092dba05',
          isSelected: false,
          options: {
            id: 'f4c8f73d-09a0-4d9b-8737-4f7c043700f9',
            content: '2',
            isCorrect: true,
          },
        },
      ],
    },
  ],
};

export { MOCK_QUIZ_RESULT };
