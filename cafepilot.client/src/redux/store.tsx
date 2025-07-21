import { configureStore } from '@reduxjs/toolkit';
import {
  persistStore,
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from 'redux-persist';
import cafeReducer from './Cafe/slice';
import storage from 'redux-persist/lib/storage';

const persistConfig = {
  key: 'cafe',
  storage,
  whitelist: ['items', 'isLoading', 'error'],
};

// Оборачиваем редьюсер в persistReducer
const persistedCafeReducer = persistReducer(persistConfig, cafeReducer);

export const store = configureStore({
  reducer: {
   
    cafe: persistedCafeReducer,
  },
  middleware: getDefaultMiddleware =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    }),
  devTools: process.env.NODE_ENV === 'development',
});

export const persistor = persistStore(store);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
