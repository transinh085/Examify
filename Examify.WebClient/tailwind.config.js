/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx}'],
  theme: {
    extend: {
      colors: {
        primary: '#027f91',
        'ds-dark-500': '#090909cc',
        'ds-dark-500-30': '#0909094d',
        'ds-dark-500-50': '#09090980',
        'ds-dark-500-70': '#090909b3',
        'ds-light-500-20': '#ffffff33',
      },
      backgroundColor: (theme) => ({
        ...theme('colors'),
      }),
      textColor: (theme) => ({
        ...theme('colors'),
      }),
      borderColor: (theme) => ({
        ...theme('colors'),
      }),
    },
  },
  plugins: [],
};