import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import { BookParams } from '../shared/models/BookParams';
import { IAuthor } from '../shared/models/IAuthor';
import { IBooks } from '../shared/models/IBooks';
import { ICategory } from '../shared/models/ICategory';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  @ViewChild('search',{static:true}) searchTerm : ElementRef
  books: IBooks[];
  categories : ICategory[];
  authors: IAuthor[];
  bookParams= new BookParams();
  totalCount : number;
  sortOptions=[
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price Low -> High', value:'priceAsc'},
    {name: 'Price High -> Low', value: 'priceDesc'}
  ]
  constructor(private shopService:ShopService) { }

  ngOnInit(): void {
    this.getBooks();
    this.getAuthors();
    this.getCategories();
  }
  getBooks(){
    this.shopService.getAllBooks(this.bookParams).subscribe(res=>{
      this.books = res.data;
      this.bookParams.pageNumber = res.pageIndex;
      this.bookParams.pageSize = res.pageSize;
      this.totalCount = res.count;
    },error=>{
      console.log(error);
    })
  }
  getCategories(){
    this.shopService.getCategories().subscribe(res=>{
      this.categories = [{id:0, categoryName:'All'},...res];
    },error=>{
      console.log(error);
    })
  }

  getAuthors(){
    this.shopService.getAuthors().subscribe(res=>{
      this.authors = [{id:0, authorName:'All'},...res];
    },error=>{
      console.log(error);
    })
  }

  onCategorySelected(categoryId: number){
    this.bookParams.categoryId = categoryId;
    this.bookParams.pageNumber=1;
    this.getBooks();
  }

  onAuthorsSelected(authorId:number){
    this.bookParams.authorId = authorId;
    this.bookParams.pageNumber=1;
    this.getBooks();
  }

  onSortSelected(sort: string){
    this.bookParams.sort = sort;
    this.getBooks();
  }

  pageChanged(event:any){

    if(this.bookParams.pageNumber!==event){
      this.bookParams.pageNumber=event;
    this.getBooks();
    }

  }

  onCustomSearch(){
    this.bookParams.search = this.searchTerm.nativeElement.value;
    this.bookParams.pageNumber=1;

    this.getBooks();
  }

  onReset(){
    this.searchTerm.nativeElement.value='';
    this.bookParams = new BookParams();
    this.getBooks();
  }

}
