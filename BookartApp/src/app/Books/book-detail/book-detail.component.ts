import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  public bookId: number;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.bookId= this.route.snapshot.params['id'];
  }

}
