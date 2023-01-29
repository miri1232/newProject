import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-budget-home-page',
  templateUrl: './budget-home-page.component.html',
  styleUrls: ['./budget-home-page.component.scss']
})
export class BudgetHomePageComponent implements OnInit {


  addExpenses:boolean=false;
  addIncomes:boolean=false;
  addPayment:boolean=false;

  constructor(
    private log:Logging,

  ) { }

  b:Budget=this.log.ActiveBudget;

  ngOnInit(): void {
  }

}
