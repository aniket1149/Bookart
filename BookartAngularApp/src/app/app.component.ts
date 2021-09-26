import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IBooks } from './models/IBooks';
import { IPagination } from './models/IPagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  books: IBooks[];
  title = 'BookartAngularApp';
  constructor(private http:HttpClient){}

  ngOnInit(): void {
    this.http.get('https://localhost:44348/api/Books').subscribe((res:IPagination)=>{
      this.books = res.data;
    },error =>{
      console.log(error);
    })
  }
}
