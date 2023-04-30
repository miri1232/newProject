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

@Component({
  selector: 'app-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.scss']
})
export class BankComponent implements OnInit {

  public listBanksOfBudget: BankOfBudget[] | undefined;

  activeBudget!: Budget;

  addBank: boolean = false;

  constructor(
    private LookupSer: LookupService,
    private router: Router,
    private bankOfBudgetSer: BankService,
    private log: Logging,
    private modalService: NgbModal,
    private budgetService: BudgetService,
    private activatedRoute: ActivatedRoute,
    //  private addBankComp: AddBankComponent,
  ) { }

  ngOnInit(): void {
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)

    this.bankOfBudgetSer.GetBankOfBudgetByIdBudget(this.activeBudget.id).subscribe(res => {
      this.listBanksOfBudget = res;
      console.log(this.listBanksOfBudget);
    });
  }

  AddBank() {
    const modalRef2 = this.modalService.open(AddBankComponent);
    modalRef2.componentInstance.idBudget = this.activeBudget
  }

  goToLinkBank(link: string) {
    window.open(link, "_blank");
  }

}
