import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostActionService<TModel> {

  private BASE_API: string;
  private httpOptionsJson = {
    headers: new HttpHeaders({
      'content-type': 'application/json; charset=utf-8',
    })
  };
  private httpOptionsFormdata = {
    headers: new HttpHeaders({
      'content-type': 'application/json; charset=utf-8',
    })
  };

  constructor(private _http: HttpClient) { 
    this.BASE_API = environment.API_SOCIALNETWORK;
  }

  post(url:string, model: TModel ){
    return this._http.post(`${this.BASE_API}${url}`, model, this.httpOptionsJson);
  }

  postForm(url:string, formData: FormData ){
    return this._http.post(`${this.BASE_API}${url}`, formData, this.httpOptionsFormdata);
  }

}
