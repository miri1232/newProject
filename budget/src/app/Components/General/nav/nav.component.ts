import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  constructor(
    private log:Logging,
    private router:Router,
    private route:ActivatedRoute
  ) { }

  ngOnInit(): void {
  }

today: Date=new Date();

  activeUser: User = this.log.ActiveUser;

  logIn(){
    this.router.navigate(['/Login'])
    }

    logOut(){
      this.log.logOutUser();
    }
}
