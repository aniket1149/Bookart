import { Component, Input, OnInit } from '@angular/core';
import { IBooks } from 'src/app/shared/models/IBooks';

@Component({
  selector: 'app-book-item',
  templateUrl: './book-item.component.html',
  styleUrls: ['./book-item.component.css']
})
export class BookItemComponent implements OnInit {
  @Input() book : IBooks;
  constructor() { }

  ngOnInit(): void {
  }

}
