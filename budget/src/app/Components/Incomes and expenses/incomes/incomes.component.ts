import { Component, OnInit } from '@angular/core';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { CategoryIncomeService } from 'src/app/Services/category-income.service';
import { CategoryService } from 'src/app/Services/category.service';
import { IncomesService } from 'src/app/Services/incomes.service';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.scss']
})
export class IncomesComponent implements OnInit {
  
  IncomeList : Income[] = [];
  CategoryIncomeList : CategoryIncome[] = [];


  constructor(
    private myIncomeServise: IncomesService,
    private myCategoryIncome:CategoryIncomeService,
  ) { }

  ngOnInit(): void {
    this.myIncomeServise.GetAllIncomes().subscribe(exp => { 
      this.IncomeList = exp;
      console.log(exp);
  } );
 this.myCategoryIncome.GetAllCategory().subscribe(c => { 
      this.CategoryIncomeList = c;
      console.log(c);
  } );

  }

  

}
