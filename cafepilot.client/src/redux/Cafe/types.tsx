export interface FotoCafe {
  urlDesctop: string;
}

export interface Cafe {
  id: string;
  city: string;
  cityId: string;
  street: string;
  geolat: string;  // или number, если хочешь
  geolon: string;
  fotoCafe: FotoCafe | null;  // теперь объект или null
  phoneNumber: string;
  startWork: string;
  endWork: string;
  rating: number;
  waitingTime: number;
  isOpen: number;  // можно сделать boolean, но для совпадения оставим number
  isOpenDescription: string | null;
}
