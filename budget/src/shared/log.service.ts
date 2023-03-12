import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Budget } from "src/app/Classes/Budget";
import { User } from "src/app/Classes/User";
import { BudgetService } from "src/app/Services/budget.service";
import { UserService } from "src/app/Services/user.service";

//סרוויס על ששומר בתוכו את פרטי המשתמש לצורך העברת המידע לקומפוננטות הפנימיות
@Injectable({
  providedIn: 'root',
})
export class Logging{

  public ActiveUser: User=new User();
  
//  public ActiveUser: User=new User('0000','qqq','www','00000','0000@gg','0000000',new Date());
  public ActiveBudget:Budget=new Budget();



    constructor(
      private router:Router,
      private route:ActivatedRoute
    ) { 
      this.ActiveUser.id = '300668852';
            this.ActiveUser.firstName = 'Miri';

      this.ActiveBudget.id=5;
    }

  // ActiveUser.id="0000";
  
 //this.ActiveUser={'0000','qqq','www','00000','0000@gg','0000','28-01-2023'};

  //  ActiveBudget:Budget=new Budget();

  logOutUser(){
    this.ActiveUser=new User();
    console.log("current User===> "+ this.ActiveUser.firstName)
    this.router.navigate([''])

  }
  
 logOutBudget(){
  this.ActiveBudget=new Budget();
  }
  
  }
