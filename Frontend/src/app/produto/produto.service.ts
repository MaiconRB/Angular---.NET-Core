import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Produto } from '../models/Produto';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ProdutoService{

    baseUrl = `${environment.UrlPrincipal}/api/produto`;
    constructor(private http: HttpClient){}

    getAll(): Observable<Produto[]> {
        return this.http.get<Produto[]>(`${this.baseUrl}`);
    }

    getById(id: number): Observable<Produto> {
        return this.http.get<Produto>(`${this.baseUrl}/${id}`);
    }

    post(produto: Produto){
        return this.http.post(`${this.baseUrl}`,produto);
    }

    put(produto: Produto){
        return this.http.put(`${this.baseUrl}/${produto.produtoId}`,produto);
    }

    delete(id: number) {
        return this.http.delete<Produto>(`${this.baseUrl}/${id}`);
    }
}