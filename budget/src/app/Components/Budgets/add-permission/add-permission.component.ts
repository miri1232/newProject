import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Permission } from 'src/app/Classes/Permission';
import { PermissionLevel } from 'src/app/Classes/PermissionLevel';
import { LookupService } from 'src/app/Services/lookup.service';
import { PermissionService } from 'src/app/Services/permission.service';
import { UserService } from 'src/app/Services/user.service';
import { Logging } from 'src/shared/log.service';

@Component({
  selector: 'app-add-permission',
  templateUrl: './add-permission.component.html',
  styleUrls: ['./add-permission.component.scss']
})
export class AddPermissionComponent implements OnInit {

  IdUserToPermission !: string;
  IdPermissionLevel !: number;
  newPermission : Permission = new Permission();

  
  //עבור יבוא מערכים לנתוני תיבה נפתחת
  public listPermissionLevel: PermissionLevel[] | undefined;

  constructor(
    private log: Logging,
    private router: Router,
    private route: ActivatedRoute,
    private lookupSer: LookupService,
    private PermissionSer : PermissionService,
    private userService: UserService,

  ) { }

  ngOnInit(): void {
    this.lookupSer.GetAllPermissionLevel().subscribe(res => {
      this.listPermissionLevel = res;
      console.log(this.listPermissionLevel);
    });
  }

// this.newPermission.id=undefined;
// this.newPermission.idUser=this.IdUserToPermission.value;
// this.newPermission.idBudget=this.log.ActiveBudget.id;
// this.newPermission.permissionLevel=this.IdPermissionLevel;


//   AddPermission(){
//         this.userService.GetUserByID(this.IdUserToPermission).subscribe(res1 => {
//           if(res1!=undefined) {
//     this.PermissionSer.AddPermission(this.newPermission).subscribe(res =>{
//       if(res){
// alert(this.res1.firstName + " נוסף לרשימת מורשי הכניסה לתקציב")
//       }
//     });
//     } 
//     else{
//      alert( "על המשתמש להרשם במערכת לצורך האפשרות לקבלת הרשאת גישה")
//     }
//         });
//       }

 





//סוגריים סופיות
}
