import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { Provider } from 'react-redux';
import { employeSlice} from './Store/redux';
import { configureStore } from '@reduxjs/toolkit';
import { departeSlice } from './Store/departeSlice';

// Store
export const store = configureStore({
  reducer : {
      employesData:employeSlice.reducer,
      departementsData:departeSlice.reducer,
  }
});

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);


