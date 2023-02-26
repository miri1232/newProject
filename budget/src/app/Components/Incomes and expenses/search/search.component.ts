import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Classes/Category';
import { Status } from 'src/app/Classes/Status';
import { Subcategory } from 'src/app/Classes/Subcategory';
import { CategoryService } from 'src/app/Services/category.service';
import { ExpensesService } from 'src/app/Services/expenses.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { SubCategoryService } from 'src/app/Services/sub-category.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  public listCategory: Category[] | undefined;
  public listSubcategory: Subcategory[] =[];
  public listStatus: Status[] | undefined;
  
    //עבור רשימה נפתחת מצומצמת לתת קטגוריה
    public idCategory:number=0;
    public listSubcategoryByCategory: Subcategory[]=[];
   

    
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

  ngOnInit(): void {
    
    // //יבוא נתונים עבור רשימות נפתחות
    this.lookupSer.GetAllStatus().subscribe(res => {
      this.listStatus = res;
      console.log(this.listStatus);
    });
 

    this.myCategory.GetAllCategory().subscribe(res => {
      this.listCategory = res;
      console.log(this.listCategory);
    });
    this.mySubCategory.GetAllSubcategory().subscribe(res => {
      this.listSubcategory = res;
      console.log(this.listSubcategory);
    });


  }
  filterByCategory(){

  }
  search(){
    
  }

}
