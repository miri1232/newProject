import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BankOfBudget } from 'src/app/Classes/BankOfBudget';
import { Budget } from 'src/app/Classes/Budget';
import { BankService } from 'src/app/Services/bank.service';
import { BudgetService } from 'src/app/Services/budget.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';
import { AddBankComponent } from '../add-bank/add-bank.component';
import { PermissionService } from 'src/app/Services/permission.service';
import { User } from 'src/app/Classes/User';

@Component({
  selector: 'app-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.scss']
})
export class BankComponent implements OnInit {

  listBanksOfBudget: BankOfBudget[] =[];

  activeBudget!: Budget;
  activeUser!: User;
  permissionLevel: number=0;

  // addBank: boolean = false;

  constructor(
    private LookupSer: LookupService,
    private router: Router,
    private bankOfBudgetSer: BankService,
    private log: Logging,
    private modalService: NgbModal,
    private budgetService: BudgetService,
    private activatedRoute: ActivatedRoute,
    private permissionSer:PermissionService,

    //  private addBankComp: AddBankComponent,
  ) { 
    this.bankOfBudgetSer.sharedBankList$.subscribe(res => {
      this.listBanksOfBudget = res;
            console.log(this.listBanksOfBudget);

    })    
  }

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)
    this.log.sharedActiveUser.subscribe(user => this.activeUser = user)
    this.bankOfBudgetSer.GetBankOfBudgetByIdBudget(this.activeBudget.id).subscribe(res => {
      this.listBanksOfBudget = res;
    });
    this.permissionSer.GetLevelPermissionForBudgetByID(this.activeBudget.id, this.activeUser.id).subscribe(level => this.permissionLevel = level)

  }

  AddBank() {
    const modalRef2 = this.modalService.open(AddBankComponent);
    modalRef2.componentInstance.activeBudget = this.activeBudget;
    // modalRef2.result.then((result) => {
    //   this.listBanksOfBudget?.push(result);
   // })
  }

  goToLinkBank(link: string) {
    window.open(link, "_blank");
  }

}
