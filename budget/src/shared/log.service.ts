import { Injectable } from "@angular/core";
import { Budget } from "src/app/Classes/Budget";
import { User } from "src/app/Classes/User";
import { BudgetService } from "src/app/Services/budget.service";
import { UserService } from "src/app/Services/user.service";

//סרוויס על ששומר בתוכו את פרטי המשתמש לצורך העברת המידע לקומפוננטות הפנימיות
@Injectable({
  providedIn: 'root',
})
export class Logging{

  ActiveUser: User=new User();
  ActiveBudget:Budget=new Budget();



    constructor(
      // myUser:UserService,
      // myBudget:BudgetService,

    ) { }

  // ActiveUser: User;
  
  // ActiveUser= myUser.GetUserByID(300668852);

  // ActiveBudget:Budget=new Budget();
  }
