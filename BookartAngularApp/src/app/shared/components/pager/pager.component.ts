import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {
  @Input() totalCount: number;
  @Input() pageSize: number;
  @Output() pagerChangedPage = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }
  onPagerChange(event: any){
      this.pagerChangedPage.emit(event.page);
  }
}
