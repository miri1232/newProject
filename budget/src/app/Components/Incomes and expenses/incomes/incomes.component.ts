import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { CategoryIncomeService } from 'src/app/Services/category-income.service';
import { CategoryService } from 'src/app/Services/category.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.scss']
})
export class IncomesComponent implements OnInit {

  IncomeList: Income[] = [];
  CategoryIncomeList: CategoryIncome[] = [];

  activeBudget!: Budget;

  constructor(
    private myIncomeServise: IncomesService,
    private myCategoryIncome: CategoryIncomeService,
    private log: Logging,

  ) { }

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)

    this.myIncomeServise.GetIncomesByBudget(this.activeBudget.id).subscribe(exp => {
      this.IncomeList = exp;
      console.log(exp);
    });

    this.myCategoryIncome.GetAllCategory().subscribe(c => {
      this.CategoryIncomeList = c;
      console.log(c);
    });

  }



}
