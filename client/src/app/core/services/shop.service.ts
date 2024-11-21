import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../../shared/models/product';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'http://localhost:4201/api/'
  private http = inject(HttpClient);

  brands: string[] = [];
  types: string[] = [];

  getProducts(brands?: string[], types?: string[]) {
    let params = new HttpParams();

    if (brands && brands.length > 0) {
      params.append('brands', brands.join(','));
    }
    if (types && types.length > 0) {
      params.append('types', types.join(','));
    }

    return this.http.get<any>(this.baseUrl + 'products', {params});
  }

  getBrands() {
    this.http.get<string[]>(this.baseUrl + 'brands').subscribe({
      next: response => this.brands = response,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    });
    return this.brands;
  }

  getTypes() {
    this.http.get<string[]>(this.baseUrl + 'types').subscribe({
      next: response => this.types = response,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    });
    return this.types;
  }
}
