import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  public showLogin:boolean=false;
  public showSignIn:boolean=false;

  constructor(
    private router:Router,
    private route:ActivatedRoute
  ) { }
  ngOnInit(): void {
  }

  Login(){
    // this.showLogin=!this.showLogin;
    // if(this.showSignIn)this.showSignIn=!this.showSignIn;
    this.router.navigate(['/Login'])
    }

SignIn(){
// this.showSignIn=!this.showSignIn;
//     if(this.showLogin) this.showLogin=!this.showLogin;
   this.router.navigate(['/SignIn'])

}

}
