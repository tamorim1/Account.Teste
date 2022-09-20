import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, ModuleWithProviders, NgModule } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CandidatoService {

  constructor(private _httpClient: HttpClient, @Inject('API_URL') private _apiUrl: string) { }

  public getCandidatos(): Observable<SelectCandidatoDTO[]> {
    return this._httpClient.get<SelectCandidatoDTO[]>(this._apiUrl + '/candidate');
  }

  public getCandidatoByLegenda(legenda: number): Observable<SelectCandidatoByLegendaDTO> {
    return this._httpClient.get<SelectCandidatoByLegendaDTO>(this._apiUrl + `/candidatebylegenda?legenda=${legenda}`);
  }


  public postCandidato(candidato: InsertCandidatoDTO): Observable<void> {
    return this._httpClient.post<void>(this._apiUrl + '/candidate', candidato);
  }

  public deleteCandidato(id: number): Observable<void> {
    return this._httpClient.delete<void>(this._apiUrl + `/candidate?id=${id}`);
  }
  
}

export class SelectCandidatoByLegendaDTO {
  public id!: number
  public nomeCompleto!: string;
  public nomeVice!: string;
  public dataRegistro!: Date;
  public legenda!: number;
}

export class SelectCandidatoDTO {
  public id!: number
  public nomeCompleto!: string;
  public nomeVice!: string;
  public dataRegistro!: Date;
  public legenda!: number;
}

export class InsertCandidatoDTO {
  public nomeCompleto!: string;
  public nomeVice!: string;
  public legenda!: number;
}

@NgModule()
export class CandidatoServiceModule {
  static forRoot(): ModuleWithProviders<CandidatoServiceModule> {
    return {
      ngModule: CandidatoServiceModule,
      providers: [{ provide: 'CandidatoService', useClass: CandidatoService }]
    };
  }
}
