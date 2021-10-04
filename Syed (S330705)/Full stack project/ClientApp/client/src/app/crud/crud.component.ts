import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';
import { CrudService } from './crud.service';
import { IAPIResponse } from '../shared/models/apiresponse';
import { ICrudResponse } from '../shared/models/crudresponse';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css']
})
export class CrudComponent implements OnInit {

  dataSaved = false;  
  employeeForm: any;  
  response:any;
  allEmployees?: IProduct[];  
  employeeIdUpdate:any;  
  massage = '';
  
  constructor(private formbulider: FormBuilder, private employeeService:CrudService) { }  
  
  ngOnInit() {  
    this.employeeForm = this.formbulider.group({  
      id: [Number(''), [Validators.required]],  
      product_name: ['', [Validators.required]],  
      product_description: ['', [Validators.required]],  
      product_price: ['', [Validators.required]],  
      product_pictureurl: ['', [Validators.required]],  
      product_type: ['', [Validators.required]],  
      product_brand: ['', [Validators.required]],  
    });  
    this.loadAllEmployees();  
  }  
  loadAllEmployees() {  
    this.employeeService.getAllEmployee().subscribe((response: any) => {
      this.allEmployees = response.result_set;
      console.log(this.allEmployees);
    }, (error: any) => {
      console.log(error);
    })
  }  
  onFormSubmit(value: any) {  
    this.dataSaved = false;  
    const employee = value;  
    this.CreateEmployee(employee);  
    this.employeeForm.reset();  
  }  
  loadEmployeeToEdit(employeeId: number) {
    // this.resetForm();  
    this.employeeService.getEmployeeById(employeeId).subscribe(employee=> {  
      this.employeeForm.reset();  
      this.massage = '';  
      this.dataSaved = false;  
      this.employeeIdUpdate = Number(employee.result_set.id);  
      this.employeeForm.controls['product_name'].setValue(employee.result_set.product_name);  
     this.employeeForm.controls['product_description'].setValue(employee.result_set.product_description);  
      this.employeeForm.controls['product_price'].setValue(Number(employee.result_set.product_price));  
      this.employeeForm.controls['product_pictureurl'].setValue(employee.result_set.product_pictureurl);  
      this.employeeForm.controls['product_type'].setValue(employee.result_set.product_type);  
      this.employeeForm.controls['product_brand'].setValue(employee.result_set.product_brand);  
    });  
  
  }  
  CreateEmployee(employee: IProduct) {  
    if (this.employeeIdUpdate == null) {  
      this.employeeService.createEmployee(employee).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.massage = 'Record saved Successfully';  
          this.loadAllEmployees();  
          this.employeeIdUpdate = null;  
          this.employeeForm.reset();  
        }  
      );  
    } else {  
      employee.id = this.employeeIdUpdate;
      
      this.employeeService.updateEmployee(employee).subscribe(() => {  
        this.dataSaved = true;  
        this.massage = 'Record Updated Successfully';  
        this.loadAllEmployees();  
        this.employeeIdUpdate = null;  
        this.employeeForm.reset();  
      });  
    }  
  }   
  deleteEmployee(employeeId: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.employeeService.deleteEmployeeById(employeeId).subscribe(() => {  
      this.dataSaved = true;  
      this.massage = 'Record Deleted Succefully';  
      this.loadAllEmployees();  
      this.employeeIdUpdate = null;  
      this.employeeForm.reset();  
  
    });  
  }  
}  
  resetForm() {  
    this.employeeForm.reset();  
    this.massage = '';  
    this.dataSaved = false;  
  }

}
