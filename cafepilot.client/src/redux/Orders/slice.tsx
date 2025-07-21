import { createSlice, type PayloadAction } from '@reduxjs/toolkit';
import { fetchOrderByCafe } from './operation';



import type { Order } from './types';

interface OrderState {
  items: Order[];
  isLoading: boolean;
  error: string | null;
  filter: string;
}


const initialState: any = {
  items: [],
  isLoading: false,
  error: null,
  filter: '',
};

export const orderSlice = createSlice({
name:"order",
initialState,
reducers:{
     updateFilter: (state, action: PayloadAction<string>) => {
      state.filter = action.payload;
    },
},
extraReducers:builder =>{
    builder.addCase(fetchOrderByCafe.fulfilled, (state, action: PayloadAction<any[]>)=>{
        state.isLoading = false;
        state.console.error=null;
        state.items = action.payload;
})
}
})


export const { updateFilter } = orderSlice.actions;
export default orderSlice.reducer;