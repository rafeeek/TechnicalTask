import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PermissionsService } from './service/permissions.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { GroupsService } from './service/groups.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  declarations: [],
  providers: [
    PermissionsService,
    HttpClient,
    GroupsService
  ]
})
export class DataModule { }
