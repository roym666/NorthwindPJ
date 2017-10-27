import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product/product.service';
import { ProductModel } from '../product/product.model';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
    selector: 'product-detail',
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {


    constructor(private route: ActivatedRoute, private router: Router, public ps: ProductService) {

    }

    ngOnInit(): void {
        let id = this.route.snapshot.params['id'];

        this.ps.getProduct(id)
            .then(product => console.log(product));
    }//fin ngOnIni

}