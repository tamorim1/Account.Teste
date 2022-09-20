import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { FormValidators } from '@syncfusion/ej2-angular-inputs';
import { DashboardLayoutComponent } from '@syncfusion/ej2-angular-layouts';
import { Toast, ToastUtility } from '@syncfusion/ej2-angular-notifications';
import { CandidatoService, InsertCandidatoDTO } from '../../../services/candidato/candidato.service';

@Component({
  selector: 'app-candidatos',
  templateUrl: './candidatos.component.html',
  styleUrls: ['./candidatos.component.css']
})
export class CandidatosComponent implements OnInit {

  public cellSpacing: number[] = [10, 10];
  public panels: any;

  public toastObj!: Toast;

  @ViewChild('defaultLayout') dashboard!: DashboardLayoutComponent;

  public reactForm: FormGroup;

  get nomeCompleto() { return this.reactForm.get('nomeCompleto'); }
  get nomeVice() { return this.reactForm.get('nomeVice'); }
  get legenda() { return this.reactForm.get('legenda'); }

  constructor(@Inject('CandidatoService') private _candidatoService: CandidatoService) {
    this.reactForm = new FormGroup({
      'nomeCompleto': new FormControl('', [FormValidators.required]),
      'nomeVice': new FormControl('', [FormValidators.required]),
      'legenda': new FormControl('', [FormValidators.required]),
    });
  }


  public refresh(ev: any) {
    this._candidatoService.getCandidatos().subscribe(v => {
      this.dashboard.removeAll();
      v.forEach((c, i) => {
        let panel = {
          id: `${c.id}`,
          sizeX: 1,
          sizeY: 1,
          row: 0,
          col: i,
          header: `<div style="text-align: center;">${c.nomeCompleto}</div>`,
          content: `<div class='content'><div style="text-align: center;">Legenda: ${c.legenda}</div><div style="text-align: center;"><button id="${c.id}" class="exclude" ejs-button cssClass="e-small">Excluir</button></div></div>`
        };
        this.dashboard.addPanel(panel);
      });

      let itens = document.getElementsByClassName('exclude');
      for (let i = 0; i < itens.length; i++) {
        itens.item(i).addEventListener('click', () => {
          this._candidatoService.deleteCandidato(new Number(itens.item(i).id).valueOf()).subscribe(v => {
            this.refresh(null);
          }, e => {
            this.toastObj = ToastUtility.show({
              title: 'Erro',
              content: e.error,
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
        });
      }

      console.log(v);
    }, e => {
      this.toastObj = ToastUtility.show({
        title: 'Erro',
        content: 'Erro ao obter os dados dos candidatos.',
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


  ngOnInit(): void {
    this.refresh(null);
    
    document.getElementById('formCandidatos')!.addEventListener(
      'submit',
      (e: Event) => {
        e.preventDefault();
        if (this.reactForm.valid) {
          let candidato = new InsertCandidatoDTO();
          candidato.nomeCompleto = <string>this.nomeCompleto.value;
          candidato.nomeVice = <string>this.nomeVice.value;
          candidato.legenda = <number>this.legenda.value;

          this._candidatoService.postCandidato(candidato).subscribe(v => {
            this.reactForm.reset();
            this.refresh(null);
          }, e => {
            this.toastObj = ToastUtility.show({
              title: 'Erro',
              content: e.error,
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
        } else {
          Object.keys(this.reactForm.controls).forEach(field => {
            const control = this.reactForm.get(field);
            control!.markAsTouched({ onlySelf: true });
          });
        }
      });
  }

  public click(ev: any) {
    console.log(ev);
  }

  

}
