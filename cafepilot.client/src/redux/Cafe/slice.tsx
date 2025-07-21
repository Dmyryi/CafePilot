import { createSlice, type PayloadAction } from '@reduxjs/toolkit';
import type { Cafe } from './types';
import { fetchCafe } from './operations';

interface CafeState {
  items: Cafe[];
  isLoading: boolean;
  error: string | null;
  filter: string;
}

const initialState: CafeState = {
  items: [],
  isLoading: false,
  error: null,
  filter: '',
};

export const cafeSlice = createSlice({
  name: 'cafe',
  initialState,
  reducers: {
    updateFilter: (state, action: PayloadAction<string>) => {
      state.filter = action.payload;
    },
  },
  extraReducers: builder => {
    builder.addCase(fetchCafe.fulfilled, (state, action: PayloadAction<Cafe[]>) => {
      state.isLoading = false;
      state.error = null;
      state.items = action.payload;
    });
  },
});

export const { updateFilter } = cafeSlice.actions;
export default cafeSlice.reducer;
