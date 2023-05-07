import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/Users/login/login.component';
import { BudgetsListComponent } from './Components/Budgets/budgets-list/budgets-list.component';
import { IncomesComponent } from './Components/Incomes and expenses/incomes/incomes.component';
import { ExpensesComponent } from './Components/Incomes and expenses/expenses/expenses.component';
import { NewBudgetComponent } from './Components/Budgets/new-budget/new-budget.component';
import { SignInComponent } from './Components/Users/sign-in/sign-in.component';
import { AddIncomeComponent } from './Components/Incomes and expenses/add-income/add-income.component';
import { AddExpenseComponent } from './Components/Incomes and expenses/add-expense/add-expense.component';
import { PaymentsListComponent } from './Components/Incomes and expenses/payments-list/payments-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './Components/General/home-page/home-page.component';
import { UpdatePasswordComponent } from './Components/Users/update-password/update-password.component';
import { UpdateUsedComponent } from './Components/Users/update-used/update-used.component';
import { NavComponent } from './Components/General/nav/nav.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BudgetHomePageComponent } from './Components/Budgets/budget-home-page/budget-home-page.component';
import { AddPermissionComponent } from './Components/Budgets/add-permission/add-permission.component';
import { AlertComponent } from './Components/General/alert/alert.component';
import { ActionDialogComponent } from './Components/General/action-dialog/action-dialog.component';
import { BankComponent } from './Components/Budgets/bank/bank.component';
import { AddBankComponent } from './Components/Budgets/add-bank/add-bank.component';
import { SearchComponent } from './Components/Incomes and expenses/search/search.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReportsComponent } from './Components/Incomes and expenses/reports/reports.component';

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
    BudgetHomePageComponent,
    AddPermissionComponent,
    AlertComponent,
    ActionDialogComponent,
    BankComponent,
    AddBankComponent,
    SearchComponent,
    ReportsComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    CommonModule,
    NgbModule
  ],
  providers: [BankComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
