import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';


axios.defaults.baseURL = 'http://localhost:5227/api';

export const fetchCafe = createAsyncThunk(
    "cafe/fetchAll",
    async(_,thunkAPI)=>{
        try{
const res = await axios.get('/cafe')
        
return res.data;
}catch(error){
console.error('Error fetching contacts:', error);
      
      throw error;
        }
    }
)