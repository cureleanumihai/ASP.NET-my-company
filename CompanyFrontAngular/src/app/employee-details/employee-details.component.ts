import { Component, OnInit } from '@angular/core';
import { EmployeeDetailService } from '../shared/employee-detail.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styles: [
  ]
})
export class EmployeeDetailsComponent implements OnInit {

  constructor(public service: EmployeeDetailService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

}
