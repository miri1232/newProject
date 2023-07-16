import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { Permission } from 'src/app/Classes/Permission';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { MessageService } from 'src/app/Services/message.service';
import { PermissionService } from 'src/app/Services/permission.service';
import { Logging } from 'src/shared/log.service';
import { ActionDialogComponent } from '../action-dialog/action-dialog.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
  providers:[Logging]
})
export class NavComponent implements OnInit {

  public BudgetList: Budget[] | undefined;
  budgetExist: boolean = false;

  today: Date = new Date();

 public activeUser!: User;
 public activeBudget!: Budget ;
 public listPermission:Permission[] | undefined;

  constructor(
    private log: Logging,
    private router: Router,
    private route: ActivatedRoute,
    private myBudgetServise: BudgetService,
private permissionSer : PermissionService,
   private modalService: NgbModal,

  ) { }

  ngOnInit(): void {
    this.log.sharedActiveUser.subscribe(user => this.activeUser = user);
    this.log.sharedActiveBudget.subscribe(budget => this.activeBudget = budget);
  }


  logIn() {
    this.router.navigate(['/Login'])
  }

  logOut() {
    this.log.logOutUser();
  }

  toHomePage() {
    this.router.navigate([''])
  }

  GoBudget(b: Budget) {
    this.activeBudget = b;
    this.router.navigate(['/BudgetHomePage']);

  }

  ShowAllBudget() {
    this.myBudgetServise.GetBudgetByUser(this.activeUser).subscribe(budget => {
      this.BudgetList = budget;
      if (this.BudgetList.length > 0)
        this.budgetExist = true;
      console.log(this.BudgetList);
    });
  }

  ShowAllPermissionForBudget(){
    this.permissionSer.GetAllPermissionForBudget(this.activeBudget.id).subscribe(p => this.listPermission = p);
  console.log(this.listPermission);
  
  }



}
