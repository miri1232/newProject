import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { BudgetsListComponent } from './Components/budgets-list/budgets-list.component';
import { IncomesComponent } from './Components/incomes/incomes.component';
import { ExpensesComponent } from './Components/expenses/expenses.component';
import { NewBudgetComponent } from './Components/new-budget/new-budget.component';
import { SignInComponent } from './Components/sign-in/sign-in.component';
import { AddIncomeComponent } from './Components/add-income/add-income.component';
import { AddExpenseComponent } from './Components/add-expense/add-expense.component';
import { PaymentsListComponent } from './Components/payments-list/payments-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    BudgetsListComponent,
    IncomesComponent,
    ExpensesComponent,
    NewBudgetComponent,
    SignInComponent,
    AddIncomeComponent,
    AddExpenseComponent,
    PaymentsListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
