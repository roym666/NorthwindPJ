import { Injectable } from '@angular/core';
import { Headers, Http, URLSearchParams } from '@angular/http';
import { ProductModel } from './product.model';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ProductService {

    private productUrl = 'api/product';  // URL to web api... controller MVC
    private headers = new Headers({ 'Content-Type': 'application/json' });
    constructor(private http: Http) { }

    getProducts(nombre: string): Promise<ProductModel[]> {
        console.log('getproduct');
        return this.http.get(`${this.productUrl}?nombre=${nombre}`) //Se llama a cada uno de los metodos creados en el API
            .toPromise()
            .then(response => response.json().data as ProductModel[])
            .catch(this.handleError);
    }

    getProduct(id: number): Promise<ProductModel> {
        const url = `${this.productUrl}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as ProductModel)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        //console.error('An error occurred', error); // for demo purposes only
        console.log(error);
        return Promise.reject(error.message || error);
    }


}