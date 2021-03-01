import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { IProduct, Product } from '../../Interfaces/IProduct';
import { Router } from '@angular/router';
declare var $;
@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css']
})
export class ListProductsComponent implements OnInit {
  @ViewChild('dataTable', { static: false }) table;
  dataTable: any;
  private _productService: ProductService;
  products: Product[];

  constructor(productService: ProductService, private router: Router) {
    this._productService = productService;
  }


  private montarTabela = function () {

    this.dtOptions = {

      "pagingType": "full_numbers",

      "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],

      responsive: true,

      language: {

        lengthMenu: "Exibir _MENU_ por paginas",

        zeroRecords: "Vazio",

        info: "Mostrando _PAGE_ de _PAGES_ paginas",

        infoEmpty: "Nenhum item para exibir",

        infoFiltered: "(filtered from _MAX_ total records)",

        search: "Buscar",

        oPaginate: {

          sNext: "Pr&oacuteximo",

          sPrevious: "Anterior",

          sFirst: "Primeiro",

          sLast: "&Uacuteltimo"

        }

      }



    };
    this.dataTable = $(this.table.nativeElement);

    this.dataTable.DataTable(this.dtOptions);
  }


  private listarProducts() {

   
  }

  ngOnInit(): void {
    var self = this;
    this._productService.GetAllProducts().subscribe(result => {
      this.products = result;
      console.log(result);
      setTimeout(function () {
        self.montarTabela();
      }, 10);
    });
  }


  deleteProduct(id: number) {
    this._productService.DeleteProduct(id).subscribe(result => {
      this._productService.GetAllProducts().subscribe(result => {
        this.products = result;
      });
    });
  }


  openProduct(id: number) {
    this.router.navigate(['/Product/'+ id]);
  }
}
