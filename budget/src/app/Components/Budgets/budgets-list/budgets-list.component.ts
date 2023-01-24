import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-budgets-list',
  templateUrl: './budgets-list.component.html',
  styleUrls: ['./budgets-list.component.scss']
})
export class BudgetsListComponent implements OnInit {
  [x: string]: any;

public BudgetList :Budget[] | undefined;

  constructor(
    private log:Logging,
    private myBudgetServise: BudgetService ,
    private router:Router,

  ) { }

  ngOnInit(): void {

  }
// b:Budget=this.log.ActiveBudget;
U:User=this.log.ActiveUser;

  ShowAllBudget(){
     this.myBudgetServise.GetBudgetByUser().subscribe(budget => { 
       this.BudgetList=budget;
       console.log(this.BudgetList);

     });
     // this.BudgetList=this.myBudgetServise.GetBudgetByUser();
  }


  
     GoBudget( b : Budget){
      this.log.ActiveBudget = b;

      this.router.navigate(['/BudgetHomePage']);

     }


  }

