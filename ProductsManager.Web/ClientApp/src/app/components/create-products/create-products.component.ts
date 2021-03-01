import { Component, OnInit } from '@angular/core';
import { Product } from '../../Interfaces/IProduct';
import { ProductService } from '../../services/product.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-products',
  templateUrl: './create-products.component.html',
  styleUrls: ['./create-products.component.css']
})
export class CreateProductsComponent implements OnInit {
  private _productService: ProductService;
  public product: Product;
  param: number;
  productId: number;


  constructor(productService: ProductService, private router: Router, private route: ActivatedRoute ) {
    this._productService = productService;
    this.product = new Product;

    this.route.params.subscribe(params => {
      this.param = params['id'];
      this.productId = this.param;
    });

    if (this.productId != null)
      this.getProduct(this.productId);

  }

  ngOnInit() {
  }

  getProduct(productId: number) {
    this._productService.GetProduct(productId).subscribe(result => {
      this.product = result;
    });
  }

  salvar(product: Product) {

    if (product.id > 0) {
      this._productService.UpdateProduct(product).subscribe(result => {
        this.router.navigate(['/ProductList']);
      });
    } else {
      this._productService.AddProduct(product).subscribe(result => {
        this.router.navigate(['/ProductList']);
      });
    }
  }


}
