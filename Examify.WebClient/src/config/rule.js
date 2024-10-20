const RULES = {
  login: {
    email: [
      { required: true, message: 'Please enter your email!' },
      { type: 'email', message: 'Please enter a valid email!' },
    ],
    password: [
      { required: true, message: 'Please enter a password!' },
      { min: 6, message: 'Password must be at least 6 characters!' },
      {
        max: 16,
        message: 'Password must be at most 16 characters!',
      },
    ],
  },
  register: {
    name: [
      { required: true, message: 'Please enter the employee name!' },
      { min: 3, message: 'Name must be at least 3 characters!' },
      {
        max: 30,
        message: 'Name must be at most 30 characters!',
      },
    ],
    email: [
      { required: true, message: 'Please enter your email!' },
      { type: 'email', message: 'Please enter a valid email!' },
    ],
    password: [
      { required: true, message: 'Please enter a password!' },
      { min: 6, message: 'Password must be at least 6 characters!' },
      {
        max: 16,
        message: 'Password must be at most 16 characters!',
      },
    ],
  },
  createEmployee: {
    name: [
      { required: true, message: 'Please enter the employee name!' },
      { min: 3, message: 'Name must be at least 3 characters!' },
      {
        max: 30,
        message: 'Name must be at most 30 characters!',
      },
    ],
    email: [
      { required: true, message: 'Please enter your email!' },
      { type: 'email', message: 'Please enter a valid email!' },
    ],
    phone: [
      { required: true, message: 'Please enter the phone number!' },
      { min: 9, message: 'Phone number must be at least 9 characters!' },
      {
        max: 11,
        message: 'Phone number must be at most 11 characters!',
      },
    ],
    address: [
      { required: true, message: 'Please enter the employee address!' },
      { min: 8, message: 'Address must be at least 8 characters!' },
      {
        max: 150,
        message: 'Address must be at most 150 characters!',
      },
    ],
    password: [
      { required: true, message: 'Please enter a password!' },
      { min: 6, message: 'Password must be at least 6 characters!' },
      {
        max: 16,
        message: 'Password must be at most 16 characters!',
      },
    ],
  },
  createCarriage: {
    name: [
      { required: true, message: 'Please enter the carriage name!' },
      { min: 10, message: 'Name must be at least 10 characters!' },
      {
        max: 150,
        message: 'Name must be at most 150 characters!',
      },
    ],
    floors: [{ required: true, message: 'Please select the number of floors!' }],
  },
  createTrain: {
    name: [
      { required: true, message: 'Please enter the carriage name!' },
      { min: 10, message: 'Name must be at least 10 characters!' },
      {
        max: 150,
        message: 'Name must be at most 150 characters!',
      },
    ],
  },
};
export default RULES;
