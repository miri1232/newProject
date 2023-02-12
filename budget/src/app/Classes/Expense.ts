export class Expense{
  
         id!: number;
         idBudget! : number;
         date !: Date;
         sum !: number;
         category! : number;
         categoryDetail!:string
         subcategory! : number;
         subcategoryDetail!:string;
         detail! : string;
         paymentMethod! : number;
         paymentMethodDetail!:string;
         frequency !: boolean;
        // numberOfPayments !: number;
         status! : number;
         statusDetail!:string;
         document ?: string;


         
        }