import 'styled-components';

declare module 'styled-components' {
  export interface DefaultTheme {
    color: {
      blue: {
        primary: string;
      };
    };
    radius: {
      primary: string;
      small: string;
      full: string;
    };
    spacing: {
      small: string;
      mid: string;
      big: string;
      huge: string;
    };
    font: {
      weight: {
        normal: number;
        medium: number;
        semiBold: number;
        bold: number;
      };
      size: {
        small: string;
        medium: string;
      };
    };
  }
}
