import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule, EmailValidator } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  id!: string;
  //currentUser: User = new User();

  newUser = new User();
  IsUser: boolean | undefined;


  constructor(
    private log: Logging,
    private formBuilder: FormBuilder,
    private myUser: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private modalService: NgbModal

  ) { }

  eventForm!: FormGroup;


  ngOnInit(): void {

    //הקמת הטופס
    this.eventForm = new FormGroup({

      password: new FormControl("", [Validators.required, Validators.minLength(5)]),
      firstName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      lastName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      email: new FormControl("", [Validators.required, Validators.email]),
      id: new FormControl("", [Validators.required, Validators.pattern("[0-9]*"),Validators.minLength(9)]),
      phone: new FormControl("", [Validators.required]),
      dateBirth: new FormControl(new Date(0), [Validators.required]),

    });
  }


  AddUser() {
    if (this.eventForm.value != undefined) {
      console.log("**פרטים**" + this.eventForm.value.firstName)

      this.myUser.AddUser(this.eventForm.value).subscribe(res1 => {
        this.newUser = this.eventForm.value;
        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = this.newUser.firstName + " הרישום נקלט בהצלחה ";
        this.log.nextUser(this.newUser)
        this.newUser = new User();
        this.router.navigate(['/ListBudgets']);
      })
    }
  }


}