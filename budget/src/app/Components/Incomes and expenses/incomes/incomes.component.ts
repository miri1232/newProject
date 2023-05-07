import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { CategoryIncomeService } from 'src/app/Services/category-income.service';
import { CategoryService } from 'src/app/Services/category.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { Logging } from 'src/shared/log.service';
import { UpdateExpenseComponent } from '../update-expense/update-expense.component';
import { UpdateIncomeComponent } from '../update-income/update-income.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

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
    private modalService: NgbModal

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


  SumIncomes(i:number){
    return this.IncomeList.slice(0,i+1).reduce((a,b)=>a+b.sum,0);
  }

  
  UpdateIncome(e: Income)
{
  const modalRef2 = this.modalService.open(UpdateIncomeComponent);
  modalRef2.componentInstance.activeBudget = this.activeBudget;
  modalRef2.componentInstance.incomeToUpdate = e;


}

}
