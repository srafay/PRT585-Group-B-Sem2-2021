import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';
import { CrudService } from './crud.service';
import { IAPIResponse } from '../shared/models/apiresponse';
import { ICrudResponse } from '../shared/models/crudresponse';
import { NotificationService } from '@progress/kendo-angular-notification';
import { IKendoNotifStyles } from '../shared/models/kendonotificationstyles';
import { ViewportScroller } from '@angular/common';
import { ActionsLayout } from '@progress/kendo-angular-dialog';
import { DialItem } from '@progress/kendo-angular-buttons';
import { pdf } from '@progress/kendo-drawing';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.css']
})
export class CrudComponent implements OnInit {

  // // Only use if we want to display notification in a specific container tagged with #appendTo
  // @ViewChild("appendTo", { read: ViewContainerRef })
  // public appendTo?: ViewContainerRef;

  dataSaved = false;  
  employeeForm: any;  
  response:any;
  allEmployees?: IProduct[];  
  employeeIdUpdate:any;  
  message = '';

  /* Kendo variables */
  opened: boolean = false;
  actionsLayout: ActionsLayout = "normal";
  primaryValue: boolean = true;

  public exportItems: Array<DialItem> = [
    { icon: "email", label: "Send as Email", disabled: true },
    { icon: "clip", label: "Save as PDF" },
    { icon: "file-txt", label: "Save as Excel file", disabled: true }
  ];

  public clicked = false;
  public clickedContact?: DialItem;

  public onDialItemClick(event: any, viewHook:any): void {
    this.clickedContact = event.item;
    this.clicked = true;
    // Check if PDF option was clicked
    if (this.clickedContact?.icon == "clip") {
      viewHook.saveAs('products_list.pdf');
    }
  }
  /* Kendo variables */
  
  constructor(private formbulider: FormBuilder, private employeeService:CrudService,
    private notificationService: NotificationService,
    private readonly viewport: ViewportScroller) { }
  
  ngOnInit() {  
    this.employeeForm = this.formbulider.group({  
      id: [Number(''), []],  
      product_name: ['', [Validators.required]],  
      product_description: ['', [Validators.required]],  
      product_price: ['', [Validators.required]],  
      product_pictureurl: ['', []],  // optional field
      product_type: ['', [Validators.required]],  
      product_brand: ['', [Validators.required]],  
    });  
    this.loadAllEmployees();  
  }

  public onDialogClose() {
    this.showSuccess("No data was deleted", "info", "slide", "center");
    this.opened = false;
    this.employeeIdUpdate = null;
  }

  public onDeleteData() {
    this.deleteEmployee(this.employeeIdUpdate);
    this.opened = false;
  }

  public open(prod_id: number) {
    this.opened = true;
    this.employeeIdUpdate = prod_id;
  }

  onScrollToTop(): void {
    this.viewport.scrollToPosition([0, 0]);
  }

  onScrollToBottom(): void {
    this.viewport.scrollToPosition([0, 100000000]);
  }

  public showSuccess(message: string, notifStyle: IKendoNotifStyles["notifStyle"], animType: IKendoNotifStyles["animType"], horizontalPos: IKendoNotifStyles["horizontalPos"]): void {
    // console.log("showSuccess called");
    this.notificationService.show({
      // appendTo: this.appendTo,
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
      this.employeeForm.controls['id'].setValue(Number(employee.result_set.id));
      this.employeeForm.controls['product_name'].setValue(employee.result_set.product_name);
     this.employeeForm.controls['product_description'].setValue(employee.result_set.product_description);  
      this.employeeForm.controls['product_price'].setValue(Number(employee.result_set.product_price));  
      this.employeeForm.controls['product_pictureurl'].setValue(employee.result_set.product_pictureurl);  
      this.employeeForm.controls['product_type'].setValue(employee.result_set.product_type);  
      this.employeeForm.controls['product_brand'].setValue(employee.result_set.product_brand);  
      this.onScrollToTop();
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
          this.onScrollToBottom();
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
    this.employeeService.deleteEmployeeById(employeeId).subscribe(() => {  
    this.dataSaved = true;  
    this.message = 'Record Deleted Succefully';  
    this.loadAllEmployees();  
    this.employeeIdUpdate = null;
    this.employeeForm.reset();
    this.showSuccess(this.message, "warning", "slide", "left");
  
    });  
}  
  resetForm() {  
    this.employeeForm.reset();  
    this.message = '';  
    this.dataSaved = false;
    this.employeeIdUpdate = null;
  }

}
