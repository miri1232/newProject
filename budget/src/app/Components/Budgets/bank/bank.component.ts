import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bank } from 'src/app/Classes/Bank';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.scss']
})
export class BankComponent implements OnInit {

  public listBanksOfBudget: Bank[] | undefined;

  constructor(
    private LookupSer: LookupService,
    private router: Router,
    private route: ActivatedRoute,   
     private log: Logging,

  ) { }

  ngOnInit(): void {
    this.LookupSer.GetAllBankOfBudget(6).subscribe(res=>{
      this.listBanksOfBudget=res;
            console.log(this.listBanksOfBudget);
    });
  }

}
