import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-budgets-list',
  templateUrl: './budgets-list.component.html',
  styleUrls: ['./budgets-list.component.scss']
})
export class BudgetsListComponent implements OnInit {

  public BudgetList: Budget[] | undefined;

  activeUser!: User;

  constructor(
    private log: Logging,
    private myBudgetServise: BudgetService,
    private router: Router,

  ) {

  }

  ngOnInit(): void {
    this.log.sharedActiveUser.subscribe(user => this.activeUser = user)
    this.myBudgetServise.GetBudgetByUser(this.activeUser).subscribe(budget => {
      this.BudgetList = budget;
      console.log(this.BudgetList);

    });
  }
  // b:Budget=this.log.ActiveBudget;

  ShowAllBudget() {
    this.myBudgetServise.GetBudgetByUser(this.activeUser).subscribe(budget => {
      this.BudgetList = budget;
      console.log(this.BudgetList);

    });
    // this.BudgetList=this.myBudgetServise.GetBudgetByUser();
  }



  GoBudget(b: Budget) {
    this.log.nextBudget(b);

    this.router.navigate(['/BudgetHomePage']);
    

  }


}

