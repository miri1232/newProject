import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { Income } from 'src/app/Classes/Income';
import { IncomesService } from 'src/app/Services/incomes.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {

  activeBudget!: Budget;
  IncomeList!:Income[];


  constructor(
    private log: Logging,
    private myIncomeServise: IncomesService,

  ) { }

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => { 
      this.activeBudget = budget;
      this.myIncomeServise.GetIncomesByBudget(this.activeBudget.id).subscribe(exp => {
        this.IncomeList = exp;

      });
    });
  }

}
