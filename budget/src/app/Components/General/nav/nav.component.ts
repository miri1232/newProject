import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Budget } from 'src/app/Classes/Budget';
import { User } from 'src/app/Classes/User';
import { BudgetService } from 'src/app/Services/budget.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  public BudgetList :Budget[] | undefined;

  constructor(
    private log:Logging,
    private router:Router,
    private route:ActivatedRoute,
    private myBudgetServise: BudgetService ,

  ) { }

  ngOnInit(): void {
  }

today: Date=new Date();

  activeUser: User = this.log.ActiveUser;

  logIn(){
    this.router.navigate(['/Login'])
    }

    logOut(){
      this.log.logOutUser();
    }

    toHomePage(){
      this.router.navigate([''])
  
  }

  GoBudget(b:Budget){
    this.router.navigate(['/BudgetHomePage',b.id]);

  }

  listBudget1(){
      this.myBudgetServise.GetBudgetByUser().subscribe(budget => { 
        this.BudgetList=budget;
        console.log(this.BudgetList);
 
      });
  }
}
