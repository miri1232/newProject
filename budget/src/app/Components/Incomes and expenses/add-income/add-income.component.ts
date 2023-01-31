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
      manager: new FormControl(this.log.ActiveUser.id),
      type: new FormControl("",this.typeIncomeFormControl.value),
    });
    
  }

   AddIncome(){
    if (this.eventForm.value != undefined) {
      console.log("**הוצאה חדשה**" + this.eventForm.value.newIncome)

      this.newIncome.Id = this.typeIncomeFormControl.value;
      this.newIncome.IdBudget = this.eventForm.controls.newIncome.value;
      this.newIncome.Date = this.eventForm.controls.newIncome.value;
      this.newIncome.Sum = this.eventForm.controls.newIncome.value;
      this.newIncome.Category = this.eventForm.controls.newIncome.value;
      this.newIncome.SourceOfIncome = this.eventForm.controls.newIncome.value;
      this.newIncome.Detail = this.eventForm.controls.newIncome.value;
      this.newIncome.PaymentMethod = this.eventForm.controls.newIncome.value;
      this.newIncome.Status = this.eventForm.controls.newIncome.value;
      this.newIncome.Document = this.eventForm.controls.newIncome.value;


      
      this.newIncome.AddIncome(this.newIncome).subscribe(res1 => {
        console.log("curent Income ======>", res1.valueOf)
        this.newIncome = this.eventForm.value;
        alert( " נוספה הכנסה חדשה נוסף תקציב בכינוי");
        this.newIncome = new Income();
        this.router.navigate(['/BudgetHomePage']);
      })
    }
   }

}
