import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BudgetsListComponent } from './Components/Budgets/budgets-list/budgets-list.component';
import { HomePageComponent } from './Components/home-page/home-page.component';
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




];


@NgModule({
  imports: [RouterModule.forRoot(appRouting)
        //,CommonModule
],
  exports: [RouterModule]
})
export class AppRoutingModule {


 }
