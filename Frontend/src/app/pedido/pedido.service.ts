import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Pedido } from '../models/Pedido';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class PedidoService{

    baseUrl = `${environment.UrlPrincipal}/api/pedido`;
    constructor(private http: HttpClient){}

    getAll(): Observable<Pedido[]> {
        return this.http.get<Pedido[]>(`${this.baseUrl}`);
    }

    getById(id: number): Observable<Pedido> {
        return this.http.get<Pedido>(`${this.baseUrl}/${id}`);
    }
    getByIdFornecedor(fornecedorId: number): Observable<Pedido[]> {
        return this.http.get<Pedido[]>(`${this.baseUrl}/byfornecedor/${fornecedorId}`);
    }

    post(pedido: Pedido){
        return this.http.post(`${this.baseUrl}`,pedido);
    }

    put(pedido: Pedido){
        return this.http.put(`${this.baseUrl}/${pedido.codigoPedido}`,pedido);
    }

    delete(id: number) {
        return this.http.delete<Pedido>(`${this.baseUrl}/${id}`);
    }
}