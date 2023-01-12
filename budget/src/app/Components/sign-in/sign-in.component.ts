import { Component, EventEmitter, OnInit, Output ,Input} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators ,ReactiveFormsModule} from '@angular/forms';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  id!: string;
 // currentUser: User = new User();

  newUser=new User();

  

constructor( 
  private formBuilder:FormBuilder,
  private myUser: UserService ,
) { }

eventForm!: FormGroup;


  ngOnInit(): void {
    this.eventForm = new FormGroup({
      Password: new FormControl("",[Validators.required,Validators.minLength(5)]),
      FirstName :new FormControl("",[Validators.required,Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      LastName   :new FormControl("",[Validators.required,Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      Email :new FormControl("",[Validators.required,Validators.email]),
     Id:new FormControl("",[Validators.required]),
Phone:new FormControl("",[Validators.required]),
DateBirth:new FormControl(new Date(),[Validators.required]),
     }); 
  }
  
  
  AddUser(){
    if(this.eventForm.value!=undefined){
    this.myUser.AddUser(this.eventForm.value);
    //this.log.ActiveUser=this.newUser;
    this.newUser= new User()
   alert("הרישום נקלט בהצלחה!")
   //this.myRoute.navigate([''])
    }
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
  //   });