import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  htmlPage: string;
  name: string;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<string>('http://www.nu.nl').subscribe(
      response => this.htmlPage = response
    );
  }

  getName(name?: string) {
    if(name !== '') {
      this.name = name;
    }
  }

}
