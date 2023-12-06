import type { StorybookConfig } from "@storybook/html-webpack5";
import path from 'path';
import postcss from 'postcss';
import tailwindcss from 'tailwindcss';
import autoprefixer from 'autoprefixer';

const config: StorybookConfig = {
  stories: [
    "../wwwroot/ts/stories/ui/**/*.stories.@(js|jsx|mjs|ts|tsx)",
  ],
  addons: [
    "@storybook/addon-links",
    "@storybook/addon-essentials",
    "@storybook/addon-interactions",
    {
      name: "@storybook/addon-postcss",
      options: {
        cssLoaderOptions: {
          importLoaders: 1
        },
        postcssLoaderOptions: {
          implementation: postcss
        }
      }
    }
  ],
  webpackFinal: async (config) => {
    if (!config.module || !config.module.rules) {
      throw new Error("Encountered an error during webpack configuration\nAt .storybook/main.ts\nAt webpackFinal");
    }

    config.module.rules.push({
      test: /\.css$/,
      use: [{
        loader: 'postcss-loader',
        options: {
          postcssOptions: { plugins: [tailwindcss, autoprefixer] }
        }
      }],
      include: path.resolve(__dirname, '../')
    })
    return config;
  },
  framework: {
    name: "@storybook/html-webpack5",
    options: {
      builder: {
        useSWC: true,
      },
    },
  },
  docs: {
    autodocs: "tag",
  },
};
export default config;
