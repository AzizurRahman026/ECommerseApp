import { Component, inject, OnInit } from '@angular/core';
import { Product } from '../../shared/models/product';
import { ShopService } from '../../core/services/shop.service';
import { ProductItemComponent } from './product-item/product-item.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { FilterDialogComponent } from './filter-dialog/filter-dialog.component';
import { concatWith } from 'rxjs';


@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [ProductItemComponent, MatIconModule],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.css'
})
export class ShopComponent implements OnInit{
  private shopService = inject(ShopService);
  private dialogService = inject(MatDialog);
  title = 'MiniShop';

  products: Product[] = [];

  // this is for store the selected brands and types...
  selectedBrands: string[] = [];
  selectedTypes: string[] = [];


  ngOnInit(): void {
    this.initializeShop();
  }

  initializeShop() {
    this.shopService.getBrands();
    this.shopService.getTypes();
    this.shopService.getProducts().subscribe({
      next: response => this.products = response,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    });
  }

  openFilterDialog() {
    const dialogRef = this.dialogService.open(FilterDialogComponent, {
      minWidth: '250px',
      data: {
        selectedBrands: this.selectedBrands,
        selectedTypes: this.selectedTypes
      }
    });

    dialogRef.afterClosed().subscribe({
      next: result => {
        if (this.selectedBrands || this.selectedTypes) {
          // apply filter
          console.log("result selected Brand: " + this.selectedBrands);
          console.log("result selected Types: " + this.selectedTypes);
          
        this.shopService.getProducts(this.selectedBrands, this.selectedTypes).subscribe({
          next: response => this.products = response,
          error: error => console.log(error),
          complete: () => console.log("Complete to fetch from getProduct()")
        });
        }
      }
    })
  }
}
