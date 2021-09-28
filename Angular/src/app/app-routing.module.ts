import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ContractorComponent } from './contractor/contractor.component';
import { DepartmentComponent } from './department/department.component';

const routes: Routes = [
  {path:'contractor',component:ContractorComponent},
  {path:'department',component:DepartmentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
