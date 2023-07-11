import { Component } from '@angular/core';
import { Pedido } from '../models/Pedido';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PedidoService } from './pedido.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent {
  
  public titulo = 'Pedidos';
  public pedidoSelecionado: Pedido | undefined;
  public pedidoForm!: FormGroup;// | undefined;
  public modoSave = 'post' as any;

  constructor(private fb: FormBuilder,
              private pedidoService: PedidoService){
    this.criarForm();
  }

  criarForm(){
      this.pedidoForm = this.fb.group({
        codigoPedido:[0],
        dataPedido: ['', Validators.required],
        produtoId:['', Validators.required], 
        quantidadeProdutos:['', Validators.required], 
        fornecedorId:['', Validators.required], 
        valorTotalPedido:['', Validators.required]
      });
  }

  pedidoSelect(pedido: Pedido){
    this.pedidoSelecionado = pedido;
    this.pedidoForm.patchValue(pedido);
  }
  pedidoNovo(){
    this.pedidoSelecionado = new Pedido();
    this.pedidoForm.patchValue(this.pedidoSelecionado);
  }
  pedidoSubimit(){
    this.salvarPedido(this.pedidoForm.value);
  }

  voltar(){
    this.pedidoSelecionado = undefined;
  }

  public pedidos!: Pedido[];

  ngOnInit(){
    this.carregarPedido();
  }
  carregarPedido(){
    this.pedidoService.getAll().subscribe(
      (pedidos: Pedido[])=>{
        this.pedidos = pedidos;
      },
      (erro: any)=>{
        console.error(erro)
      }
    );
  }

  salvarPedido(pedido: Pedido){
    (pedido.codigoPedido == 0) ? this.modoSave = 'post' : this.modoSave = 'put';

    if (this.modoSave === 'post') {
      this.pedidoService.post(pedido).subscribe(
        () => {
          this.carregarPedido();
        }, (error: any) => { 
          console.error(error);
        }, 
      );
    } else {
      this.pedidoService.put(pedido).subscribe(
        () => {
          this.carregarPedido();
        }, (error: any) => { 
          console.error(error);
        }, 
      );
    }
  }
  deletarPedido(id: number){
    this.pedidoService.delete(id).subscribe(
      (model: any) =>{
        console.log(model);
        this.carregarPedido(); 
      },
      (erro: any) =>{
        console.error(erro); 
      }
    );
  }

  pedidoByFornecedor(fornecedorId: number){
    this.pedidoService.getByIdFornecedor(fornecedorId).subscribe(
      (pedidos: Pedido[]) =>{
        this.pedidos = pedidos;
        this.carregarPedido(); 
      },
      (erro: any) =>{
        console.error(erro); 
      }
    )
  }
}
