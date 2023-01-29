export class Expense{
  
         id!: number;
         idBudget! : number;
         date !: Date;
         sum !: number;
         category! : number;
         subcategory! : number;
         detail! : string;
         paymentMethod! : number;
         frequency !: boolean;
         numberOfPayments !: number;
         status! : number;
         document ?: string;


         
        }