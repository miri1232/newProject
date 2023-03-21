import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { MessageService } from 'src/app/Services/message.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
  providers:[Logging]
})
export class NavComponent implements OnInit {

  public BudgetList: Budget[] | undefined;
  budgetExist: boolean = false;

  today: Date = new Date();

 public activeUser!: User;
 public activeBudget!: Budget ;

  constructor(
    private log: Logging,
    private router: Router,
    private route: ActivatedRoute,
    private myBudgetServise: BudgetService,

  ) { }

  ngOnInit(): void {
    this.log.sharedActiveUser.subscribe(user => this.activeUser = user);
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget);
  }


  logIn() {
    this.router.navigate(['/Login'])
  }

  logOut() {
    this.log.logOutUser();
  }

  toHomePage() {
    this.router.navigate([''])
  }

  GoBudget(b: Budget) {
    this.activeBudget = b;
    this.router.navigate(['/BudgetHomePage']);

  }

  ShowAllBudget() {
    this.myBudgetServise.GetBudgetByUser(this.activeUser).subscribe(budget => {
      this.BudgetList = budget;
      if (this.BudgetList.length > 0)
        this.budgetExist = true;
      console.log(this.BudgetList);
    });
  }
}
