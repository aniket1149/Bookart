import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { IBooks } from '../Books/IBooks';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

constructor(private http: HttpClient) { }
getAllBooks(): Observable<IBooks[]>{
  return this.http.get('data/books.json').pipe(
    map(data=>
      {
        const bookArray : Array<IBooks>=[];
        for(const id in data){
        if(data.hasOwnProperty(id))
        {
         bookArray.push(data[id]);
        }
      }
      return bookArray;
    })
  );
}
}
