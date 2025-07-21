import type { RootState } from '../store';



export const selectCafeItems = (state: RootState) => state.cafe.items;

export const selectCafeIsLoading = (state: RootState) => state.cafe.isLoading;

export const selectCafeError = (state: RootState) => state.cafe.error;
