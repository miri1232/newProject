
export class Search {

    idBudget!: number;
    dateEnd: Date=new Date();
    dateStart: Date=new Date();
    sumMin: number = 0;
    sumMax: number = 9999999;
    category: number = 0;
    subcategory: number = 0;
    status: number = 0;
    
    constructor() {
        // this.dateEnd = new Date();
        // this.dateStart = new Date();
        // this.dateStart.setDate(this.dateStart.getDay() - 30);
    }


}