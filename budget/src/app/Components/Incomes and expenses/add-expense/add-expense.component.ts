import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Classes/Category';
import { Expense } from 'src/app/Classes/Expense';
import { PaymentMethod } from 'src/app/Classes/PaymentMethod';
import { Status } from 'src/app/Classes/Status';
import { Subcategory } from 'src/app/Classes/Subcategory';
import { CategoryService } from 'src/app/Services/category.service';
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

  public listCategory: Category[] | undefined;
  public listSubcategory: Subcategory[] | undefined;
  public listStatus: Status[] | undefined;
  public listPaymentMethod: PaymentMethod[] | undefined;


  categoryFormControl = new FormControl(null, Validators.required);
  statusFormControl = new FormControl(null, Validators.required);
  SubcategoryFormControl = new FormControl(null, Validators.required);
  PaymentMethodFormControl = new FormControl(null, Validators.required);


  constructor(
    private log: Logging,
    private formBuilder: FormBuilder,
    //private myBudget: BudgetService,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService,
    private myExpense: Expense,
    private myCategory: CategoryService,
    private mySubCategory: SubCategoryService,


  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
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

    this.eventForm = new FormGroup({
      idBudget: new FormControl(this.log.ActiveBudget.id),
      date: new FormControl("", [Validators.required]),
      sum: new FormControl("", [Validators.required]),
      category:  new FormControl("",this.categoryFormControl.value),
      subCategory:  new FormControl("",this.SubcategoryFormControl.value),
      detail:new FormControl("", [Validators.required]),
      paymentMethod:new FormControl( "", this.PaymentMethodFormControl.value),
      frequency:new FormControl("", [Validators.required]),
      numberOfPayments:new FormControl(  "", [Validators.required]),
      status:new FormControl( "",this.statusFormControl.value),
      document:new FormControl(  "", [Validators.required]),
    });
    

  }


  AddExpense(){


  }


}
