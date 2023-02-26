import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Classes/Category';
import { Expense } from 'src/app/Classes/Expense';
import { PaymentMethod } from 'src/app/Classes/PaymentMethod';
import { Status } from 'src/app/Classes/Status';
import { Subcategory } from 'src/app/Classes/Subcategory';
import { CategoryService } from 'src/app/Services/category.service';
import { ExpensesService } from 'src/app/Services/expenses.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { SubCategoryService } from 'src/app/Services/sub-category.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.scss']
})
export class AddExpenseComponent implements OnInit {

  // addCategory: boolean = false;
  // addSubCategory: boolean = false;

  public nameNewCategory!: string;
    public nameNewSubCategory!: string;

  newCategory = new Category();
  newSubCategory = new Subcategory();

  newExpense = new Expense();
  // IsExpense: boolean | undefined;

  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listCategory: Category[] | undefined;
  public listSubcategory: Subcategory[] = [];
  public listStatus: Status[] | undefined;
  public listPaymentMethod: PaymentMethod[] | undefined;

  //עבור רשימה נפתחת מצומצמת לתת קטגוריה
  public idCategory: number = 0;
  public idSubcategory: number = 0;

  public listSubcategoryByCategory: Subcategory[] = [];


  //עבור תיבה נפתחת
  // categoryFormControl = new FormControl(Validators.prototype);
  // statusFormControl = new FormControl( Validators.required);
  // subcategoryFormControl = new FormControl( Validators.required);
  // paymentMethodFormControl = new FormControl( Validators.required);


  constructor(
    private log: Logging,
    private formBuilder: FormBuilder,
    //private myBudget: BudgetService,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService,
    private myExpense: ExpensesService,
    private myCategory: CategoryService,
    private mySubCategory: SubCategoryService,
    private modalService: NgbModal
  ) { }

  eventForm!: FormGroup;

  // ngDoCheck(): void {
  //   this.mySubCategory.GetSubcategoryByCategory(this.idCategory).subscribe(res => {
  //     this.listSubcategoryByCategory = res;
  //     console.log(this.listSubcategoryByCategory);
  //   });
  // }

  ngOnInit(): void {
    // //יבוא נתונים עבור רשימות נפתחות
    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
      console.log(this.listStatus);
    });
    this.lookupSer.GetAllPaymentMethod().subscribe(res => {
      this.listPaymentMethod = res;
      console.log(this.listPaymentMethod);
    });

    this.myCategory.GetAllCategory().subscribe(res => {
      this.listCategory = res;
      console.log(this.listCategory);
    });
    this.mySubCategory.GetAllSubcategory().subscribe(res => {
      this.listSubcategory = res;
      console.log(this.listSubcategory);
    });




    //הקמת הטופס
    this.eventForm = new FormGroup({
      idBudget: new FormControl(5007),
      date: new FormControl(""),
      sum: new FormControl(""),
      category: new FormControl(""),
      subCategory: new FormControl(""),
      detail: new FormControl(""),
      paymentMethod: new FormControl(""),
      frequency: new FormControl(false),
      //  numberOfPayments:new FormControl("" ),
      status: new FormControl(""),
      document: new FormControl(""),
    });



  }

  filterByCategory() {

    console.log("idCategory", this.idCategory)
    this.mySubCategory.GetSubcategoryByCategory(this.idCategory).subscribe(res => {

      this.listSubcategoryByCategory = res;
      console.log(this.listSubcategoryByCategory);
    });
  }
  AddExpense() {

    if (this.eventForm.value != undefined) {
      //  console.log("ההוצאה נקלטה")

      this.newExpense = this.eventForm.value;

      this.myExpense.AddExpense(this.eventForm.value).subscribe(res1 => {
        console.log("curent user ======>", res1)
        this.newExpense = this.eventForm.value;
        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = "ההוצאה נקלטה בהצלחה";

        this.newExpense = new Expense();

      })
    }
  }

  AddCategory() {
    if (this.nameNewCategory != undefined) {
      console.log(this.nameNewCategory)
      this.newCategory.detail = this.nameNewCategory;
      this.myCategory.AddCategory(this.newCategory).subscribe(res1 => {
        console.log("אישור הוספת קטגוריה ======>", res1)
        // this.addCategory = false;
        this.idCategory=0;

      })
    }


  }

  AddSubcategory() {
  if (this.nameNewSubCategory != undefined) {
    console.log(this.nameNewSubCategory)
    this.newSubCategory.detail = this.nameNewSubCategory;
    this.newSubCategory.category = this.idCategory;
  
    this.mySubCategory.AddSubcategory(this.newSubCategory).subscribe(res1 => {
      console.log("אישור הוספת תת קטגוריה ======>", res1)
      // this.addSubCategory = false;
      this.filterByCategory();
     this.idSubcategory=0;

    })
  }


  }
}

