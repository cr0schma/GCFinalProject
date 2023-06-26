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

  userName: string = ''

  storeUserName(usernName: string){
    this.userName = usernName.toLowerCase();
  }

  getImages(): Observable<AzStorage[]> {
    return (this.http.get<AzStorage[]>(this.url + 'GetImages?' + 'userContainer=' + this.userName))
  }

  addImage(imageToUpload: FormData, tag: string) {
    return this.http.post(this.url + 'AddImage?' + 'userContainer=' + this.userName + '&' + 'tag=' + tag, imageToUpload)
  }

  addTag(addTag: string, fileName: string) {
    return this.http.put(this.url + 'AddTag?' + 'userContainer=' + this.userName + '&' + 'fileName=' + fileName + '&tag=' + addTag, null)
  }

  deleteImage(fileName: string): Observable<any> {
    return this.http.delete(this.url + 'DeleteImage?' + 'userContainer=' + this.userName + '&' + 'fileName=' + fileName);
  }
}
