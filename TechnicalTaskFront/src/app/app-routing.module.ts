import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupsComponent } from './modules/groups/groups.component';
import { GroupPermissionsComponent } from './modules/permissions/group-permissions/group-permissions.component';

const routes: Routes = [
  {path : 'permissions' , component:GroupPermissionsComponent},
  {path : 'groups' , component:GroupsComponent},
  {path : '' , pathMatch:'full' , redirectTo:'permissions'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
