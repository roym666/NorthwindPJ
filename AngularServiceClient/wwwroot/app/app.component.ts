import { Component, OnInit } from '@angular/core';

import { ProductService } from './product.service';
import { IProduct } from './IProduct';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    providers: [ProductService]
})
export class AppComponent implements OnInit {

    products: Observable<IProduct[]>;
    constructor(private ps: ProductService) { }

    ngOnInit(): void {
        console.log('appcomponent.oninit');

        this.products = this.ps.getProducts();
    }
}
