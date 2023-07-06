import { Component, OnInit } from '@angular/core';
import { Budget } from 'src/app/Classes/Budget';
import { Logging } from 'src/shared/log.service';
import { NgbModal, } from '@ng-bootstrap/ng-bootstrap';
import { AddExpenseComponent } from '../../Incomes and expenses/add-expense/add-expense.component';
import { AddIncomeComponent } from '../../Incomes and expenses/add-income/add-income.component';
import { AddPermissionComponent } from '../add-permission/add-permission.component';
import { BudgetService } from 'src/app/Services/budget.service';
import { ActivatedRoute } from '@angular/router';
import { BankService } from 'src/app/Services/bank.service';
import { User } from 'src/app/Classes/User';
import { PermissionService } from 'src/app/Services/permission.service';


@Component({
  selector: 'app-budget-home-page',
  templateUrl: './budget-home-page.component.html',
  styleUrls: ['./budget-home-page.component.scss'],
  template: `
`

})
export class BudgetHomePageComponent implements OnInit {

  activeBudget!: Budget;
  activeUser!: User;
  permissionLevel: number=0;

  addExpenses: boolean = false;
  addIncomes: boolean = false;
  addPayment: boolean = false;
  addPermission: boolean = false;
  // b!: Budget;

  constructor(
    private log: Logging,
    private modalService: NgbModal,
    private budgetService: BudgetService,
    private activatedRoute: ActivatedRoute,
    private bankOfBudgetSer: BankService,
    private permissionSer:PermissionService,
 
  ) { }



  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)
    this.log.sharedActiveUser.subscribe(user => this.activeUser = user)
    this.permissionSer.GetLevelPermissionForBudgetByID(this.activeBudget.id, this.activeUser.id).subscribe(level => this.permissionLevel = level)
  }

  AddExpenses() {
    const modalRef2 = this.modalService.open(AddExpenseComponent);
    modalRef2.componentInstance.activeBudget = this.activeBudget;

  }

  AddIncomes() {
    const modalRef2 = this.modalService.open(AddIncomeComponent);
    modalRef2.componentInstance.activeBudget = this.activeBudget;

  }
  AddPermission() {
    const modalRef2 = this.modalService.open(AddPermissionComponent);
    modalRef2.componentInstance.activeBudget = this.activeBudget;

  }

}
