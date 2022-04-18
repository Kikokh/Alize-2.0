import { Component, OnInit } from '@angular/core';
import { NavigationService } from '../services/navigation.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {
  showFiller = false;
  isSideBarExpander = true;
  constructor(private _navigationService: NavigationService) { }

  ngOnInit(): void {
    this._navigationService.isSideBarExpanded.subscribe(isSideBarExpander => {
      this.isSideBarExpander = isSideBarExpander;
    });
  }

}
