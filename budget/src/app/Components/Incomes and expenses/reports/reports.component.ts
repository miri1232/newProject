import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { ObjectSumCategory } from 'src/app/Classes/ObjectSumCategory';
import { ObjectSumSubCategory } from 'src/app/Classes/ObjectSumSubCategory';
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
  IncomeList: Income[] =[];

  listCategory:ObjectSumCategory[]=[];
  listSubCategory:ObjectSumSubCategory[]=[];


  constructor(
    private log: Logging,
    private myIncomeServise: IncomesService,
    private myExpense: ExpensesService,

  ) { }



  // groupBy(xs: Income[], groupByFn: any) {
  //   return xs.reduce(function (rv: Income, x: Income) {
  //     (rv[groupByFn(x)] = rv[groupByFn(x)] || []).push(x);
  //     return rv;
  //   }, {});
  // };

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => {
      this.activeBudget = budget;
      this.myIncomeServise.GetIncomesByBudget(this.activeBudget.id).subscribe(exp => {
        this.IncomeList=exp;
      });

this.myExpense.ReportCategoryExpenses(this.activeBudget.id).subscribe(exp => {
  this.listCategory=exp;
});

  this.myExpense.ReportSubCategoryExpenses(this.activeBudget.id).subscribe(exp => {
  this.listSubCategory=exp;
  
      });
    });
  }

}
