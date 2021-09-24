import { Component, Input, OnInit } from '@angular/core';
import { IBooks } from '../IBooks';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrls: ['./book-card.component.css']
})
export class BookCardComponent implements OnInit {
  @Input() Book : IBooks;
  constructor() { }

  ngOnInit(): void {
  }

}
