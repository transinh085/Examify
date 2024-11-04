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
    firstName: [
      { required: true, message: 'Please enter your first name!' },
      { min: 2, message: 'First name must be at least 3 characters!' },
      {
        max: 30,
        message: 'First name must be at most 30 characters!',
      },
    ],
    lastName: [
      { required: true, message: 'Please enter your last name!' },
      { min: 2, message: 'Last name must be at least 3 characters!' },
      {
        max: 30,
        message: 'Last name must be at most 30 characters!',
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
};

export default RULES;
