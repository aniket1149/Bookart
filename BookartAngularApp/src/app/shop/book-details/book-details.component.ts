import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CartService } from 'src/app/cart/cart.service';
import { IBooks } from 'src/app/shared/models/IBooks';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: IBooks;
  quantity= 1;
  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute,private cartService: CartService) { }

  ngOnInit(): void {
    this.loadProduct();
  }
  addBookToCart(){
    this.cartService.addItemToCart(this.book, this.quantity);
  }

  incrementQuantity(){
    this.quantity++;
  }
  decrementQuantity(){
    if(this.quantity>1){
      this.quantity--;
    }

  }

  loadProduct(){

    this.shopService.getBookDetail(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(book=>{
      this.book = book;
    },
    error=>{
      console.log(error)
    }
    );
  }

}
