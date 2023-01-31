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

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.scss']
})
export class AddExpenseComponent implements OnInit {

  
  newExpense = new Expense();
  IsExpense: boolean | undefined;

  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listCategory: Category[] | undefined;
  public listSubcategory: Subcategory[] | undefined;
  public listStatus: Status[] | undefined;
  public listPaymentMethod: PaymentMethod[] | undefined;

//עבור תיבה נפתחת
  categoryFormControl = new FormControl(null, Validators.required);
  statusFormControl = new FormControl(null, Validators.required);
  subcategoryFormControl = new FormControl(null, Validators.required);
  paymentMethodFormControl = new FormControl(null, Validators.required);


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


  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    //יבוא נתונים עבור רשימות נפתחות
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

    // //קליטת נתונים מהטופס
    // this.eventForm = new FormGroup({
    //   idBudget: new FormControl(this.log.ActiveBudget.id),
    //   date: new FormControl("", [Validators.required]),
    //   sum: new FormControl("", [Validators.required]),
    //   category:  new FormControl("",this.categoryFormControl.value),
    //   subCategory:  new FormControl("",this.subcategoryFormControl.value),
    //   detail:new FormControl("", [Validators.required]),
    //   paymentMethod:new FormControl( "", this.paymentMethodFormControl.value),
    //   frequency:new FormControl("", [Validators.required]),
    //   numberOfPayments:new FormControl(  "", [Validators.required]),
    //   status:new FormControl( "",this.statusFormControl.value),
    //   document:new FormControl("", ),
    // });
     
    //הקמת הטופס
    this.eventForm = new FormGroup({
     // idBudget: new FormControl(this.log.ActiveBudget.id),
      date: new FormControl(),
      sum: new FormControl(),
      category:  new FormControl(),
      subCategory:  new FormControl(),
      detail:new FormControl(),
      paymentMethod:new FormControl( ),
      frequency:new FormControl(),
      numberOfPayments:new FormControl( ),
      status:new FormControl(),
      document:new FormControl(),
    });

  }


  AddExpense(){

    if (this.eventForm.value != undefined) {
    //  console.log("ההוצאה נקלטה")


      this.newExpense.idBudget = this.log.ActiveBudget.id;
      this.newExpense.date = this.eventForm.value.date;
      this.newExpense.sum = this.eventForm.value.sum;
      this.newExpense.category = this.eventForm.value.category;
      this.newExpense.subcategory = this.eventForm.value.subCategory;
      this.newExpense.paymentMethod = this.eventForm.value.paymentMethod;
      this.newExpense.frequency = this.eventForm.value.frequency;
      this.newExpense.numberOfPayments = this.eventForm.value.numberOfPayments;
      this.newExpense.status = this.eventForm.value.status;
      this.newExpense.document = this.eventForm.value.document;

      // this.typeBudgetFormControl.value;
      // this.newBudget.manager = this.log.ActiveUser.id;
      // this.newBudget.nameBudget = this.eventForm.controls.nameBudget.value;
       
 
      this.myExpense.AddExpense(this.newExpense).subscribe(res1 => {
        console.log("curent user ======>", res1)
       // this.newExpense = this.eventForm.value;
        alert( " ההוצאה נקלטה בהצלחה ");
        
        this.newExpense = new Expense();


      })
    }

  }


}
