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
import { Subcategory } from 'src/app/Classes/Subcategory';


@Component({
  selector: 'app-add-income',
  templateUrl: './add-income.component.html',
  styleUrls: ['./add-income.component.scss']
})
export class AddIncomeComponent implements OnInit {

  public nameNewCategory!: string;
  public nameNewSourceOfIncome!: string;

  newCategory = new Category();
  newSourceOfIncome = new SourceOfIncome();

  newIncome = new Income();
 // IsIncome: boolean | undefined;

 //עבר יבוא מערכים לנתוני תיבה נפתחת
  public listTypeCategory: CategoryIncome[] | undefined;
  public listTypeSourceOfIncome: SourceOfIncome[] | undefined;
  public listTypePaymentMethod: PaymentMethod[] | undefined;
  public listTypeStatus: Status[] | undefined;

   //עבור רשימה נפתחת מצומצמת לתת קטגוריה
   public idCategory: number = 0;
   public idSourceOfIncome: number = 0;

   public listSourceOfIncomeByCategory: SourceOfIncome[] = [];


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
    //יבוא נתונים עבור רשימות נפתחות

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
  filterByCategory() {

    console.log("idCategory", this.idCategory)
    this.mySourceOfIncomeSer.GetSourceOfIncomeByID(this.idCategory).subscribe(res => {

      this.listSourceOfIncomeByCategory = res;
      console.log(this.listSourceOfIncomeByCategory);
    });
  }

  AddIncome() {
    if (this.eventForm.value != undefined) {
      // console.log("הכנסה חדשה נקלטה" )

      this.newIncome = this.eventForm.value;

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
        this.idCategory=0;
        this.myCategoryIncomeSer.GetAllCategory().subscribe(res => {
          this.listTypeCategory = res;
          console.log(this.listTypeCategory);
        });
      })
    }


  }
  AddSourceOfIncome() {
    if (this.nameNewSourceOfIncome != undefined) {
      console.log(this.nameNewSourceOfIncome)
      this.newSourceOfIncome.detail = this.nameNewSourceOfIncome;
      this.newSourceOfIncome.categoryIncome = this.idCategory;
    
      this.myCategoryIncomeSer.AddSourceOfIncome(this.newSourceOfIncome).subscribe(res1 => {
        console.log("אישור הוספת תת קטגוריה ======>", res1)
        // this.addSubCategory = false;
        this.filterByCategory();
       this.idSourceOfIncome=0;
  
      })
    }
  
  
    }

}
