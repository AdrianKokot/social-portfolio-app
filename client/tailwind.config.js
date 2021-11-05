const colors = require('tailwindcss/colors')

module.exports = {
  mode: 'jit',
  purge: ['./projects/**/src/**/*.{html,ts}'],
  darkMode: 'class',
  theme: {
    screens: {
      sm: '640px',
      md: '768px',
      lg: '1024px',
      xl: '1280px',
      '2xl': '1536px',
    },
    colors: {
      transparent: 'transparent',
      current: 'currentColor',

      black: colors.black,
      white: colors.white,
      // gray: colors.coolGray,
      red: colors.red,
      yellow: colors.amber,

      gray: {
        '50': '#F9FAFC',
        '100': '#f0f3f5',
        '200': '#e2e7eb',
        '300': '#c5ced6',
        '400': '#99aab8',
        '500': '#6D8599',
        '600': '#4F5F6D',
        '700': '#394b5a',
        '800': '#233748',
        '900': '#1a2936',
        // '1000': '#111b23'
      },
      green: {
        '50': '#f4fcfa',
        '100': '#e9f9f6',
        '200': '#c8efe7',
        '300': '#a7e5d9',
        '400': '#64d2bd',
        '500': '#22BFA0',
        '600': '#1fac90',
        '700': '#1a8f78',
        '800': '#147360',
        '900': '#115e4e'
      },

      blue: colors.blue,
      indigo: colors.indigo,
      purple: colors.violet,
      pink: colors.pink,
    },
    fontFamily: {
      'sans-heading': [
        '"Josefin Sans"',
        'ui-sans-serif',
        'system-ui',
        '-apple-system',
        'BlinkMacSystemFont',
        '"Segoe UI"',
        'Roboto',
        '"Helvetica Neue"',
        'Arial',
        '"Noto Sans"',
        'sans-serif',
        '"Apple Color Emoji"',
        '"Segoe UI Emoji"',
        '"Segoe UI Symbol"',
        '"Noto Color Emoji"',
      ],
      sans: [
        '"Poppins"',
        'ui-sans-serif',
        'system-ui',
        '-apple-system',
        'BlinkMacSystemFont',
        '"Segoe UI"',
        'Roboto',
        '"Helvetica Neue"',
        'Arial',
        '"Noto Sans"',
        'sans-serif',
        '"Apple Color Emoji"',
        '"Segoe UI Emoji"',
        '"Segoe UI Symbol"',
        '"Noto Color Emoji"',
      ],
      // serif: ['ui-serif', 'Georgia', 'Cambria', '"Times New Roman"', 'Times', 'serif'],
      // mono: [
      //   'ui-monospace',
      //   'SFMono-Regular',
      //   'Menlo',
      //   'Monaco',
      //   'Consolas',
      //   '"Liberation Mono"',
      //   '"Courier New"',
      //   'monospace',
      // ],
      cursive: [
        '"Pacifico"',
        'cursive'
      ]
    },
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/aspect-ratio'),
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography')
  ],
};
