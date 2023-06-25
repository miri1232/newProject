import { Injectable } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { Budget } from "src/app/Classes/Budget";
import { Search } from "src/app/Classes/Search";
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

  // private ActiveSearch = new BehaviorSubject(new Search());
  // sharedActiveSearch = this.ActiveSearch.asObservable();

  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) {

  }
  nextUser(newUser: User) {
    this.ActiveUser.next(newUser);
  }

  nextBudget(newBudget:Budget){
    this.ActiveBudget.next(newBudget);
  }

  // nextSearch(newSearch:Search){
  //   this.ActiveSearch.next(newSearch);
  // }

  logOutUser() {
    this.ActiveUser.next(new User());

    this.ActiveBudget.next(new Budget());

    // this.ActiveSearch.next(new Search());

    this.router.navigate([''])

  }

  logOutBudget() {
    this.ActiveBudget.next(new Budget());
    // this.ActiveSearch.next(new Search());

  }




}
