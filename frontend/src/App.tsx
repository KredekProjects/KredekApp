import React from 'react';
import { ThemeProvider } from 'styled-components';

import { theme } from 'lib';
import { Routing } from 'routing';
import { GlobalStyle } from 'style';

export const App: React.FC = () => (
  <>
    <GlobalStyle />
    <ThemeProvider theme={theme}>
      <Routing />
    </ThemeProvider>
  </>
);
