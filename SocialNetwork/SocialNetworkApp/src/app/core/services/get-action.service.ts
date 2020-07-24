import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetActionService<TModel> {

  private BASE_API: string;

  constructor(private _http: HttpClient) {
    this.BASE_API = environment.API_SOCIALNETWORK;
  }

  get(url: string): Observable<TModel[]> {
    return this._http.get<TModel[]>(`${this.BASE_API}${url}`);
  }

  getById(url: string, id: number): Observable<TModel> {
    return this._http.get<TModel>(`${this.BASE_API}${url}${id}`);
  }

  getPostsByUserOrFriends(url1: string, url2: string, id: number): Observable<TModel[]> {
    return this._http.get<TModel[]>(`${this.BASE_API}${url1}${id}${url2}`);
  }
}
