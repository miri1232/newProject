import { Component, Input, OnInit } from '@angular/core';
//import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-action-dialog',
  templateUrl: './action-dialog.component.html',
  styleUrls: ['./action-dialog.component.scss']
})
export class ActionDialogComponent implements OnInit {

  @Input()
  content!:string;

  // constructor(public activeModal: NgbActiveModal) {
  //  }

  ngOnInit(): void {
  }

  // close(){
  //   this.activeModal.close();
  // }

}
