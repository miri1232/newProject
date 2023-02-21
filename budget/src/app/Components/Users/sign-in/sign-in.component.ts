import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule, EmailValidator } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';

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
    private log:Logging,
    private formBuilder: FormBuilder,
    private myUser: UserService,
    private router:Router,
    private route:ActivatedRoute
  ) { }

  eventForm!: FormGroup;


  ngOnInit(): void {
    
        //הקמת הטופס
        this.eventForm = new FormGroup({

          password: new FormControl("", [Validators.required, Validators.minLength(5)]),
          firstName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
          lastName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
          email: new FormControl("", [Validators.required, Validators.email]),
          id: new FormControl("", [Validators.required, Validators.pattern("[0-9]*")]),
          phone: new FormControl("", [Validators.required]),
          dateBirth: new FormControl(new Date(0), [Validators.required]),

          // password: new FormControl("", [Validators.required, Validators.minLength(5)]),
          // firstName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
          // lastName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
          // email: new FormControl("", [Validators.required, Validators.email]),
          // id: new FormControl("", [Validators.required, Validators.pattern("[0-9]")]),
          // phone: new FormControl("", [Validators.required]),
          // dateBirth: new FormControl(new Date(), [Validators.required]),

          // this.eventForm = new FormGroup({
          //   password: new FormControl("", [Validators.required, Validators.minLength(5)]),
          //   firstName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
          //   lastName: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
          //   email: new FormControl("", [Validators.required,  Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" )]),
          //   id: new FormControl("", [Validators.required, Validators.pattern("[0-9]"), Validators.maxLength(9)]),
          //   phone: new FormControl("", [Validators.required, Validators.pattern("05[0-9]-?[0-9]{7}")]),
          //   dateBirth: new FormControl(new Date(), [Validators.required]),
    });
  }

  //  this.newUser = new User({
  //   this.newUser.Password=this.eventForm.value.Password,
  //   this.newUser.FirstName=this.eventForm.value.FirstName,
  //   this.newUser.LastName =this.eventForm.value.LastName,
  //   this.newUser.Email =this.eventForm.value.Email,
  //   this.newUser.Id=this.eventForm.value.Id,
  //   this.newUser.Phone=this.eventForm.value.Phone,
  //   this.newUser.DateBirth=this.eventForm.value.DateBirth
  //   });


  // this.newUser = new User(
  //   this.eventForm.value.Id,
  //   this.eventForm.value.FirstName,
  //   this.eventForm.value.LastName,
  //   this.eventForm.value.Password,
  //   this.eventForm.value.Email
  //   this.eventForm.value.Phone,
  //   this.eventForm.value.DateBirth
  //   );


  AddUser() {
    if (this.eventForm.value != undefined) {
      console.log("**פרטים**" + this.eventForm.value.firstName)

      this.myUser.AddUser(this.eventForm.value).subscribe(res1 => {
        console.log("curent user ======>", res1)
        this.newUser = this.eventForm.value;
        alert(this.newUser.firstName + " הרישום נקלט בהצלחה ");
        this.log.ActiveUser = this.newUser;
        this.newUser = new User();
        this.router.navigate(['/ListBudgets']);
      })


    }
  }


  // checkUser() {

  //   // this.ccurrentUser !=new User() ;
  //   this.userService.LoginUserByID(this.IdToLogin, this.PassToLogin).subscribe(res => {
  //     if (res) {
  //       this.userService.GetUserByID(this.IdToLogin).subscribe(res1 => {
  //         this.currentUser = res1;
  //         console.log("curent user ======>",this.currentUser)
  //         alert(this.currentUser.FirstName + " התחברת בהצלחה");
  //       });

  //     } else {
  //       this.IdToLogin ="";
  //       this.PassToLogin ="";
  //       alert("שם משתמש או סיסמה שגויים, אנא נסה שנית או הירשם");
  //     }
  //     console.log('res===', res)
  //   })

}