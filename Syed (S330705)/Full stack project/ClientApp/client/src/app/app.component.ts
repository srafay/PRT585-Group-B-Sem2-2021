import { Component, OnInit } from '@angular/core';
import { IAPIResponse } from './models/apiresponse';
import { IProduct } from './models/product';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Ecommerce';
  products: IProduct[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:44341/api/Product/GetAllProducts').subscribe((response: any) => {
      console.log(response);
      this.products = response.result_set;
    }, error => {
      console.log(error);
    })
  }
}

