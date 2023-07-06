import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Budget } from 'src/app/Classes/Budget';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { Search } from 'src/app/Classes/Search';
import { Status } from 'src/app/Classes/Status';
import { TotalSumCategory } from 'src/app/Classes/TotalSumCategory';
import { TotalSumCategoryIncome } from 'src/app/Classes/TotalSumCategoryIncome';
import { ExpensesService } from 'src/app/Services/expenses.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {

  today = new Date();
  public end = new Date();
  public start = new Date(this.today.getFullYear(), this.today.getMonth() - 3, 1);


  activeBudget!: Budget;

  searchForm!: FormGroup;

  listCategoryIncomes: TotalSumCategoryIncome[] = [];
  listCategoryExpenses: TotalSumCategory[] = [];
  public listStatus: Status[] | undefined;
  public idStatus: number = 0;


  // dateEnd: Date = new Date(); // default to today's date
  // dateStart: Date = new Date();//default to befor mounth

  constructor(
    private log: Logging,
    private myIncomeSer: IncomesService,
    private myExpenseSer: ExpensesService,
    private lookupSer: LookupService,

  ) {

  }



  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => {
      this.activeBudget = budget;
    });

    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
    });
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

    this.myExpenseSer.ReportExpenses3(this.searchForm.value);
    this.myIncomeSer.ReportIncomes(this.searchForm.value);

    // this.myExpenseSer.ReportExpenses3(this.searchForm.value);
    this.myExpenseSer.sharedreportExp$.subscribe(res => {
      this.listCategoryExpenses = res;
    });
    //  this.myIncomeSer.ReportIncomes(this.searchForm.value);
    this.myIncomeSer.sharedReportInc$.subscribe(res => {
      this.listCategoryIncomes = res;
    });

  }

  changeRange(event: any) {
    this.searchForm.controls["dateStart"].setValue(event.target.dateStart.value)
    this.searchForm.controls["dateEnd"].setValue(event.target.dateEnd.value)

    if (this.searchForm.value.dateStart <= this.searchForm.value.dateEnd) {
      this.myExpenseSer.ReportExpenses3(this.searchForm.value);
      this.myExpenseSer.sharedreportExp$.subscribe(res => {
        this.listCategoryExpenses = res;
      });
      this.myIncomeSer.ReportIncomes(this.searchForm.value);
      this.myIncomeSer.sharedReportInc$.subscribe(res => {
        this.listCategoryIncomes = res;
      });
    }
  }

}

