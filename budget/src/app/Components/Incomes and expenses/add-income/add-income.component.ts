import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
import { Subcategory } from 'src/app/Classes/Subcategory';
import { Budget } from 'src/app/Classes/Budget';
import { BudgetService } from 'src/app/Services/budget.service';


@Component({
  selector: 'app-add-income',
  templateUrl: './add-income.component.html',
  styleUrls: ['./add-income.component.scss']
})
export class AddIncomeComponent implements OnInit {

  @Input()
  activeBudget!: Budget;

  public nameNewCategory!: string;
  public nameNewSourceOfIncome!: string;
  defaultDate: Date = new Date(); // default to today's date

  newCategory = new Category();
  newSourceOfIncome = new SourceOfIncome();

  newIncome = new Income();


  //עבר יבוא מערכים לנתוני תיבה נפתחת
  public listCategory: CategoryIncome[] | undefined;
  public listSourceOfIncome: SourceOfIncome[] | undefined;
  public listPaymentMethod: PaymentMethod[] | undefined;
  public listStatus: Status[] | undefined;

  //עבור רשימה נפתחת מצומצמת לתת קטגוריה
  public idCategory: number = 0;
  public idSourceOfIncome: number = 0;

  public listSourceOfIncomeByCategory: SourceOfIncome[] = [];

  typeIncomeFormControl = new FormControl(null, Validators.required);

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

  ) {
    this.log.sharedActiveBudget.subscribe(budget => {
      this.activeBudget = budget;
    })
   }

  eventForm!: FormGroup;

  ngOnInit(): void {
    // this.log.sharedActiveBudget.subscribe(budget => {
    //   this.activeBudget = budget;
    // })

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
    //הבאת נתונים מהטופס
    this.eventForm = new FormGroup({
      date: new FormControl(this.defaultDate),
      sum: new FormControl(""),
      categoryIncome: new FormControl(""),
      sourceOfIncome: new FormControl(""),
      detail: new FormControl(""),
      paymentMethod: new FormControl(""),
      status: new FormControl(""),
      document: new FormControl(""),
      idBudget: new FormControl(this.activeBudget.id),

    });

  }
  filterByCategory() {

    console.log("idCategory", this.idCategory)
    this.mySourceOfIncomeSer.GetSourceOfIncomeByID(this.idCategory).subscribe(res => {

      this.listSourceOfIncomeByCategory = res;
      console.log(this.listSourceOfIncomeByCategory);
    });
  }

  AddIncome() {
    if (this.eventForm.value != undefined) {
      this.newIncome = this.eventForm.value;
      // this.newIncome.idBudget=this.activeBudget.id;
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

}
