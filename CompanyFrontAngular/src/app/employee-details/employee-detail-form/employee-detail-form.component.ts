import { Component, OnInit } from '@angular/core';
import { EmployeeDetailService } from 'src/app/shared/employee-detail.service';
import { NgForm } from '@angular/forms';
import { EmployeeDetail } from 'src/app/shared/employee-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-detail-form',
  templateUrl: './employee-detail-form.component.html',
  styles: [
  ]
})
export class EmployeeDetailFormComponent implements OnInit {

  constructor(public service:EmployeeDetailService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
      this.service.postEmployeeDetail().subscribe(
        res =>{
            this.resetForm(form);
            this.toastr.success('Submit succesfully','Employee Register')
        },
        err =>{ console.log(err);}
      )
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new EmployeeDetail();
  }


}
