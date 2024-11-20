import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  baseUrl = 'http://localhost:4201/api/'
  private http = inject(HttpClient);
  title = 'MiniShop';

  products: Product[] = [];


  ngOnInit(): void {
    this.http.get<any>(this.baseUrl + 'products').subscribe({
      next: response => this.products = response,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    })
  }
}
