import { User } from "src/app/Classes/User";

//סרוויס על ששומר בתוכו את פרטי המשתמש לצורך העברת המידע לקומפוננטות הפנימיות

export class Logging{


    ActiveUser: User=new User();
  
    constructor() { }
  }
