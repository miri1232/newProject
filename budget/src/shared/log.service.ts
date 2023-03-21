import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { Budget } from "src/app/Classes/Budget";
import { User } from "src/app/Classes/User";
import { BudgetService } from "src/app/Services/budget.service";
import { UserService } from "src/app/Services/user.service";

//סרוויס על ששומר בתוכו את פרטי המשתמש לצורך העברת המידע לקומפוננטות הפנימיות

@Injectable({
  providedIn: 'root',
})
export class Logging {

  // public ActiveUser: User = new User();

  public ActiveBudget = new BehaviorSubject(new Budget());
  sharedActiveBudget = this.ActiveBudget.asObservable();

  private ActiveUser = new BehaviorSubject(new User());
  sharedActiveUser = this.ActiveUser.asObservable();



  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) {
    // this.ActiveUser.id = '300668852';
    // this.ActiveUser.firstName = 'Miri';
    // this.ActiveBudget.id=5;
  }
  nextUser(newUser: User) {
    this.ActiveUser.next(newUser);
  }

  nextBudget(newBudget:Budget){
    this.ActiveBudget.next(newBudget);
  }

  logOutUser() {
    this.ActiveUser.next(new User());
    console.log(this.ActiveUser);

    this.ActiveBudget.next(new Budget());

    this.router.navigate([''])

  }

  logOutBudget() {
    this.ActiveBudget.next(new Budget());
  }




}
