export interface OrderItem {
  productId: number;
  name: string;
  quantity: number;
  price: number;
}

export interface Feedback {
  rating: number;
  comment: string;
}

export interface Order {
  id: string;
  cafeId: string;
  phone: string | null;
  date: string; 
  items: OrderItem[];
  totalPrice: number;
  status: 'Pending' | 'Done' | string; 
  feedback: Feedback | null;
}
