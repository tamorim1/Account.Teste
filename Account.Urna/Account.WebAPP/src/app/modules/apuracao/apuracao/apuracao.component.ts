import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { DashboardLayoutComponent } from '@syncfusion/ej2-angular-layouts';
import { Toast, ToastUtility } from '@syncfusion/ej2-angular-notifications';
import { VotoService } from '../../../services/voto/voto.service';

@Component({
  selector: 'app-apuracao',
  templateUrl: './apuracao.component.html',
  styleUrls: ['./apuracao.component.css']
})
export class ApuracaoComponent implements OnInit {

  public cellSpacing: number[] = [10,10];
  public panels: any;

  public toastObj!: Toast;

  @ViewChild('defaultLayout') dashboard!: DashboardLayoutComponent;

  constructor(@Inject('VotoService') private _votoService: VotoService) {
  }

  public refresh(ev:any) {
    this._votoService.getVotos().subscribe(v => {
      this.dashboard.removeAll();
      v.forEach((vt, i) => {
        let panel = {
          id: "Panel" + i.toString(),
          sizeX: 1,
          sizeY: 1,
          row: 0,
          col: i,
          header: `<div style="text-align: center;">${vt.nomeCompleto}</div>`,
          content: `<div class='content'><div style="text-align: center;">Votos: ${vt.quantidadeVotos}</div><div style="text-align: center;">Percentual: ${vt.percentualVotos}%</div></div>`
        };
        console.log(panel);
        this.dashboard.addPanel(panel);
      });
      console.log(v);
    }, e => {
      this.toastObj = ToastUtility.show({
        title: 'Erro',
        content: 'Erro ao obter os dados de apuração.',
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
  }

}
