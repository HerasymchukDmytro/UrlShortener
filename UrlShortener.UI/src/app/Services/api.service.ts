import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { myURL } from '../Models/url';

@Injectable({
  providedIn: 'root'
})
export class ApiService { 
  baseApiUrl: string = "https://localhost:7187";
  constructor(private http: HttpClient) { }

  postLongUrl(url: myURL):Observable<myURL>{
    return this.http.post<myURL>(this.baseApiUrl+'/url', url);
  }
}
