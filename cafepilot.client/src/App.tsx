import { useEffect, useState } from 'react';
import './App.css';
import CafeList from './CafeComponent/CafeComponent';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import CafeOrder from './CafeOrder/CafeOrder';


function App() {

    useEffect(() => {
    }, []);

  console.log('App rendered');

 return (
    <BrowserRouter>
    <div className='pageContainer'>
   
      <Routes>
        <Route path="/" element={<CafeList />} />
        <Route path="/cafe/:id" element={<CafeOrder />} />
      </Routes>

    </div>
        </BrowserRouter>
  );
}

export default App;