import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from '../Interfaces/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private http: HttpClient;

  constructor(httpClient: HttpClient) {
    this.http = httpClient;
  }


  GetProduct(id: number) {
    return this.http.get<any>('/api/Product/'+id);
  }

  GetAllProducts() {
    return this.http.get<any>('/api/Product');
  }

  AddProduct(product: IProduct) {
    return this.http.post<any>('/api/Product', product);
  }


  UpdateProduct(product: IProduct) {
    return this.http.put<any>('/api/Product', product);
  }


  DeleteProduct(id: number) {
    return this.http.delete<any>('/api/Product/' + id);
  }

}
