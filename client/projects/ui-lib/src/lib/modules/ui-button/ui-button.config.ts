export type uiButtonVariants = 'default' | 'landing' | 'submit';

export const uiButtonVariantsConfig: { [key in uiButtonVariants]: string } = {
  default: '',
  landing: 'inline-block font-sans-heading bg-green-500 py-4 text-xl px-10 rounded-lg text-gray-50 font-bold duration-300 transition-colors disabled:bg-green-400 hover:bg-green-600 focus:bg-green-600',
  submit: 'block w-full hover:bg-green-600 focus:bg-green-600 duration-300 transition-colors bg-green-500 disabled:bg-green-400 disabled:cursor-default rounded-lg text-white px-4 py-2 font-semibold text-center'
}
