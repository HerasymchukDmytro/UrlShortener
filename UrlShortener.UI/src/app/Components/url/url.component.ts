import { Component } from '@angular/core';
import { myURL } from 'src/app/Models/url';
import { ApiService } from 'src/app/Services/api.service';

@Component({
  selector: 'app-url',
  templateUrl: './url.component.html',
  styleUrls: ['./url.component.css']
})
export class UrlComponent {
  constructor(private apiUrl: ApiService){}
  result: string = ""
  longUrl: myURL =
  {
    url: ""
  };
  create(){
    this.apiUrl.postLongUrl(this.longUrl).subscribe({
      next: (result) => {
        console.log(result);
        this.result = result.url;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
