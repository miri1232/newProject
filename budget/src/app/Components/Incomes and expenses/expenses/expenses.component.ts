import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Expense } from 'src/app/Classes/Expense';
import { ExpensesService } from 'src/app/Services/expenses.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.scss']
})
export class ExpensesComponent implements OnInit {

ExpensesList : Expense[] = [];
counter:number=1;


  constructor(
        private myExpensesServise: ExpensesService ,

  ) { }

  //הכנת משתנה לקליטת הקטגוריה שמתקבל מהמשתמש
  // @Input() CategoryToShow="";

  ngOnInit(): void {
    this.myExpensesServise.GetAllExpenses().subscribe(exp => { 
      this.ExpensesList = exp;
      console.log(exp);
  } );

  }

 CategoryToShow:string="גגגגגגגגגגגגג";
  
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

