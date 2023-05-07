import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Budget } from 'src/app/Classes/Budget';
import { Category } from 'src/app/Classes/Category';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { PaymentMethod } from 'src/app/Classes/PaymentMethod';
import { SourceOfIncome } from 'src/app/Classes/SourceOfIncome';
import { Status } from 'src/app/Classes/Status';
import { BudgetService } from 'src/app/Services/budget.service';
import { CategoryIncomeService } from 'src/app/Services/category-income.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { SourceOfIncomeService } from 'src/app/Services/source-of-income.service';
import { Logging } from 'src/shared/log.service';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';

@Component({
  selector: 'app-update-income',
  templateUrl: './update-income.component.html',
  styleUrls: ['./update-income.component.scss']
})
export class UpdateIncomeComponent implements OnInit {
 
  @Input()
  activeBudget!: Budget;
  incomeToUpdate!: Income;

  public nameNewCategory!: string;
  public nameNewSourceOfIncome!: string;
  newCategory = new Category();
  newSourceOfIncome = new SourceOfIncome();
  defaultDate?: Date;

  //עבר יבוא מערכים לנתוני תיבה נפתחת
  public listCategory: CategoryIncome[] | undefined;
  public listSourceOfIncome: SourceOfIncome[] | undefined;
  public listPaymentMethod: PaymentMethod[] | undefined;
  public listStatus: Status[] | undefined;

  //עבור רשימה נפתחת מצומצמת לתת קטגוריה
  public idCategory: number = 0;
  public idSourceOfIncome: number = 0;

  public listSourceOfIncomeByCategory: SourceOfIncome[] = [];


  constructor(
    public activeModal: NgbActiveModal,
    private log: Logging,
    private formBuilder: FormBuilder,
    private myBudget: BudgetService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private lookupSer: LookupService,
    private myIncome: IncomesService,
    private myCategoryIncomeSer: CategoryIncomeService,
    private mySourceOfIncomeSer: SourceOfIncomeService,
    private modalService: NgbModal,

  ) {}

  eventForm!: FormGroup;

  ngOnInit(): void {
    
    this.defaultDate = this.incomeToUpdate.date;
    this.idCategory = this.incomeToUpdate.categoryIncome;
    this.idSourceOfIncome = this.incomeToUpdate.sourceOfIncome;
  

    //יבוא נתונים עבור רשימות נפתחות
    this.myCategoryIncomeSer.GetAllCategory().subscribe(res => {
      this.listCategory = res;
      console.log(this.listCategory);
    });
    this.mySourceOfIncomeSer.GetAllSourceOfIncomes().subscribe(res => {
      this.listSourceOfIncome = res;
      console.log(this.listSourceOfIncome);
    });
    this.lookupSer.GetAllPaymentMethod().subscribe(res => {
      this.listPaymentMethod = res;
      console.log(this.listPaymentMethod);
    });
    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
      console.log(this.listStatus);
    });
    this.filterByCategory();
    
    //הבאת נתונים מהטופס
    this.eventForm = new FormGroup({
      id: new FormControl(this.incomeToUpdate.id),
      idBudget: new FormControl(this.incomeToUpdate.idBudget),
      date: new FormControl(this.defaultDate),
      sum: new FormControl(this.incomeToUpdate.sum),
      categoryIncome: new FormControl(this.incomeToUpdate.categoryIncome),
      categoryIncomeDetail: new FormControl(this.incomeToUpdate.categoryIncomeDetail),
      sourceOfIncome: new FormControl(this.incomeToUpdate.sourceOfIncome),
      detail: new FormControl(this.incomeToUpdate.detail),
      paymentMethod: new FormControl(this.incomeToUpdate.paymentMethod),
      status: new FormControl(this.incomeToUpdate.status),
      document: new FormControl(this.incomeToUpdate.document),

    });

  }
  filterByCategory() {

    console.log("idCategory", this.idCategory)
    this.mySourceOfIncomeSer.GetSourceOfIncomeByID(this.idCategory).subscribe(res => {

      this.listSourceOfIncomeByCategory = res;
      console.log(this.listSourceOfIncomeByCategory);
    });
  }

 
  AddCategoryIncome() {
    if (this.nameNewCategory != undefined) {
      console.log(this.nameNewCategory)
      this.newCategory.detail = this.nameNewCategory;
      this.myCategoryIncomeSer.AddCategoryIncome(this.newCategory).subscribe(res1 => {
        console.log("אישור הוספת קטגוריה ======>", res1)
        // this.addCategory = false;
        this.idCategory = 0;
        this.myCategoryIncomeSer.GetAllCategory().subscribe(res => {
          this.listCategory = res;
          console.log(this.listCategory);
        });
      })
    }


  }
  AddSourceOfIncome() {
    if (this.nameNewSourceOfIncome != undefined) {
      console.log(this.nameNewSourceOfIncome)
      this.newSourceOfIncome.detail = this.nameNewSourceOfIncome;
      this.newSourceOfIncome.categoryIncome = this.idCategory;

      this.mySourceOfIncomeSer.AddSourceOfIncome(this.newSourceOfIncome).subscribe(res1 => {
        console.log("אישור הוספת תת קטגוריה ======>", res1)
        // this.addSubCategory = false;
        this.filterByCategory();
        this.idSourceOfIncome = 0;

      })
    }
  }

  close() {
    this.activeModal.close();
    const modalRef = this.modalService.open(ActionDialogComponent);
    modalRef.componentInstance.content = "השינויים לא נשמרו";

  }

  UpdateIncome() {

    if (this.eventForm.value != undefined) {
      //  console.log("ההכנסה נקלטה")

      this.incomeToUpdate = this.eventForm.value;

      this.myIncome.UpdateIncome(this.eventForm.value).subscribe(res1 => {
        console.log("curent user ======>", res1)
        this.incomeToUpdate = this.eventForm.value;
        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = "ההכנסה עודכנה בהצלחה";
        this.activeModal.close();

        this.incomeToUpdate = new Income();

      })
    }
  }

}
