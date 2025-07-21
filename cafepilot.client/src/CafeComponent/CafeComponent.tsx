import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { selectCafeItems, selectCafeIsLoading, selectCafeError } from '../redux/Cafe/selector';
import { useDispatch } from 'react-redux';
import { useEffect } from 'react';
import { fetchCafe } from '../redux/Cafe/operations';
import type { AppDispatch } from '../redux/store';
import styles from './CafeComponent.module.scss';
import { Star } from 'lucide-react';

const CafeList = () => {
  const cafes = useSelector(selectCafeItems);
  const isLoading = useSelector(selectCafeIsLoading);
  const error = useSelector(selectCafeError);
  const navigate = useNavigate();

 const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    dispatch(fetchCafe());
   console.log(cafes);
  }, [dispatch]);


  if (isLoading) return <p>Завантаження...</p>;
  if (error) return <p>Помилка: {error}</p>;

return (
   <div className={styles.dashboard}>
    {cafes.map(cafe => (
      <div
        key={cafe.id}
        className={styles.card}
        style={{ backgroundImage: `url(${cafe.fotoCafe?.urlDesctop || '/default-cafe.jpg'})` }}
      onClick={() => navigate(`/cafe/${cafe.id}`)}
      >
        <div className={styles.overlay}>
          <div className={styles.topRight}>
            <Star size={16} color="gold" fill="gold" />
            <span>{cafe.rating}</span>
          </div>

          <div className={styles.bottomLeft}>
            <p className={styles.address}>{cafe.city}, {cafe.street}</p>
            <p className={cafe.isOpen ? styles.open : styles.closed}>
              {cafe.isOpen ? 'Открыто' : 'Закрыто'}
            </p>
          </div>
        </div>
      </div>
    ))}
  </div>
);

};


export default CafeList;

