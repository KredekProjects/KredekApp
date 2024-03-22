import { createGlobalStyle } from 'styled-components';

import { theme } from 'lib';

export const GlobalStyle = createGlobalStyle`
    html{
        font-size: ${theme.font.size.medium};
    }

    body {
        background-color: #fff;
        font-family: 'Roboto', sans-serif;
        margin: 0;
        overflow: hidden;
        padding: 0;
    }
`;
