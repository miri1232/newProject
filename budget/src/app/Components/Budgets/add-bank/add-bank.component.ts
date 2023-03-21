import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Bank } from 'src/app/Classes/Bank';
import { BankOfBudget } from 'src/app/Classes/BankOfBudget';
import { BankService } from 'src/app/Services/bank.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-add-bank',
  templateUrl: './add-bank.component.html',
  styleUrls: ['./add-bank.component.scss']
})
export class AddBankComponent implements OnInit {

  newBank : BankOfBudget= new BankOfBudget();

  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listBanks: Bank[] | undefined;


  constructor(
    private router: Router,
    private route: ActivatedRoute,   
     private log: Logging,
     private bankOfBudgetSer:BankService,
     private lookupSer: LookupService,
     private formBuilder: FormBuilder,
     private modalService: NgbModal,

  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    //יבוא נתונים עבור רשימה נפתחת
    this.lookupSer.GetAllBank().subscribe(res => {
      this.listBanks = res;
      console.log(this.listBanks);
    });

    
  //הקמת הטופס
  this.eventForm = new FormGroup({
    id: new FormControl(0),
    idBudget: new FormControl(5),
    idBank:new FormControl(""),
    branch_Number: new FormControl(""),
    account_Number: new FormControl(""),


  });

}

AddBankOfBudget(){
  
  if (this.eventForm.value != undefined) {
    console.log("**פרטים**" + this.eventForm.value)

this.bankOfBudgetSer.AddBankOfBudget(this.eventForm.value).subscribe(res =>{
  if(res){
    const modalRef = this.modalService.open(ActionDialogComponent);
    modalRef.componentInstance.content = " נוסף לרשימת הבנקים המשוייכים לתקציב";
  }
});
} 

}






}