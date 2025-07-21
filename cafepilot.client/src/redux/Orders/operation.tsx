import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';
import type { Order } from './types'; // Предположим, что тип Order у тебя уже есть

axios.defaults.baseURL = 'http://localhost:5227/api';

export const fetchOrderByCafe = createAsyncThunk<Order[], string, { rejectValue: string }>(
  'orders/fetchByCafe',
  async (cafeId, { rejectWithValue }) => {
    try {
      const response = await axios.get(`/cafe/${cafeId}/orders`);
      return response.data;
    } catch (err: any) {
      return rejectWithValue(err.response?.data?.error?.message || 'Ошибка при загрузке заказов');
    }
  }
);
