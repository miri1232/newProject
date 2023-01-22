import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/Users/login/login.component';
import { BudgetsListComponent } from './Components/Budgets/budgets-list/budgets-list.component';
import { IncomesComponent } from './Components/Incomes and expenses/add-expense/incomes/incomes.component';
import { ExpensesComponent } from './Components/Incomes and expenses/add-expense/incomes/expenses/expenses.component';
import { NewBudgetComponent } from './Components/Budgets/new-budget/new-budget.component';
import { SignInComponent } from './Components/Users/sign-in/sign-in.component';
import { AddIncomeComponent } from './Components/add-income/add-income.component';
import { AddExpenseComponent } from './Components/Incomes and expenses/add-expense/add-expense.component';
import { PaymentsListComponent } from './Components/Incomes and expenses/add-expense/payments-list/payments-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { UpdatePasswordComponent } from './Components/Users/update-password/update-password.component';
import { UpdateUsedComponent } from './Components/Users/update-used/update-used.component';
import { NavComponent } from './Components/nav/nav.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BudgetHomePageComponent } from './Components/Budgets/budget-home-page/budget-home-page.component';

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
    PaymentsListComponent,
    HomePageComponent,
    UpdatePasswordComponent,
    UpdateUsedComponent,
    NavComponent,
    BudgetHomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
