import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule, EmailValidator } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  // public user : User  = new User();

 // id!: string;
  currentUser: User = new User();

  PassToLogin !: string;
  IdToLogin !: string;

  @Output() passToLogin: EventEmitter<number> = new EventEmitter()

  constructor(
    private log:Logging,
    private userService: UserService,
    private router:Router,
    private route:ActivatedRoute
  ) { }

  ngOnInit(): void {

  }

  checkUser() {
    //if (this.IdToLogin != undefined && this.PassToLogin != undefined && this.IdToLogin != "" && this.PassToLogin != "")
      // this.ccurrentUser !=new User() ;
      this.userService.LoginUserByID(this.IdToLogin, this.PassToLogin).subscribe(res => {
        if (res) {
          this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
            this.currentUser = res1;
            console.log("curent user ======>",this.currentUser)
            alert(this.currentUser.firstName + " התחברת בהצלחה");
            this.log.ActiveUser = this.currentUser;
            this.router.navigate(['/ListBudgets']);
  
          });
  
        } else {
          this.IdToLogin ="";
          this.PassToLogin ="";
          alert("שם משתמש או סיסמה שגויים, אנא נסה שנית או הירשם");
        }
        console.log('res===', res)
      });
    
    // else {
    //   alert("חובה להכניס שפ משתמש וסיסמא");
    // }
   
  }
}


