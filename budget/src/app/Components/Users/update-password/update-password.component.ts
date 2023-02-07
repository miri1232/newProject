import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';
import { AlertComponent } from '../../General/alert/alert.component';

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
  myAlert!:AlertComponent;

  @Output() passToLogin: EventEmitter<number> = new EventEmitter()

  constructor(
    private log:Logging,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router:Router,
    private route:ActivatedRoute,

    ) { }


  
  ngOnInit(): void {
    
  }


SendPass(){
this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
 if(res1!=undefined) {
  
    alert(res1.email + "נשלחה סיסמא חדשה לכתובת המייל ")

//  return this.myAlert.AddAlert1("לתשומת ליבך",res1.email + "נשלחה סיסמא חדשה לכתובת המייל ")

  this.IsSend=true;
}
 else{
  alert("מספר תעודת הזהות אינו מופיע במערכת, עליך להרשם")
        this.router.navigate(['/SignIn']);
 }
});
}

  UpdateUser() {
    this.userService.LoginUserByID(this.IdToLogin, this.PassToLogin).subscribe(res => {
      if (res) {
        this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
          this.UserToUpdate = res1;
          this.UserToUpdate.password = this.PassToUpdate;
   this.userService.UpdateUser(this.UserToUpdate).subscribe(res1 => {
        alert(this.UserToUpdate.firstName + " הסיסמא עודכנה בהצלחה ");
        this.log.ActiveUser = this.UserToUpdate;
        this.IsSend=false;
        this.router.navigate(['/ListBudgets']);
      });
    });
    }
    else{
      this.IdToLogin ="";
      this.PassToLogin ="";
      this.IsSend=false;

      alert("הסיסמה שגויה, אנא נסה שנית או הירשם");
    }
  }
);

}

}
