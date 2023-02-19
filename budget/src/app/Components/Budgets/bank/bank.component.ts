import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bank } from 'src/app/Classes/Bank';
import { BankOfBudget } from 'src/app/Classes/BankOfBudget';
import { BankService } from 'src/app/Services/bank.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.scss']
})
export class BankComponent implements OnInit {

  public listBanksOfBudget: BankOfBudget[] | undefined;

  addBank:boolean=false;

  constructor(
    private LookupSer: LookupService,
    private router: Router,
    private route: ActivatedRoute,   
     private log: Logging,
     private bankOfBudgetSer:BankService,

  ) { }

  ngOnInit(): void {
    this.bankOfBudgetSer.GetBankOfBudgetByIdBudget().subscribe(res=>{
      this.listBanksOfBudget=res;
            console.log(this.listBanksOfBudget);
    });
  }

}
