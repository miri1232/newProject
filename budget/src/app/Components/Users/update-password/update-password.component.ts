import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.scss']
})
export class UpdatePasswordComponent implements OnInit {

IsSend:boolean=false;
  IdToLogin !: string;
  PassToLogin !: string;
  PassToUpdate !: string;
  UserToUpdate = new User();

  @Output() passToLogin: EventEmitter<number> = new EventEmitter()

  constructor(
    private log:Logging,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router:Router,
    private route:ActivatedRoute
  ) { }


  
  ngOnInit(): void {
    
  }


SendPass(){
this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
 if(res1!=undefined) alert(res1.email + "נשלחה סיסמא חדשה לכתובת המייל ");
 this.IsSend=true;
});
}

  UpdateUser() {
    this.userService.LoginUserByID(this.IdToLogin, this.PassToLogin).subscribe(res => {
      if (res!=undefined) {
        this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
          this.UserToUpdate = res1;
          this.UserToUpdate.password = this.PassToUpdate;
   this.userService.UpdateUser(this.UserToUpdate).subscribe(res1 => {
    console.log("curent user ======>", res1)
        alert(this.UserToUpdate.firstName + " הסיסמא עודכנה בהצלחה ");
        this.log.ActiveUser = this.UserToUpdate;
        this.IsSend=false;
        this.router.navigate(['/ListBudgets']);
      });
    });
    }
  }
);

}

}
