/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["../**/*{html,razor,js,cs}", "D:/LIN Services/Components/LIN.Calendar.Shared/**/*{html,razor,js,cs}"],
    theme: {
        screens: {
            'sm': '640px',
            'md': '768px',
            'dl': '910px',
            'lg': '1024px',
            'xl': '1280px',
            '2xl': '1536px',
        },
        extend: {
            colors: {

                'current': {
                    '50': '#fdf3f3',
                    '100': '#fae9e9',
                    '200': '#f6d5d6',
                    '300': '#eeb3b6',
                    '400': '#e4888e',
                    '500': '#d45662',
                    '600': '#c03e50',
                    '700': '#a12f42',
                    '800': '#872a3d',
                    '900': '#742739',
                    '950': '#40111a'
                }
            }
      },
  },
  plugins: [],
}

