import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Permission } from 'src/app/Classes/Permission';
import { PermissionLevel } from 'src/app/Classes/PermissionLevel';
import { LookupService } from 'src/app/Services/lookup.service';
import { PermissionService } from 'src/app/Services/permission.service';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActionDialogComponent } from '../../General/action-dialog/action-dialog.component';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-add-permission',
  templateUrl: './add-permission.component.html',
  styleUrls: ['./add-permission.component.scss']
})
export class AddPermissionComponent implements OnInit {

  newPermission: Permission = new Permission();
  public listPermission: Permission[] | undefined;
  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listPermissionLevel: PermissionLevel[] | undefined;

  constructor(
    public activeModal: NgbActiveModal,
    private log: Logging,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService,
    private PermissionSer: PermissionService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,

  ) { }

  eventForm!: FormGroup;

  // IdUserToPermission !: string;
  // IdPermissionLevel !: number;



  ngOnInit(): void {
    //יבוא נתונים עבור רשימה נפתחת
    this.lookupSer.GetAllPermissionLevel().subscribe(res => {
      this.listPermissionLevel = res;
      console.log(this.listPermissionLevel);
    });


    //הקמת הטופס
    this.eventForm = new FormGroup({
      id: new FormControl(0),
      idUser: new FormControl(""),
      idBudget: new FormControl(5),
      permissionLevel: new FormControl(""),
    });

  }

  // this.newPermission.id=0;
  // this.newPermission.idUser=this.IdUserToPermission.value;
  // this.newPermission.idBudget=this.log.ActiveBudget.id;
  // this.newPermission.permissionLevel=this.IdPermissionLevel;


  AddPermission() {

    if (this.eventForm.value != undefined) {
      console.log("**פרטים**" + this.eventForm.value)

      // this.PermissionSer.GetAllPermissionForBudget(5).subscribe(res => {
      //   this.listPermission=res;
      //   this.listPermission.forEach(element => {
      //     if(element.idUser==this.eventForm.value.idUser){
      //     const modalRef = this.modalService.open(ActionDialogComponent);
      //     modalRef.componentInstance.content = "למשתמש קיימת כבר הרשאה בתקציב זה";
      //     this.activeModal.close();

      //     }

      //   })
      // });

      // this.PermissionSer.GetAllPermissionForBudget(5).subscribe(res => {
      //   this.listPermission=res;
      //   if(this.listPermission!=undefined){
      //   for(let p in this.listPermission){
      //      if(p.idUser==this.eventForm.value.idUser){
      //     const modalRef = this.modalService.open(ActionDialogComponent);
      //     modalRef.componentInstance.content = "למשתמש קיימת כבר הרשאה בתקציב זה";
      //     this.activeModal.close();
      //   }


      //     }
      //  }
      //   })

      this.userService.GetUserByID(this.eventForm.value.idUser).subscribe(res1 => {
        if (res1 != undefined) {
          this.newPermission = this.eventForm.value;


          this.PermissionSer.AddPermission(this.eventForm.value).subscribe(res => {
            if (res) {
              const modalRef = this.modalService.open(ActionDialogComponent);
              modalRef.componentInstance.content = "למשתמש נוספה הרשאה לתקציב";
              this.activeModal.close();
              this.eventForm.value.idUser
            }
            else {
              const modalRef = this.modalService.open(ActionDialogComponent);
              modalRef.componentInstance.content = "למשתמש קיימת כבר הרשאה בתקציב זה";
            }
          });
        }
        else {
          const modalRef = this.modalService.open(ActionDialogComponent);
          modalRef.componentInstance.content = "על המשתמש להרשם במערכת לצורך האפשרות לקבלת הרשאת גישה";
          this.activeModal.close();

        }
      });
    }
  }








  //סוגריים סופיות
}
