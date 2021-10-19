import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
// import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { catchError, map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IAPIResponse } from '../shared/models/apiresponse';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:44341/api/';
  // baseUrl = 'https://10.0.2.2:44341/api/Product';

  constructor(private http: HttpClient) { }

  errorHandler(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.log('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.log(
        `Backend returned code ${error.status}, ` +
        `body was: ${JSON.stringify(error.error)}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    // if (shopParams.brandId !== 0) {
    //   params = params.append('brandId', shopParams.brandId.toString())
    // }

    // if (shopParams.typeId !== 0) {
    //   params = params.append('typeId', shopParams.typeId.toString())
    // }

    // if (shopParams.search) {
    //   params = params.append('search', shopParams.search)
    // }

    // params = params.append('sort', shopParams.sort);
    // params = params.append('pageIndex', shopParams.pageNumber.toString());
    // params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IAPIResponse>(this.baseUrl + 'product/getAllProducts', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'product/GetAllBrands').pipe(catchError(this.errorHandler));  // catch error;
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'product/GetAllTypes').pipe(catchError(this.errorHandler));  // catch error;
  }
}