export class Expense{
  
    constructor(
        public  Id: number,
        public  IdBudget : number,
        public  Date : Date,
        public  Sum : number,
        public  Category : number,
        public  Subcategory : number,
        public  Detail : string,
        public  PaymentMethod : number,
        public  Frequency : boolean,
        public  NumberOfPayments : number,
        public  Status : number,
        public  Document : string


         
            ) {
     
        
            }
        }