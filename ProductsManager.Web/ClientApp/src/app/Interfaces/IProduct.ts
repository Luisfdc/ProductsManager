

export interface IProduct {
  id: number;
  description: string;
  price: number;
  image: string;
}

export class Product implements IProduct {

  id: number;
  description: string;
  price: number;
  image: string;
}

