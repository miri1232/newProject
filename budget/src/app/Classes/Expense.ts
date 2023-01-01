export class Expense{
  
    constructor(
        public  Id: number,
        public  IdBudget : number,
        public  Date : Date,
        public  Sum : number,
        public  Category : string,
        public  Subcategory : string,
        public  Detail : string,
        public  PaymentMethod : string,
        public  Frequency : boolean,
        public  NumberOfPayments : number,
        public  Status : string,
        public  Document : string


         
            ) {
     
        
            }
        }