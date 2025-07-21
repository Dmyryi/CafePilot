import { useSelector, useDispatch } from 'react-redux';
import { useParams } from 'react-router-dom';
import { useEffect } from 'react';
import { fetchOrderByCafe } from '../redux/Orders/operation';
import { selectOrders, selectOrdersLoading, selectOrdersError } from '../redux/Orders/selector';
import type { AppDispatch } from '../redux/store';
import type { Order } from '../redux/Orders/types';

const CafeOrder = () => {
  const { id } = useParams<{ id: string }>();

  const orders = useSelector(selectOrders) ?? [];
  const isLoading = useSelector(selectOrdersLoading);
  const error = useSelector(selectOrdersError);

  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    if (id) {
      dispatch(fetchOrderByCafe(id));
    }
  }, [dispatch, id]);

  if (isLoading) return <p>Завантаження...</p>;
  if (error) return <p>Помилка: {error}</p>;

  return (
    <div>
      <h2>Заказы для кафе {id}</h2>
      {orders.length === 0 ? (
        <p>Заказов нет.</p>
      ) : (
        orders.map((order: Order) => (
          <div key={order.id} style={{ border: '1px solid #ccc', marginBottom: 10, padding: 10 }}>
            <p>Телефон: {order.phone || 'Не указан'}</p>
            <p>Статус: {order.status}</p>
            <p>Итого: {order.totalPrice} грн</p>
            <ul>
              {order.items.map(item => (
                <li key={item.productId}>
                  {item.name} - {item.quantity} x {item.price} грн
                </li>
              ))}
            </ul>
            {order.feedback && (
              <p>Отзыв: {order.feedback.comment} (Оценка: {order.feedback.rating})</p>
            )}
          </div>
        ))
      )}
    </div>
  );
};

export default CafeOrder;
