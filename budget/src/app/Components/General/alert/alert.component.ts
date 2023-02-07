import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss']
})
export class AlertComponent implements OnInit {
isModal:boolean=false;
  modal!:string;
title!:string;
notifications!:string;
accept !:string;
cancel !:string;
isCancel :boolean=false;

  constructor() { }

  ngOnInit(): void {
  }

AddAlert(m:string, t:string, n:string,  a :string, isC:boolean, c:string ){
  this.modal=m;
    this.title=  t;
    this.notifications=n ;
    this.accept= a;
    this.isCancel = isC;
    this.cancel =c ;

}

AddAlert1(t:string, n:string ){
  this.title=  t;
  this.notifications=n ;
  this.accept= "אישור";
  this.isCancel = false;
  this.cancel ="" ;
}

AddAlert2(t:string, n:string ){
  this.title=  t;
  this.notifications=n ;
  this.accept= "אישור";
  this.isCancel = true;
  this.cancel ="ביטול" ;
}


}
