import { Component, OnInit, Input } from '@angular/core';
import { Application } from "../../../../models/application.model";

@Component({
  selector: 'app-query-card',
  templateUrl: './query-card.component.html',
  styleUrls: ['./query-card.component.scss']
})
export class QueryCardComponent implements OnInit {

  constructor() { }

  @Input() application: Application

  ngOnInit(): void {
  }

}
