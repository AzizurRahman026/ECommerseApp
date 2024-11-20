import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../shared/models/product';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'http://localhost:4201/api/'
  private http = inject(HttpClient);

  getProducts() {
    return this.http.get<any>(this.baseUrl + 'products');
  }
}
