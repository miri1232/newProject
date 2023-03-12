import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BudgetHomePageComponent } from './Components/Budgets/budget-home-page/budget-home-page.component';
import { BudgetsListComponent } from './Components/Budgets/budgets-list/budgets-list.component';
import { NewBudgetComponent } from './Components/Budgets/new-budget/new-budget.component';
import { HomePageComponent } from './Components/General/home-page/home-page.component';
import { LoginComponent } from './Components/Users/login/login.component';
import { SignInComponent } from './Components/Users/sign-in/sign-in.component';
import { UpdatePasswordComponent } from './Components/Users/update-password/update-password.component';
//import { CommonModule } from '@angular/common';



const appRouting:Routes=[
  {path:"",component:HomePageComponent},
  {path:"SignIn",component:SignInComponent},
  { path: "Login",component:LoginComponent},
  { path: "UpdatePassword",component:UpdatePasswordComponent},
  {path:"ListBudgets",component:BudgetsListComponent},
    {path:"BudgetHomePage/:budgetId",component:BudgetHomePageComponent},
    {path:"NewBudget",component:NewBudgetComponent},





];


@NgModule({
  imports: [RouterModule.forRoot(appRouting)
        //,CommonModule
],
  exports: [RouterModule]
})
export class AppRoutingModule {


 }
