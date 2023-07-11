import { Component, OnInit } from '@angular/core';
import { Fornecedor } from '../models/Fornecedor';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FornecedorService } from './fornecedor.service';

@Component({
  selector: 'app-fornecedor',
  templateUrl: './fornecedor.component.html',
  styleUrls: ['./fornecedor.component.css']
})
export class FornecedorComponent{

  public titulo = 'Fornecedores';
  public fornecedorForm!: FormGroup;// | undefined;
  public fornecedorSelecionado: Fornecedor | undefined;
  public modoSave = 'post' as any;

  constructor(private fb: FormBuilder,
              private fornecedorService: FornecedorService){
    this.criarForm();
  }

  criarForm(){
      this.fornecedorForm = this.fb.group({
        id: [0],
        razaoSocial: ['', Validators.required],
        cnpj:['', Validators.required], 
        uf:['', Validators.required], 
        email:['', Validators.required], 
        contato:['', Validators.required], 
        nomeContato:['', Validators.required]
      });
  }

  fornecedorSelect(fornecedor: Fornecedor){
    this.fornecedorSelecionado = fornecedor;
    this.fornecedorForm.patchValue(fornecedor);
  }
  fornecedorNovo(){
    this.fornecedorSelecionado = new Fornecedor();
    this.fornecedorForm.patchValue(this.fornecedorSelecionado);
  }
  fornecedorSubimit(){
    this.salvarFornecedor(this.fornecedorForm.value);
  }

  voltar(){
    this.fornecedorSelecionado = undefined;
  }

  salvarFornecedor(fornecedor: Fornecedor){
    (fornecedor.id == 0) ? this.modoSave = 'post' : this.modoSave = 'put';

    if (this.modoSave === 'post') {
      this.fornecedorService.post(fornecedor).subscribe(
        () => {
          this.carregarFornecedores();
        }, (error: any) => { 
          console.error(error);
        }, 
      );
    } else {
      this.fornecedorService.put(fornecedor).subscribe(
        () => {
          this.carregarFornecedores();
        }, (error: any) => { 
          console.error(error);
        }, 
      );
    }
  }

  public fornecedores!: Fornecedor[];

  ngOnInit(){
    this.carregarFornecedores();
  }
  carregarFornecedores(){
    this.fornecedorService.getAll().subscribe(
      (fornecedores: Fornecedor[])=>{
        this.fornecedores = fornecedores;
      },
      (erro: any)=>{
        console.error(erro)
      }
    );
  }

  deletarFornecedor(id: number){
    this.fornecedorService.delete(id).subscribe(
      (model: any) =>{
        console.log(model);
        this.carregarFornecedores(); 
      },
      (erro: any) =>{
        console.error(erro); 
      }
    );

  }
}
