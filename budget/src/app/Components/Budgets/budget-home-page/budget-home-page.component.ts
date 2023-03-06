import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { Logging } from 'src/shared/log.service';
import { NgbModal, NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { AddExpenseComponent } from '../../Incomes and expenses/add-expense/add-expense.component';
import { AddIncomeComponent } from '../../Incomes and expenses/add-income/add-income.component';
import { AddPermissionComponent } from '../add-permission/add-permission.component';


@Component({
  selector: 'app-budget-home-page',
  templateUrl: './budget-home-page.component.html',
  styleUrls: ['./budget-home-page.component.scss'],
  template: `
  <button type="button" ngbPopover="AddExpenseComponent" ngbPopoverPlacement="top" ngbPopoverContent>Open Popover</button>
`
  
})
export class BudgetHomePageComponent implements OnInit {

  addExpenses:boolean=false;
  addIncomes:boolean=false;
  addPayment:boolean=false;
  addPermission:boolean=false;

  constructor(
    private log:Logging,
    private modalService: NgbModal,

  ) { }

  b:Budget=this.log.ActiveBudget;

  ngOnInit(): void {
  }

  AddExpenses(){
    const modalRef2 = this.modalService.open(AddExpenseComponent);
  }

  AddIncomes(){
    const modalRef2 = this.modalService.open(AddIncomeComponent);
  }
  AddPermission(){
    const modalRef2 = this.modalService.open(AddPermissionComponent);

  }

}
