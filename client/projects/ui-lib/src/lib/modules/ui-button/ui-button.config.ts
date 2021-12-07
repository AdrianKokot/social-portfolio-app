export type uiButtonVariants = 'default' | 'submit' | 'primary' | 'secondary';

export const uiButtonVariantsConfig: { [key in uiButtonVariants]: string } = {
  default: '',
  // landing: 'inline-block font-sans-heading bg-green-600 py-4 text-xl px-10 rounded-lg text-gray-50 font-bold duration-300 transition-colors disabled:bg-green-500 hover:bg-green-700',
  submit: 'block w-full hover:bg-green-700 duration-300 transition-colors bg-green-600 loading:text-opacity-0 loading:bg-green-700 disabled:bg-green-400 disabled:cursor-default rounded-lg text-gray-50 px-4 py-2 font-medium text-center',
  primary: 'block w-full hover:bg-green-700 duration-300 transition-colors bg-green-600 loading:text-opacity-0 loading:bg-green-700 rounded-lg text-gray-50 py-1 px-2  focus:bg-green-700',
  secondary: 'block w-full hover:bg-gray-300 duration-300 transition-colors bg-gray-200 loading:text-opacity-0 loading:bg-gray-300 rounded-lg text-gray-700 py-1 px-2  focus:bg-gray-300'
}
