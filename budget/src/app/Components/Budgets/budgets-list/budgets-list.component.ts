import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { BudgetService } from 'src/app/Services/budget.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-budgets-list',
  templateUrl: './budgets-list.component.html',
  styleUrls: ['./budgets-list.component.scss']
})
export class BudgetsListComponent implements OnInit {

BudgetList : Budget[]=[];

  constructor(
    private log:Logging,
    private myBudgetServise: BudgetService ,

  ) { }

  ngOnInit(): void {
  }

  ShowAllBudget(){
    this.myBudgetServise.GetBudgetByUser().subscribe(budget => { 
     // this.BudgetList.push(budget);
      console.log(budget);
  } );
  }

}
