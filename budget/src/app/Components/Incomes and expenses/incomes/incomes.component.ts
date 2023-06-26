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
import { FormControl, FormGroup } from '@angular/forms';
import { LookupService } from 'src/app/Services/lookup.service';
import { SourceOfIncomeService } from 'src/app/Services/source-of-income.service';
import { Status } from 'src/app/Classes/Status';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.scss']
})
export class IncomesComponent implements OnInit {

  today = new Date();
  public end = new Date();
  public start = new Date(this.today.getFullYear(), this.today.getMonth() - 1);

  IncomeList: Income[] = [];
  public CategoryIncomeList: CategoryIncome[] = [];

  public listStatus: Status[] | undefined;

  activeBudget!: Budget;

  searchForm!: FormGroup;

  constructor(
    private myIncomeServise: IncomesService,
    private myCategoryIncome: CategoryIncomeService,
    private mySourceOfCategoryIncome: SourceOfIncomeService,
    private log: Logging,
    private modalService: NgbModal,
    private lookupSer: LookupService,

  ) {
    this.myIncomeServise.sharedIncomeList$.subscribe(res => {
      this.IncomeList = res;
    })
   }

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)

    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
    });
    this.myIncomeServise.GetIncomesByBudget(this.activeBudget.id).subscribe(exp => {
      this.IncomeList = exp;
      console.log(exp);
    });

    this.myCategoryIncome.GetAllCategory().subscribe(c => {
      this.CategoryIncomeList = c;
      console.log(c);
    });
    
//הקמת טופס לחיפוש
this.searchForm = new FormGroup({
  idBudget: new FormControl(this.activeBudget.id),
  dateEnd: new FormControl(this.end),
  dateStart: new FormControl(this.start),
  sumMin: new FormControl(0),
  sumMax: new FormControl(9999999),
  category: new FormControl(0),
  subCategory: new FormControl(0),
  status: new FormControl(0),
});
// this.myIncomeServise.SearchIncomesObject$(this.searchForm.value);
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
