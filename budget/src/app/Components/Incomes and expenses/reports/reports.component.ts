import { Component, Input, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';

import { TotalSumCategory } from 'src/app/Classes/TotalSumCategory copy';
import { ExpensesService } from 'src/app/Services/expenses.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {

  activeBudget!: Budget;
  IncomeList: Income[] = [];

  listCategory: TotalSumCategory[] = [];


  DateEnd: Date = new Date(); // default to today's date
  DateStart:Date=new Date();//default to befor mounth

  constructor(
    private log: Logging,
    private myIncomeServise: IncomesService,
    private myExpense: ExpensesService,

  ) {   
 }


  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => {
      this.activeBudget = budget;
      this.myIncomeServise.GetIncomesByBudget(this.activeBudget.id).subscribe(exp => {
        this.IncomeList = exp;
      });
      this.myExpense.ReportExpenses2(this.activeBudget.id).subscribe(exp => {
        this.listCategory = exp;
      });
    });
    this.DateStart.setMonth(this.DateStart.getMonth() - 1);  
    // console.log(this.DateEnd);
    // console.log(this.DateStart);

  }

changeRange(){
  if(this.DateStart<=this.DateEnd){

    this.myExpense.ReportExpenses3(this.activeBudget.id,this.DateStart,this.DateEnd).subscribe(exp => {
      this.listCategory = exp;
  });
  }
}

}

