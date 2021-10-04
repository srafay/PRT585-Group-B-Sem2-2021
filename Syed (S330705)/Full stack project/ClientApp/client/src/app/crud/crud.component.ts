import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';
import { CrudService } from './crud.service';
import { IAPIResponse } from '../shared/models/apiresponse';
import { ICrudResponse } from '../shared/models/crudresponse';
import { NotificationService } from '@progress/kendo-angular-notification';
import { IKendoNotifStyles } from '../shared/models/kendonotificationstyles';

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
  message = '';
  
  constructor(private formbulider: FormBuilder, private employeeService:CrudService,
    private notificationService: NotificationService) { }
  
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

  public showSuccess(message: string, notifStyle: IKendoNotifStyles["notifStyle"], animType: IKendoNotifStyles["animType"], horizontalPos: IKendoNotifStyles["horizontalPos"]): void {
    // console.log("showSuccess called");
    this.notificationService.show({
      content: message,
      cssClass: "button-notification",
      animation: { type: animType, duration: 400 },
      position: { horizontal: horizontalPos, vertical: "bottom" },
      type: { style: notifStyle, icon: true },
      closable: false,
    });
  }

  loadAllEmployees() {  
    this.employeeService.getAllEmployee().subscribe((response: any) => {
      this.allEmployees = response.result_set;
      // console.log(this.allEmployees);
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
      this.message = '';  
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
      // Set employee id to 0 (random) to make sure API doesnt give error
      employee.id = 0;
      this.employeeService.createEmployee(employee).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Record saved Successfully';  
          this.loadAllEmployees();
          this.showSuccess(this.message, "success", "slide", "left");
          this.employeeIdUpdate = null;  
          this.employeeForm.reset();
        }  
      );  
    } else {  
      employee.id = this.employeeIdUpdate;
      
      this.employeeService.updateEmployee(employee).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Record Updated Successfully';  
        this.loadAllEmployees();  
        this.employeeIdUpdate = null;  
        this.employeeForm.reset();
        this.showSuccess(this.message, "info", "slide", "left");
      });  
    }  
  }   
  deleteEmployee(employeeId: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.employeeService.deleteEmployeeById(employeeId).subscribe(() => {  
      this.dataSaved = true;  
      this.message = 'Record Deleted Succefully';  
      this.loadAllEmployees();  
      this.employeeIdUpdate = null;  
      this.employeeForm.reset();
      this.showSuccess(this.message, "warning", "slide", "left");
  
    });  
  }  
}  
  resetForm() {  
    this.employeeForm.reset();  
    this.message = '';  
    this.dataSaved = false;  
  }

}
