import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/Operators';
import { IBooks } from '../shared/models/IBooks';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  books: IBooks[];
  baseUrl="https://localhost:44348/api/";
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getLatestBookAsync();
  }
  getLatestBookAsync() {
    this.http.get<IBooks[]>(this.baseUrl+'Books/latest')
    .pipe(
      map(res=>{
        return res;
      }
        )
    )

    .subscribe(b=>{
      this.books = b;
    });

  }

}
