import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAPIResponse } from '../shared/models/apiresponse';
import { ICrudResponse } from '../shared/models/crudresponse';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  response?: any;
  url = 'https://localhost:5001/api/Product';  
  constructor(private http: HttpClient) { }  
  getAllEmployee() {
    // console.log("getAllEmployee");
    this.response = this.http.get<any>(this.url + '/GetAllProducts');
    // console.log(this.response);
    return this.response;
  }  
  getEmployeeById(employeeId: number): Observable<ICrudResponse> {  
    // console.log("getEmployeeById");
    return this.http.get<ICrudResponse>(this.url + '/GetProductById?product_id=' + employeeId);
  }  
  createEmployee(employee: IProduct): Observable<ICrudResponse> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'accept': '*/*'}) };
    // console.log(employee);
    return this.http.post<ICrudResponse>(this.url + '/AddProduct/',  
    employee, httpOptions);  
  }  
  updateEmployee(employee: IProduct): Observable<ICrudResponse> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'accept': '*/*'}) };  
    // console.log(employee);
    return this.http.post<ICrudResponse>(this.url + '/UpdateProduct/',  
    employee, httpOptions);  
  }  
  deleteEmployeeById(employeeid: number): Observable<boolean> {  
    return this.http.get<boolean>(this.url + '/DeleteProduct?product_id=' + employeeid); 
  }  
} 
