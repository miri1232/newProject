import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { MessageService } from 'src/app/Services/message.service';

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
    private log: Logging,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private mess: MessageService
  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    //הקמת הטופס
    this.eventForm = new FormGroup({

      password: new FormControl("", [Validators.required, Validators.minLength(4)]),
      id: new FormControl("", [Validators.required, Validators.pattern("[0-9]*")]),
    });

  }

  checkUser() {
    this.mess.a = "cccc";
    this.userService.LoginUserByID(this.IdToLogin, this.PassToLogin).subscribe(res => {
      if (res) {
        this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
          this.currentUser = res1;
          console.log("curent user ======>", this.currentUser)
          const modalRef = this.modalService.open(ActionDialogComponent);
          modalRef.componentInstance.content = this.currentUser.firstName + " התחברת בהצלחה";
          this.log.nextUser(this.currentUser)
          this.router.navigate(['/ListBudgets']);

        });
      } else {
        this.IdToLogin = "";
        this.PassToLogin = "";
        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = "שם משתמש או סיסמה שגויים, אנא נסה שנית או הירשם";
      }
      console.log('res===', res)
    });
  }



}


