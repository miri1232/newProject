import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  // public user : User  = new User();

  id!: string;
  currentUser: User = new User();

  IdToLogin !: string;
  PassToLogin !: string;

  @Output() passToLogin: EventEmitter<number> = new EventEmitter()

  constructor(
    private userService: UserService,
  ) { }

  ngOnInit(): void {

  }

  checkUser() {

    // this.ccurrentUser !=new User() ;
    this.userService.LoginUserByID(this.IdToLogin, this.PassToLogin).subscribe(res => {
      if (res) {
        this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
          this.currentUser = res1;
          console.log("curent user ======>",this.currentUser)
          alert(this.currentUser.FirstName + " התחברת בהצלחה");
        });

      } else {
        alert("שם משתמש או סיסמה שגויים, אנא נסה שנית או הירשם");
      }
      console.log('res===', res)
    });
    // if (www== undefined){
    //   alert("שם משתמש או סיסמה שגויים, אנא נסה שנית או הירשם")
    // }
    // else{
    // this.log.ActiveUser=www;

    //  console.log("log: " + this.log.ActiveUser.userName);
    // console.log("www: " + www.LastName + " " + www.FirstName);

    //  if(www.IsManager == true){
    //     this.myRoute.navigate(['/Manager'])
    //     }
    //   else{
    //    this.myRoute.navigate([''])
    //    }
  }
}


