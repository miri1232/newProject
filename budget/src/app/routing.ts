import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';



const appRouting:Routes=[
    {path:"",component:'HomePageComponent'}


];


@NgModule({
    imports: [RouterModule.forRoot(appRouting), 
      CommonModule
    ],
    exports: [RouterModule]
  })
  
  export class AppRoutingModule {
  
  
  
   }