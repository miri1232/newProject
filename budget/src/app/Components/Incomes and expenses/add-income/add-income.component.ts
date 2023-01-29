import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/Classes/Category';
import { CategoryIncome } from 'src/app/Classes/CategoryIncome';
import { Income } from 'src/app/Classes/Income';
import { CategoryIncomeService } from 'src/app/Services/category-income.service';
import { IncomesService } from 'src/app/Services/incomes.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-add-income',
  templateUrl: './add-income.component.html',
  styleUrls: ['./add-income.component.scss']
})
export class AddIncomeComponent implements OnInit {

  newIncome = new Income();
  IsIncome: boolean | undefined;

  public listTypeCategory: CategoryIncome[] | undefined;

  typeIncomeFormControl = new FormControl(null, Validators.required);

  constructor(
    private log: Logging,
    private formBuilder: FormBuilder,
    // private myBudget: BudgetService,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService,
    private myIncome: IncomesService,
    private myCategoryIncomeSer: CategoryIncomeService,
  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    this.myCategoryIncomeSer.GetAllCategory().subscribe(res => {
      this.listTypeCategory = res;
      console.log(this.listTypeCategory);
    });

    this.eventForm = new FormGroup({
      nameBudget: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      manager: new FormControl(this.log.ActiveUser.Id),
      type: new FormControl("",this.typeBudgetFormControl.value),
    });
    
  }

  AddIncome

}
