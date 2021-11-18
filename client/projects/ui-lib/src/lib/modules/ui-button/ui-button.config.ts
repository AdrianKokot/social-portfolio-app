export type uiButtonVariants = 'default' | 'submit';

export const uiButtonVariantsConfig: { [key in uiButtonVariants]: string } = {
  default: '',
  // landing: 'inline-block font-sans-heading bg-green-600 py-4 text-xl px-10 rounded-lg text-gray-50 font-bold duration-300 transition-colors disabled:bg-green-500 hover:bg-green-700',
  submit: 'block w-full hover:bg-green-700 duration-300 transition-colors bg-green-600 loading:text-opacity-0 loading:bg-green-700 disabled:bg-green-400 disabled:cursor-default rounded-lg text-gray-50 px-4 py-2 font-semibold text-center'
}
