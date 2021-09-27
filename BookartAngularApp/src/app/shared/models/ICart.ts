import { v4 as uuid_v4 } from "uuid";
export interface ICart {

    id: string
    items: ICartItem[]

}
export interface ICartItem {
  id: number
  bookName: string
  price: number
  quantity: number
  pictureUrl: string
  categoryName: string
  authorName: string
}

export class Cart implements ICart{
  id = uuid_v4();
  items: ICartItem[]=[];

}

export interface ICartTotals{
  shipping : number;
  subtotal : number;
  total: number;
}
