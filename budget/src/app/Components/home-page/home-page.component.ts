import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  constructor(
    private router:Router,
    private route:ActivatedRoute
  ) { }
  ngOnInit(): void {
  }

  logIn(){
    this.router.navigate(['/Login'])
    }

SignIn(){
  this.router.navigate(['/SignIn'])

}

}
