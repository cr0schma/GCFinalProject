import { Injectable } from '@angular/core';
import { AzStorage } from './az-storage';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AzBlobService {

  constructor(private http: HttpClient) { }

  private readonly url = 'https://grandclickr20230621220237.azurewebsites.net/api/AzStorage/'

  getImages(): Observable<AzStorage[]> {
    return (this.http.get<AzStorage[]>(this.url + 'GetImages?' + 'userContainer=' + localStorage.getItem("userName")))
  }

  addImage(imageToUpload: FormData, tag: string) {
    return this.http.post(this.url + 'AddImage?' + 'userContainer=' + localStorage.getItem("userName") + '&' + 'tag=' + tag, imageToUpload)
  }

  addTag(addTag: string, fileName: string) {
    return this.http.put(this.url + 'AddTag?' + 'userContainer=' + localStorage.getItem("userName") + '&' + 'fileName=' + fileName + '&tag=' + addTag, null)
  }

  deleteImage(fileName: string): Observable<any> {
    return this.http.delete(this.url + 'DeleteImage?' + 'userContainer=' + localStorage.getItem("userName") + '&' + 'fileName=' + fileName);
  }
}
