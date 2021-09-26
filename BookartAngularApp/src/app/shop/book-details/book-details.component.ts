import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBooks } from 'src/app/shared/models/IBooks';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: IBooks;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
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
