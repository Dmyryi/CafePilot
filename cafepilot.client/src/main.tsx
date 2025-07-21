import React from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import { store, persistor } from './redux/store';
import { PersistGate } from 'redux-persist/integration/react';
import App from './App';
import './index.css';
// ReactDOM.createRoot(document.getElementById('root')!).render(

// );


const rootElement = document.getElementById('root');
console.log('rootElement:', rootElement);

if (rootElement) {
  ReactDOM.createRoot(rootElement).render(
   <React.StrictMode>
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <App />
      </PersistGate>
    </Provider>
  </React.StrictMode>
  );
} else {
  console.error('Root element not found');
}
