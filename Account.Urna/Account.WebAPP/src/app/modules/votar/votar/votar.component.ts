import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { TextBoxComponent } from '@syncfusion/ej2-angular-inputs';
import { Toast, ToastUtility } from '@syncfusion/ej2-angular-notifications';
import { CandidatoService, SelectCandidatoByLegendaDTO } from '../../../services/candidato/candidato.service';
import { VotoService } from '../../../services/voto/voto.service';

@Component({
  selector: 'app-votar',
  templateUrl: './votar.component.html',
  styleUrls: ['./votar.component.css']
})
export class VotarComponent implements OnInit {

  public candidato: SelectCandidatoByLegendaDTO = new SelectCandidatoByLegendaDTO();
  public value1: string = '';
  public value2: string = '';

  public toastObj!: Toast;

  constructor(@Inject('VotoService') private _votoService: VotoService, @Inject('CandidatoService') private _candidatoService: CandidatoService) {

  }

  ngOnInit() {
    
  }

  public click(e: any) {

    if (this.value1 && !this.value2) {
      this.value2 = e.srcElement.innerText;
      const legenda = new Number(this.value1 + this.value2);
      console.log(legenda);
      this._candidatoService.getCandidatoByLegenda(legenda.valueOf()).subscribe(v => {
        if (v) {
          this.candidato = v;
        } else {
          this.null();
        }
        console.log(v);
      }, e => {
        this.toastObj = ToastUtility.show({
          title: 'Erro',
          content: 'Erro ao obter os dados do candidato.',
          timeOut: 5000,
          position: { X: 'Center', Y: 'Top' },
          showCloseButton: true,
          click: () => { this.toastObj.hide(); },
          buttons: [{
            model: { content: 'Fechar' }, click: () => { this.toastObj.hide(); }
          }]
        }, 'Error');
        console.log(e);
      })
    }

    if (!this.value1) {
      this.value1 = e.srcElement.innerText;
    }

    console.log(e.srcElement.innerText);
  }

  public clickCommand(e: any) {
    if (e.srcElement.innerText == 'BRANCO') {
      this.blank();
    }

    if (e.srcElement.innerText == 'CORRIGE') {
      this.clear();
    }

    if (e.srcElement.innerText == 'CONFIRMA') {
      if (!this.value1 || !this.value2) {
        return;
      }
      console.log(this.candidato.id);
      this._votoService.postVoto(this.candidato.id).subscribe(v => {
        this.toastObj = ToastUtility.show({
          title: 'Sucesso',
          content: 'Voto computado com sucesso.',
          timeOut: 5000,
          position: { X: 'Center', Y: 'Top' },
          showCloseButton: true,
          click: () => { this.toastObj.hide(); },
          buttons: [{
            model: { content: 'Fechar' }, click: () => { this.toastObj.hide(); }
          }]
        }, 'Sucess');
        this.clear();
        console.log(e);
      },e => {
        this.toastObj = ToastUtility.show({
          title: 'Erro',
          content: 'Erro ao computar o voto.',
          timeOut: 5000,
          position: { X: 'Center', Y: 'Top' },
          showCloseButton: true,
          click: () => { this.toastObj.hide(); },
          buttons: [{
            model: { content: 'Fechar' }, click: () => { this.toastObj.hide(); }
          }]
        }, 'Error');
        console.log(e);
      });
      
    }
    console.log(e.srcElement.innerText);
  }

  private clear() {
    this.candidato.id = 0;
    this.candidato.nomeCompleto = '';
    this.candidato.nomeVice = '';
    this.candidato.legenda = 0;

    this.value1 = '';
    this.value2 = '';
  }

  private blank() {
    this.candidato.id = 0;
    this.candidato.nomeCompleto = 'BRANCO';
    this.candidato.nomeVice = 'BRANCO';
    this.candidato.legenda = 0;
    this.value1 = '0';
    this.value2 = '0';

  }

  private null() {
    this.candidato.id = 0;
    this.candidato.nomeCompleto = 'NULO';
    this.candidato.nomeVice = 'NULO';
    this.candidato.legenda = 0;

  }

  


}
