import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Fornecedor } from '../models/Fornecedor';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class FornecedorService{

    baseUrl = `${environment.UrlPrincipal}/api/fornecedor`;
    constructor(private http: HttpClient){}

    getAll(): Observable<Fornecedor[]> {
        return this.http.get<Fornecedor[]>(`${this.baseUrl}`);
    }

    getById(id: number): Observable<Fornecedor> {
        return this.http.get<Fornecedor>(`${this.baseUrl}/${id}`);
    }

    post(fornecedor: Fornecedor){
        return this.http.post(`${this.baseUrl}`,fornecedor);
    }

    put(fornecedor: Fornecedor){
        return this.http.put(`${this.baseUrl}/${fornecedor.id}`,fornecedor);
    }

    delete(id: number) {
        return this.http.delete<Fornecedor>(`${this.baseUrl}/${id}`);
    }
}