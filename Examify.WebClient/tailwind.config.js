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
      animation: {
        shake: 'shake 300ms ease-in-out',
        slip: 'slip 1s ease-in-out',
        mewmew: 'mewmew 60s linear infinite',
      },
      keyframes: {
        shake: {
          '0%': { transform: 'translateX(0)' },
          '25%': { transform: 'translateX(-4px)' },
          '50%': { transform: 'translateX(4px)' },
          '75%': { transform: 'translateX(-4px)' },
          '100%': { transform: 'translateX(0)' },
        },
        slip: {
          '0%': { transform: 'translateX(100%)' },
          '100%': { transform: 'translateX(0)' },
        },
        mewmew: {
          '0%': { left: '0' },
          '100%': { left: '100%' },
        },
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