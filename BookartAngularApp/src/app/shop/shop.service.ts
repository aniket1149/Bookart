import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAuthor } from '../shared/models/IAuthor';
import { ICategory } from '../shared/models/ICategory';
import { IPagination } from '../shared/models/IPagination';
import {map} from 'rxjs/Operators'
import { BookParams } from '../shared/models/BookParams';
import { IBooks } from '../shared/models/IBooks';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:44348/api/';
  constructor(private http: HttpClient) {  }
  getAllBooks(bookParams: BookParams) {
    let params = new HttpParams();
    if(bookParams.categoryId  !==0){
      params= params.append('categoryId', bookParams.categoryId.toString());
    }
    if(bookParams.authorId !==0){
      params= params.append('authorId', bookParams.authorId.toString());
    }
    if(bookParams.search){
      params=params.append('search', bookParams.search);
    }

    params=params.append('sort', bookParams.sort);

    params=params.append('pageIndex',bookParams.pageNumber.toString());
    params=params.append('pageSize', bookParams.pageSize.toString());
    return this.http.get<IPagination>(this.baseUrl+'Books',{observe:'response', params})
    .pipe(
      map(res=>{
        return res.body;
      }
        )
    );
  }
  getBookDetail(id:number){
    return this.http.get<IBooks>(this.baseUrl+'Books/'+id);
  }
  getCategories(){
    return this.http.get<ICategory[]>(this.baseUrl+'Books/Categories');
  }
  getAuthors(){
    return this.http.get<IAuthor[]>(this.baseUrl+'Books/Authors');
  }

}
