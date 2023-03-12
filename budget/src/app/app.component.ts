import { Component } from '@angular/core';
import { UserService } from './Services/user.service';
import { Logging } from '../shared/log.service';
import { User } from './Classes/User';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers:[Logging]
})
export class AppComponent {
  title = 'Budget';


 constructor(
  private router:Router,
  private route:ActivatedRoute
//   private log: Logging,
  ) {}
    
  toHomePage(){
    
        this.router.navigate(['/HomePage'])
    
    }

 //activeUser=this.log.ActiveUser;

 
// logOut(){
//   this.log.ActiveUser=new User();
//   //this.myRoute.navigate(['/'])
// }



}