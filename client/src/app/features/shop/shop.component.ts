import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product';
import { ShopService } from '../../core/services/shop.service';
import { ProductItemComponent } from './product-item/product-item.component';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [ProductItemComponent],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit{
  private shopService = inject(ShopService);
  title = 'MiniShop';

  products: Product[] = [];


  ngOnInit(): void {
    this.shopService.getProducts().subscribe({
      next: response => this.products = response,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    });
  }
}
