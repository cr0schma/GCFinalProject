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

  addImage(imageToUpload: FormData, tag: string) {
    return this.http.post(this.url + 'AddImage?' + 'userContainer=chris&' + 'tag=' + tag, imageToUpload)
  }

  addTag(addTag: string, fileName: string) {
    return this.http.put(this.url + 'AddTag?' + 'userContainer=chris&' + 'fileName=' + fileName + '&tag=' + addTag, null)
  }

}
