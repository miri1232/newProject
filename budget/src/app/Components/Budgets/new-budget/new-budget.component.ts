import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { TypeBudget } from 'src/app/Classes/TypeBudget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-new-budget',
  templateUrl: './new-budget.component.html',
  styleUrls: ['./new-budget.component.scss']
})
export class NewBudgetComponent implements OnInit {

  newBudget = new Budget();
  IsBudget: boolean | undefined;

  public listTypeBudget: TypeBudget[] | undefined;
  typeBudgetFormControl = new FormControl(null, Validators.required);

  constructor(
    private log: Logging,

    private formBuilder: FormBuilder,
    private myBudget: BudgetService,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService
  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    this.lookupSer.GetAllTypeBudget().subscribe(res => {
      this.listTypeBudget = res;
      console.log(this.listTypeBudget);
    });

    this.eventForm = new FormGroup({
      NameBudget: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      Manager: new FormControl(this.log.ActiveUser.Id),
      Type: new FormControl(0,this.typeBudgetFormControl.value),
    });

    
  }

  AddBudget() {

    if (this.eventForm.value != undefined) {
      console.log("**שם תקציב**" + this.eventForm.value.NameBudget)

      this.newBudget.type = this.typeBudgetFormControl.value;
      this.newBudget.manager = 'null';
      this.newBudget.nameBudget = this.eventForm.controls.NameBudget.value;

      this.myBudget.AddBudget(this.newBudget).subscribe(res1 => {
        console.log("curent Budget ======>", res1)
        this.newBudget = this.eventForm.value;
        alert(this.newBudget.nameBudget + " נוסף תקציב בכינוי");

        // this.log.ActiveUser = this.newBudget;
        this.newBudget = new Budget();
        this.router.navigate(['/ListBudgets']);
      })
    }

  }


}



