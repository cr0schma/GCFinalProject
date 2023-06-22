import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GrandClickrDbService {

  constructor(private http: HttpClient) { }

  private readonly url = 'https://localhost:7212/api/'

  UserLoginValidation(userName: string, password: string): Observable<boolean>{
    return this.http.get<boolean>(this.url + 'GrandClickrDb/Login?userName='+userName+'&password='+password);
  }
}
