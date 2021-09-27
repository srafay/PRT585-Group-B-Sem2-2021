import { Component, OnInit } from '@angular/core';
import { IAPIResponse } from './shared/models/apiresponse';
import { IProduct } from './shared/models/product';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Ecommerce';
  api_response!: IAPIResponse;
  products!: IProduct[];
  URL_BACKEND: string = 'https://localhost:44341/api';
  URL_GET_ALL_PRODUCTS: string = this.URL_BACKEND + '/Product/GetAllProducts/'

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get(this.URL_GET_ALL_PRODUCTS).subscribe((response: any) => {
      console.log(response); // Log to console for debugging purposes
      this.api_response = response;
      this.products = this.api_response.result_set;
    }, error => {
      console.log(error);
    })
  }
}

