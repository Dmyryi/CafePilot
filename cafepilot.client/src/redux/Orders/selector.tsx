import type { RootState } from '../store';

export const selectOrders = (state: RootState) => state.order.items;

export const selectOrdersLoading = (state: RootState) => state.order.isLoading;

export const selectOrdersError = (state: RootState) => state.order.error;
