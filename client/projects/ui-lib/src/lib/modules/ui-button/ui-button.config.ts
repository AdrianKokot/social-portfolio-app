export type uiButtonVariants = 'default' | 'landing';

export const uiButtonVariantsConfig: { [key in uiButtonVariants]: string } = {
  default: '',
  landing: 'inline-block font-sans-heading bg-green-500 py-4 text-xl px-10 rounded-lg text-gray-50 font-bold duration-300 transition-colors hover:bg-green-700 focus:bg-green-700'
}
