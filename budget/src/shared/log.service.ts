import { Injectable } from "@angular/core";
import { Budget } from "src/app/Classes/Budget";
import { User } from "src/app/Classes/User";

//סרוויס על ששומר בתוכו את פרטי המשתמש לצורך העברת המידע לקומפוננטות הפנימיות
@Injectable({
  providedIn: 'root',
})
export class Logging{

    ActiveUser: User=new User();
    ActiveBudget:Budget=new Budget();
  
    constructor() { }
  }
