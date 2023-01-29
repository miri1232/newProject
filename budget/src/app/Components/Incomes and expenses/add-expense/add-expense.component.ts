import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Classes/Category';
import { Expense } from 'src/app/Classes/Expense';
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


  typeExpenseFormControl = new FormControl(null, Validators.required);


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
    // this.lookupSer.GetAllTypeBudget().subscribe(res => {
    //   this.listTypeBudget = res;
    //   console.log(this.listTypeBudget);
    // });
    this.myCategory.GetAllCategory().subscribe(res => {
      this.listCategory = res;
      console.log(this.listCategory);
    });

    this.eventForm = new FormGroup({
      nameBudget: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      manager: new FormControl(this.log.ActiveUser.Id),
      type: new FormControl("",this.typeBudgetFormControl.value),
    });
    

  }


  AddExpense(){


  }


}
