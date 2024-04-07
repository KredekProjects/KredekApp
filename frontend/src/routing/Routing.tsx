import React from 'react';
import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from 'react-router-dom';

import { MainPage } from 'views/MainPage';

import { NotFound } from './NotFound';
import { RootRoutes } from './utils';

const RoutingWrapper: React.FC<{ children: React.ReactNode }> = ({ children }) => children;
export const Routing: React.FC = () => {
  const router = createBrowserRouter([
    {
      children: createRoutesFromElements(
        <>
          <Route
            path={RootRoutes.ROOT}
            element={
              <RoutingWrapper>
                <MainPage />
              </RoutingWrapper>
            }
          />
          <Route
            path="*"
            element={
              <RoutingWrapper>
                <NotFound />
              </RoutingWrapper>
            }
          />
        </>
      )
    }
  ]);
  return <RouterProvider router={router} />;
};
