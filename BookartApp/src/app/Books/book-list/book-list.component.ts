import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/Services/booking.service';
import { IBooks } from '../IBooks';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  Books: Array<IBooks>;
  constructor(private bookingService: BookingService) { }

  ngOnInit() {
    this.bookingService.getAllBooks().subscribe(
      data=>{this.Books = data}
    );
  }

}
