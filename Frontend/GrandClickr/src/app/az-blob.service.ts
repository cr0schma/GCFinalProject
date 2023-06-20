import { Injectable } from '@angular/core';
import { AzStorage } from './az-storage';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AzBlobService {

  constructor(private http: HttpClient) { }

  private readonly url = 'https://localhost:7212/api/AzStorage/'
  
  getImages(): Observable<AzStorage[]> {
    return (this.http.get<AzStorage[]>(this.url + 'GetImages?' + 'userContainer=chris'))
  }

}
