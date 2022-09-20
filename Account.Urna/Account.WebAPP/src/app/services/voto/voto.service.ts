import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, ModuleWithProviders, NgModule } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VotoService {

  constructor(private _httpClient: HttpClient, @Inject('API_URL') private _apiUrl: string) { }

  public getVotos(): Observable<SelectVotoDTO[]> {
    return this._httpClient.get<SelectVotoDTO[]>(this._apiUrl + '/votes');
  }

  public postVoto(idCandidato?: number): Observable<void> {
    return this._httpClient.post<void>(this._apiUrl + '/vote', idCandidato);
  }

}

export class SelectVotoDTO {
  public nomeCompleto!: string;
  public nomeVice!: string;
  public quantidadeVotos!: number;
  public percentualVotos!: number;

}

@NgModule()
export class VotoServiceModule {
  static forRoot(): ModuleWithProviders<VotoServiceModule> {
    return {
      ngModule: VotoServiceModule,
      providers: [{ provide: 'VotoService', useClass: VotoService }]
    };
  }
}
