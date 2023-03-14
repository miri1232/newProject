import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

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
    private route:ActivatedRoute,
    private modalService: NgbModal,

    ) { }

    eventForm!: FormGroup;
  
  ngOnInit(): void {
    
  }


SendPass(){
this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
 if(res1!=undefined) {

    const modalRef = this.modalService.open(ActionDialogComponent);
    modalRef.componentInstance.content = res1.email + "נשלחה סיסמא חדשה לכתובת המייל ";

  this.IsSend=true;
}
 else{
  const modalRef = this.modalService.open(ActionDialogComponent);
  modalRef.componentInstance.content = "מספר תעודת הזהות אינו מופיע במערכת, עליך להרשם";
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
        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = this.UserToUpdate.firstName + " הסיסמא עודכנה בהצלחה ";
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
      const modalRef = this.modalService.open(ActionDialogComponent);
      modalRef.componentInstance.content = "הסיסמה שגויה, אנא נסה שנית או הירשם";
    }
  }
);

}

}
