import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-new-budget',
  templateUrl: './new-budget.component.html',
  styleUrls: ['./new-budget.component.scss']
})
export class NewBudgetComponent implements OnInit {

  newBudget = new Budget();
  IsBudget: boolean | undefined;

  

  constructor(
    private log:Logging,

    private formBuilder: FormBuilder,
    private myBudget: BudgetService,
    private router:Router,
    private route:ActivatedRoute
  ) { }

  eventForm!: FormGroup;

  ngOnInit(): void {
    this.eventForm = new FormGroup({
      NameBudget: new FormControl("", [Validators.required, Validators.pattern("[א-ת-a-z-A-Z ]*")]),
      Type: new FormControl("", [Validators.required, Validators.pattern("[1-2 ]")]),
      Manager: new FormControl(this.log.ActiveUser.Id),
    });
  
  }

  AddBudget() {
    if (this.eventForm.value != undefined) {
      console.log("**שם תקציב**" + this.eventForm.value.NameBudget)

      this.myBudget.AddBudget(this.eventForm.value).subscribe(res1 => {
        console.log("curent Budget ======>", res1)
        this.newBudget = this.eventForm.value;
        alert(this.newBudget.NameBudget + " נוסף תקציב בכינוי");

        // this.log.ActiveUser = this.newBudget;
        this.newBudget = new Budget();
        this.router.navigate(['/ListBudgets']);
      })


    }
  }
}
