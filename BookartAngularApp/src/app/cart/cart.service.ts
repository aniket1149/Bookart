import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/Operators';
import { IBooks } from '../shared/models/IBooks';
import { Cart, ICart, ICartItem, ICartTotals } from '../shared/models/ICart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseUrl = 'https://localhost:44348/api/';
  private cartSource = new BehaviorSubject<ICart>(null);
  cart$ = this.cartSource.asObservable();
  private cartTotalSource = new BehaviorSubject<ICartTotals>(null);
  cartTotal$=this.cartTotalSource.asObservable();
  constructor(private http: HttpClient) { }

  getCart(id: string){
    return this.http.get(this.baseUrl+'Basket?id='+id).pipe(
      map(
        (cart:ICart)=>{
          this.cartSource.next(cart);
          this.calculateTotal();
        }
      )
    );
  }

  setCart(cart: ICart){
    return this.http.post(this.baseUrl+'Basket', cart).subscribe((response: ICart)=>
    {
      this.cartSource.next(response);
      this.calculateTotal();
    },error=>{
      console.log(error);
    });
  }

  getCurrentCartValue(){
    return this.cartSource.value;
  }

  addIncrementBookQuantity(item: ICartItem){
    const cart = this.getCurrentCartValue();
    const foundBookIndex= cart.items.findIndex(x=>x.id===item.id);
    cart.items[foundBookIndex].quantity++;
    this.setCart(cart);
  }
  decrementBookQuantity(item: ICartItem){
    const cart = this.getCurrentCartValue();
    const foundBookIndex= cart.items.findIndex(x=>x.id===item.id);
    if(cart.items[foundBookIndex].quantity>1){
      cart.items[foundBookIndex].quantity--;
      this.setCart(cart);
    }else{
      this.removeBookFromCart(item);
    }
    this.setCart(cart);
  }
  removeBookFromCart(item: ICartItem) {
    const cart = this.getCurrentCartValue();
    if(cart.items.some(x=>x.id===item.id)){
      cart.items = cart.items.filter(i=>i.id!==item.id);
      if(cart.items.length>0){
        this.setCart(cart);
      }else{
        this.deleteCart(cart);
      }

    }
  }
  deleteCart(cart: ICart) {
    return this.http.delete(this.baseUrl+'Basket/?id='+cart.id).subscribe(()=>{
      this.cartSource.next(null);
      this.cartTotalSource.next(null);
      localStorage.removeItem('basket_id');
    }, error=>{
      console.log(error);
    });
  }

  addItemToCart(item : IBooks, quantity =1){
    const itemToAdd: ICartItem=this.mapBookItemToCartItem(item, quantity);
    const currCart = this.getCurrentCartValue() ?? this.createCart();
    currCart.items = this.addOrUpdateItem(currCart.items, itemToAdd, quantity);
    this.setCart(currCart);
  }
  private addOrUpdateItem(items: ICartItem[], itemToAdd: ICartItem, quantity: number): ICartItem[] {
    const index = items.findIndex(i=> i.id === itemToAdd.id);
    if(index===-1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    }else{
      items[index].quantity +=quantity;
    }
    return items;
  }
  private calculateTotal(){
    const cart = this.getCurrentCartValue();
    const shipping = 0;
    const subtotal = cart.items.reduce((a,b)=>(b.price * b.quantity)+a, 0);
    const total=subtotal+shipping;
    this.cartTotalSource.next({shipping, total, subtotal});
  }
  private createCart(): ICart {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
  }
  private mapBookItemToCartItem(item: IBooks, quantity: number): ICartItem {
    console.log(item);
    return{
      id:item.id,
      bookName:item.bookName,
      price:item.price,
      pictureUrl : item.pictureUrl,
      quantity,
      categoryName : item.categoryName,
      authorName : item.bookAuthor,

    };
  }
}
