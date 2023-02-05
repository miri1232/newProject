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
  [x: string]: any;

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

    // this.eventForm = new FormGroup({
    //   nameBudget: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
    //   manager: new FormControl(this.log.ActiveUser.id),
    //   type: new FormControl("",this.typeBudgetFormControl.value),
    // });

    this.eventForm = new FormGroup({
      nameBudget: new FormControl(""),
      manager: new FormControl(),
      type: new FormControl(""),
    });
    
  }


  
  AddBudget() {

    if (this.eventForm.value != undefined) {
      console.log("**שם תקציב**" + this.eventForm.value.nameBudget)

      this.newBudget = this.eventForm.value;
      // this.newBudget.type = this.typeBudgetFormControl.value;
      // this.newBudget.manager = '300668852';
      // this.newBudget.nameBudget = this.eventForm.controls.nameBudget.value;
       
      
      this.myBudget.AddBudget(this.newBudget).subscribe(res1 => {
        console.log("curent Budget ======>", res1.valueOf)
        this.newBudget = this.eventForm.value;
        alert(this.newBudget.nameBudget + " נוסף תקציב בכינוי");
        this.newBudget = new Budget();
       // this.router.navigate(['/BudgetHomePage']);
       
      })
    }

  }


}



