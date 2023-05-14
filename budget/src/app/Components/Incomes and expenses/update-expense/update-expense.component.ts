import { Component, Input, OnInit } from '@angular/core';
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
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Budget } from 'src/app/Classes/Budget';
import { BudgetService } from 'src/app/Services/budget.service';
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-update-expense',
  templateUrl: './update-expense.component.html',
  styleUrls: ['./update-expense.component.scss']
})
export class UpdateExpenseComponent implements OnInit {

  @Input()
  activeBudget!: Budget;
  expenseToUpdate!: Expense;


  public nameNewCategory!: string;
  public nameNewSubCategory!: string;
  newCategory = new Category();
  newSubCategory = new Subcategory();
  defaultDate?: Date;

  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listCategory: Category[] | undefined;
  public listSubcategory: Subcategory[] = [];
  public listStatus: Status[] | undefined;
  public listPaymentMethod: PaymentMethod[] | undefined;

  //עבור רשימה נפתחת מצומצמת לתת קטגוריה
  public idCategory: number = 0;//this.expenseToUpdate.category;
  public idSubcategory: number = 0;//this.expenseToUpdate.subcategory; 

  //public idCategory: number =2;
  //public idSubcategory: number =3;

  public listSubcategoryByCategory: Subcategory[] = [];




  constructor(
    public activeModal: NgbActiveModal,
    private log: Logging,
    private formBuilder: FormBuilder,
    private myBudget: BudgetService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private lookupSer: LookupService,
    private myExpense: ExpensesService,
    private myCategory: CategoryService,
    private mySubCategory: SubCategoryService,
    private modalService: NgbModal,
  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    this.defaultDate = this.expenseToUpdate.date;
    this.idCategory = this.expenseToUpdate.category;
    this.idSubcategory = this.expenseToUpdate.subcategory;
  
    // //יבוא נתונים עבור רשימות נפתחות
    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
      console.log(this.listStatus);
      // this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget)

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
this.filterByCategory();
    //הקמת הטופס
    this.eventForm = new FormGroup({
      id: new FormControl(this.expenseToUpdate.id),
      idBudget: new FormControl(this.expenseToUpdate.idBudget),
      date: new FormControl(this.defaultDate),//+"/"+ | date: 'dd/MM/yyyy'),
      sum: new FormControl(this.expenseToUpdate.sum),
      category: new FormControl(this.expenseToUpdate.category),
      categoryDetail: new FormControl(this.expenseToUpdate.categoryDetail),//
       subCategory: new FormControl(this.expenseToUpdate.subcategory),
      // subcategoryDetail: new FormControl(this.expenseToUpdate.subcategoryDetail),//
      detail: new FormControl(this.expenseToUpdate.detail),
      paymentMethod: new FormControl(this.expenseToUpdate.paymentMethod),
      frequency: new FormControl(this.expenseToUpdate.frequency),
      status: new FormControl(this.expenseToUpdate.status),
      document: new FormControl(this.expenseToUpdate.document),
    });

  }



  filterByCategory() {

    console.log("idCategory", this.idCategory)
    this.mySubCategory.GetSubcategoryByCategory(this.idCategory).subscribe(res => {

      this.listSubcategoryByCategory = res;
      console.log(this.listSubcategoryByCategory);
    });
  }

  AddCategory() {
    if (this.nameNewCategory != undefined) {
      console.log(this.nameNewCategory)
      this.newCategory.detail = this.nameNewCategory;
      this.myCategory.AddCategory(this.newCategory).subscribe(res1 => {
        console.log("אישור הוספת קטגוריה ======>", res1)
        // this.addCategory = false;
        this.idCategory = 0;
        this.myCategory.GetAllCategory().subscribe(res => {
          this.listCategory = res;
          console.log(this.listCategory);
        });
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
        this.idSubcategory = 0;

      })
    }


  }
  close() {
    this.activeModal.close();
    const modalRef = this.modalService.open(ActionDialogComponent);
    modalRef.componentInstance.content = "השינויים לא נשמרו";

  }

  UpdateExpense() {

    if (this.eventForm.value != undefined) {
      //  console.log("ההוצאה נקלטה")

      this.expenseToUpdate = this.eventForm.value;

      this.myExpense.UpdateExpense(this.eventForm.value).subscribe(res1 => {
        console.log("curent user ======>", res1)
        this.expenseToUpdate = this.eventForm.value;
        const modalRef = this.modalService.open(ActionDialogComponent);
        modalRef.componentInstance.content = "ההוצאה עודכנה בהצלחה";
        this.activeModal.close();

        this.expenseToUpdate = new Expense();

      })
    }
  }





}
