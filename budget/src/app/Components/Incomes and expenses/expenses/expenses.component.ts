import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { Category } from 'src/app/Classes/Category';
import { Expense } from 'src/app/Classes/Expense';
import { CategoryService } from 'src/app/Services/category.service';
import { ExpensesService } from 'src/app/Services/expenses.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal, } from '@ng-bootstrap/ng-bootstrap';
import { UpdateExpenseComponent } from '../update-expense/update-expense.component';
import { LookupService } from 'src/app/Services/lookup.service';
import { Subcategory } from 'src/app/Classes/Subcategory';
import { Status } from 'src/app/Classes/Status';
import { SubCategoryService } from 'src/app/Services/sub-category.service';
import { Search } from 'src/app/Classes/Search';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.scss']
})
export class ExpensesComponent implements OnInit {

  ExpensesList: Expense[] = [];
  public listCategory: Category[] | undefined;
  public listSubcategory: Subcategory[] = [];
  public listStatus: Status[] | undefined;
  public idCategory: number = 0;
  public listSubcategoryByCategory: Subcategory[] = [];

  // public idStatus: number = 0;
  // public DateEnd: Date = new Date(); // default to today's date
  // public DateStart: Date = new Date();//default to befor mounth
  // public idSubCategory: number = 0;

  // public objectToSearch:Search=new Search();

  activeBudget!: Budget;
  searchForm!: FormGroup;

  constructor(
    private myExpensesServise: ExpensesService,
    private myCategory: CategoryService,
    private mySubCategory: SubCategoryService,
    private log: Logging,
    private modalService: NgbModal,
    private lookupSer: LookupService,

  ) {
   // this.DateEnd = new Date();
    this.myExpensesServise.sharedexpenseList$.subscribe(res => {
      this.ExpensesList = res;
    })
  }


  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)

    this.myExpensesServise.GetExpensesByBudget(this.activeBudget.id);

    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
    });
    this.myCategory.GetAllCategory().subscribe(res => {
      this.listCategory = res;
    });
    this.mySubCategory.GetAllSubcategory().subscribe(res => {
      this.listSubcategory = res;
      console.log(this.listSubcategory);
    });

    //הקמת טופס לחיפוש
    this.searchForm = new FormGroup({
      idBudget: new FormControl(this.activeBudget.id),
      dateEnd: new FormControl(new Date()),
      dateStart: new FormControl(new Date()),
      sumMin: new FormControl(0),
      sumMax: new FormControl(9999999),
      category: new FormControl(0),
      subCategory: new FormControl(0),
      status: new FormControl(0),
    });

  }

  search(){
    this.myExpensesServise.SearchExpensesObject( this.searchForm.value);
    this.myExpensesServise.sharedexpenseList$.subscribe(res => {
      this.ExpensesList = res;
    })
  }


  SumExpenses(i: number) {
    return this.ExpensesList.slice(0, i + 1).reduce((a, b) => a + b.sum, 0);
  }

  UpdateExpense(e: Expense) {
    const modalRef2 = this.modalService.open(UpdateExpenseComponent);
    modalRef2.componentInstance.activeBudget = this.activeBudget;
    modalRef2.componentInstance.expenseToUpdate = e;
  }

  ConvertCategory(id: number) {

  }
  sss(i: number) {
    document.getElementById(i.toString())?.setAttribute("color", "red")
  }


  filterByCategory() {
    this.mySubCategory.GetSubcategoryByCategory(this.idCategory).subscribe(res => {
      this.listSubcategoryByCategory = res;
    });
  }


  CategoryToShow: string = "";

  // ShowAllExpenses(){
  //   this.myExpensesServise.GetAllExpenses().subscribe(exp => { 
  //     this.ExpensesList = exp;
  //     console.log(exp);
  // } );
  // }

  // ShowExpensesByCategory(){
  //   this.myExpensesServise.GetExpensesByCategory(this.CategoryToShow).subscribe(exp => { 
  //     this.ExpensesList = exp;
  //     console.log(exp);
  //     });
  //                         }



}

