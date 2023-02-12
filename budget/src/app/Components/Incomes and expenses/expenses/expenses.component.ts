import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from 'src/app/Classes/Category';
import { Expense } from 'src/app/Classes/Expense';
import { CategoryService } from 'src/app/Services/category.service';
import { ExpensesService } from 'src/app/Services/expenses.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.scss']
})
export class ExpensesComponent implements OnInit {

ExpensesList : Expense[] = [];
CategoryList : Category[] = [];


  constructor(
        private myExpensesServise: ExpensesService ,
        private myCategory:CategoryService,
  ) { }

  //הכנת משתנה לקליטת הקטגוריה שמתקבל מהמשתמש
  // @Input() CategoryToShow="";

  ngOnInit(): void {
    this.myExpensesServise.GetAllExpenses().subscribe(exp => { 
      this.ExpensesList = exp;
      console.log(exp);
  } );
 this.myCategory.GetAllCategory().subscribe(c => { 
      this.CategoryList = c;
      console.log(c);
  } );


  }

ConvertCategory(id:number){

}

 CategoryToShow:string="";
  
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

