import { Component, Input, OnInit, } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Bank } from 'src/app/Classes/Bank';
import { BankOfBudget } from 'src/app/Classes/BankOfBudget';
import { BankService } from 'src/app/Services/bank.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { Budget } from 'src/app/Classes/Budget';
import { BankComponent } from '../bank/bank.component';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-add-bank',
  templateUrl: './add-bank.component.html',
  styleUrls: ['./add-bank.component.scss']
})
export class AddBankComponent implements OnInit {

  @Input()
  activeBudget!: Budget;

  newBank: BankOfBudget = new BankOfBudget();

  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listBanks: Bank[] | undefined;

  constructor(
    public activeModal: NgbActiveModal,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private log: Logging,
    private bankOfBudgetSer: BankService,
    private lookupSer: LookupService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private bankComp: BankComponent,
  ) { }

  bankForm!: FormGroup;

  ngOnInit(): void {
    //הקמת הטופס
    this.bankForm = new FormGroup({
      id: new FormControl(0),
      idBudget: new FormControl(this.activeBudget.id),
      idBank: new FormControl(""),
      branch_Number: new FormControl("", [Validators.required]),
      account_Number: new FormControl("", [Validators.required])
    });
    // this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)

    //יבוא נתונים עבור רשימה נפתחת
    this.lookupSer.GetAllBank().subscribe(res => {
      this.listBanks = res;
      console.log(this.listBanks);
    });

  }

  AddBankOfBudget() {

    if (this.bankForm.value != undefined) {
      // console.log("**פרטים**" + this.bankForm.value)

      this.bankOfBudgetSer.AddBankOfBudget(this.bankForm.value).subscribe(res => {
        if (res) {
          this.bankForm.controls['id'].setValue(res);
          const modalRef = this.modalService.open(ActionDialogComponent);
          modalRef.componentInstance.content = " נוסף לרשימת הבנקים המשוייכים לתקציב" + this.activeBudget.nameBudget;

          this.activeModal.close(this.bankForm.value);
          // this.bankComp.addBank = false;
        }
      });
    }

  }






}