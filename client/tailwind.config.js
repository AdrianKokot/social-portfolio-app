module.exports = {
  mode: 'jit',
  purge: ['./projects/**/src/**/*.{html,ts}'],
  darkMode: 'class',
  theme: {
    extend: {
    },
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
