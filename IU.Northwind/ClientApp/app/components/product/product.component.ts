import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { ProductModel } from './product.model';

import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
    productList: ProductModel[] = [];
    palabraBusqueda: string = '';
    respuesta: Observable<ProductModel[]>;
    private searchTerms = new BehaviorSubject(this.palabraBusqueda);

    constructor(public ps: ProductService) {

    }

    ngOnInit(): void {
        //this.ps.getProducts('').then(lista => this.productList = lista);

        //this.respuesta = this.searchTerms.
        //    debounceTime(300).           
        //    switchMap(term => term
        //        ? this.ps.getProducts(term)
        //        : Observable.of<ProductModel[]>());

        this.respuesta = this.searchTerms.
            debounceTime(300).
            switchMap(term => this.ps.getProducts(term));

        this.respuesta.subscribe(v => {
            this.productList = v;
        });

        //this.search();
    }//fin ngOnInit

    private search(): void {
        console.log(this.palabraBusqueda);

        this.searchTerms.next(this.palabraBusqueda);
    }
}