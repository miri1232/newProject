import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { TypeBudget } from 'src/app/Classes/TypeBudget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { LookupService } from 'src/app/Services/lookup.service';
import { Logging } from 'src/shared/log.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

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
    private lookupSer: LookupService,
    private modalService: NgbModal,

  ) { }

  eventForm!: FormGroup;

  
  ngOnInit(): void {
    this.lookupSer.GetAllTypeBudget().subscribe(res => {
      this.listTypeBudget = res;
      console.log(this.listTypeBudget);
    });

    this.eventForm = new FormGroup({
      nameBudget: new FormControl("", [Validators.required, Validators.pattern("")]),
      manager: new FormControl(this.log.ActiveUser.id),
      typeBudget: new FormControl(""),
    });  
  }


  
  AddBudget() {

      if (this.eventForm.value != undefined) {
          console.log("**שם תקציב**" + this.eventForm.value.nameBudget)

          this.newBudget.id = 0;

          this.newBudget.type = this.eventForm.value.typeBudget;
          this.newBudget.manager = "0000";
          this.newBudget.nameBudget = this.eventForm.value.nameBudget;


          this.myBudget.AddBudget(this.newBudget).subscribe(res1 => {
              console.log("curent Budget ======>", res1)
              this.newBudget = this.eventForm.value;
              const modalRef = this.modalService.open(ActionDialogComponent);
              modalRef.componentInstance.content = this.newBudget.nameBudget + " נוסף תקציב בכינוי";
              this.newBudget = new Budget();
              this.router.navigate(['/BudgetHomePage']);
          })
      }

  }


}



