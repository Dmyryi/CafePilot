import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { selectCafeItems, selectCafeIsLoading, selectCafeError } from '../redux/Cafe/selector';
import { useDispatch } from 'react-redux';
import { useEffect } from 'react';
import { fetchCafe } from '../redux/Cafe/operations';
import type { AppDispatch } from '../redux/store';
const CafeOrder = () => {

    return(
        <div>
            Hello!
        </div>
    )
}

export default CafeOrder;