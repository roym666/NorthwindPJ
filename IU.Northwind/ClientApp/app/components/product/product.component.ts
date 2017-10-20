import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
    constructor(public ps: ProductService) {

    }

    ngOnInit(): void {
        this.ps.getProducts('ch').then(x => console.log(x));
    }
}