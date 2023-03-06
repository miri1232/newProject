import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Classes/Category';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { PaymentMethod } from 'src/app/Classes/PaymentMethod';
import { SourceOfIncome } from 'src/app/Classes/SourceOfIncome';
import { Status } from 'src/app/Classes/Status';
import { CategoryIncomeService } from 'src/app/Services/category-income.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { SourceOfIncomeService } from 'src/app/Services/source-of-income.service';
import { Logging } from 'src/shared/log.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';


@Component({
  selector: 'app-add-income',
  templateUrl: './add-income.component.html',
  styleUrls: ['./add-income.component.scss']
})
export class AddIncomeComponent implements OnInit {

  newIncome = new Income();
  IsIncome: boolean | undefined;

  public listTypeCategory: CategoryIncome[] | undefined;
  public listTypeSourceOfIncome: SourceOfIncome[] | undefined;
  public listTypePaymentMethod : PaymentMethod[] | undefined;
  public listTypeStatus: Status[] | undefined;

  typeIncomeFormControl = new FormControl(null, Validators.required);

  constructor(
    public activeModal: NgbActiveModal,   
    private log: Logging,
    private formBuilder: FormBuilder,
    // private myBudget: BudgetService,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService,
    private myIncome: IncomesService,
    private myCategoryIncomeSer: CategoryIncomeService,
    private mySourceOfIncomeSer: SourceOfIncomeService,
    private modalService: NgbModal,

  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    this.myCategoryIncomeSer.GetAllCategory().subscribe(res => {
      this.listTypeCategory = res;
      console.log(this.listTypeCategory);
    });

    this.mySourceOfIncomeSer.GetAllSourceOfIncomes().subscribe(res => {
      this.listTypeSourceOfIncome = res;
      console.log(this.listTypeSourceOfIncome);
    });

    this.lookupSer.GetAllPaymentMethod().subscribe(res => {
      this.listTypePaymentMethod = res;
      console.log(this.listTypePaymentMethod);
    });

    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listTypeStatus = res;
      console.log(this.listTypeStatus);
    });
//הבאת נתונים מהטופס
this.eventForm = new FormGroup({
  idBudget: new FormControl(5007),
      date: new FormControl(""),
       sum: new FormControl(""),
       categoryIncome: new FormControl(""),
       sourceOfIncome: new FormControl(""),
        detail: new FormControl(""),
        paymentMethod: new FormControl(""),
       status: new FormControl(""),
            document: new FormControl(""),
    }); 

  }
 

    AddIncome(){
    if (this.eventForm.value != undefined) {
     // console.log("הכנסה חדשה נקלטה" )

    this.newIncome = this.eventForm.value;

      // this.newIncome.idBudget = this.log.ActiveBudget.id;
      // this.newIncome.date = this.eventForm.controls.date.value;
      // this.newIncome.sum = this.eventForm.controls.sum.value;
      // this.newIncome.category = this.eventForm.controls.category.value;
      // this.newIncome.sourceOfIncome = this.eventForm.controls.sourceOfIncome.value;
      // this.newIncome.detail = this.eventForm.controls.detail.value;
      // this.newIncome.paymentMethod = this.eventForm.controls.paymentMethod.value;
      // this.newIncome.status = this.eventForm.controls.status.value;
      // this.newIncome.document = this.eventForm.controls.document.value;


      
      this.myIncome.AddIncome(this.eventForm.value).subscribe(res1 => {
        console.log("curent Income ======>", res1)
        this.newIncome = this.eventForm.value;

        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = "ההכנסה נקלטה בהצלחה";
        this.activeModal.close();
        
        this.newIncome = new Income();

        
       
      })
    }
   }

}
