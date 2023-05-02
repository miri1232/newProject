import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { Category } from 'src/app/Classes/Category';
import { Expense } from 'src/app/Classes/Expense';
import { CategoryService } from 'src/app/Services/category.service';
import { ExpensesService } from 'src/app/Services/expenses.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal, } from '@ng-bootstrap/ng-bootstrap';
import { UpdateExpenseComponent } from '../update-expense/update-expense.component';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.scss']
})
export class ExpensesComponent implements OnInit {

  ExpensesList: Expense[] = [];
  CategoryList: Category[] = [];

  activeBudget!: Budget;

  constructor(
    private myExpensesServise: ExpensesService,
    private myCategory: CategoryService,
    private log: Logging,
    private modalService: NgbModal,

  ) { }

  //הכנת משתנה לקליטת הקטגוריה שמתקבל מהמשתמש
  // @Input() CategoryToShow="";

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)
 
    this.myExpensesServise.GetExpensesByBudget(this.activeBudget.id).subscribe(exp => {
      this.ExpensesList = exp;
      console.log(exp);
    });
    this.myCategory.GetAllCategory().subscribe(c => {
      this.CategoryList = c;
      console.log(c);
    });


  }

SumExpenses(i:number){
  return this.ExpensesList.slice(0,i+1).reduce((a,b)=>a+b.sum,0);
}

UpdateExpense(e:Expense)
{
  const modalRef2 = this.modalService.open(UpdateExpenseComponent);
  modalRef2.componentInstance.activeBudget = this.activeBudget;
  modalRef2.componentInstance.expenseToUpdate = e;


}

  ConvertCategory(id: number) {

  }
  sss(i:number){
document.getElementById( i.toString())?.setAttribute("color","red")
  }

  CategoryToShow: string = "";

  //ExpensesList= this.myExpensesServise.GetAllExpenses();

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

