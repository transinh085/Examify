/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {
      animation: {
        'bounce-up': 'bounce-up 2s infinite',
        'bounce-down': 'bounce-down 2s infinite',
      },
      colors: {
        primary: '#027f91',
      },
    },
  },
  plugins: [],
};
