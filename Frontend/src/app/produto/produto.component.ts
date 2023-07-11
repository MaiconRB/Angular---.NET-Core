import { Component } from '@angular/core';
import { Produto } from '../models/Produto';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProdutoService } from './produto.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent {

  public titulo = 'Produtos';
  public produtoSelecionado: Produto | undefined;
  public produtoForm!: FormGroup;// | undefined;
  public modoSave = 'post' as any;

  constructor(private fb: FormBuilder,
              private produtoService: ProdutoService){
    this.criarForm();
  }

  criarForm(){
      this.produtoForm = this.fb.group({
        produtoId: [0],
        codigo: ['', Validators.required],
        descricao:['', Validators.required], 
        dataCadastro:['', Validators.required], 
        valorProduto:['', Validators.required]
      });
  }


  produtoSelect(produto: Produto){
    this.produtoSelecionado = produto;
    this.produtoForm.patchValue(produto);
  }
  produtoNovo(){
    this.produtoSelecionado = new Produto();
    this.produtoForm.patchValue(this.produtoSelecionado);
  }
  produtoSubimit(){
    this.salvarProduto(this.produtoForm.value);
  }
  voltar(){
    this.produtoSelecionado = undefined;
  }

  public produtos! : Produto[];
  
  ngOnInit(){
    this.carregarProduto();
  }
  carregarProduto(){
    this.produtoService.getAll().subscribe(
      (produtos: Produto[])=>{
        this.produtos = produtos;
      },
      (erro: any)=>{
        console.error(erro)
      }
    );
  }

  salvarProduto(produto: Produto){
    (produto.produtoId == 0) ? this.modoSave = 'post' : this.modoSave = 'put';

    if (this.modoSave === 'post') {
      this.produtoService.post(produto).subscribe(
        () => {
          this.carregarProduto();
        }, (error: any) => { 
          console.error(error);
        }, 
      );
    } else {
      this.produtoService.put(produto).subscribe(
        () => {
          this.carregarProduto();
        }, (error: any) => { 
          console.error(error);
        }, 
      );
    }
  }
  deletarProduto(id: number){
    this.produtoService.delete(id).subscribe(
      (model: any) =>{
        console.log(model);
        this.carregarProduto(); 
      },
      (erro: any) =>{
        console.error(erro); 
      }
    );
  }
}
