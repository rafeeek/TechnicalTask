import { Component, OnInit } from '@angular/core';
import { GroupsData } from 'src/app/data/models/groups';
import { PermissionsService } from 'src/app/data/service/permissions.service';
import {MessageService} from 'primeng/api';

@Component({
  selector: 'app-group-permissions',
  templateUrl: './group-permissions.component.html',
  styleUrls: ['./group-permissions.component.scss']
})
export class GroupPermissionsComponent implements OnInit {
  groups : GroupsData | any ;
  selectedGroup:any;
  pagePermissionsTableData : any[]= [];
  selectedValues: string[] = [];
  veiwAllPages : boolean = true;

  groupModeldisplay:boolean = false;
  dataToSave:any;
  permissionFormData:any;

  constructor(private permissionsService:PermissionsService, private ms: MessageService) { }

  ngOnInit() {
    this.setAllGroups();
    this.getPagePermissions();
  }

  // Get all groups to print dropdown/
  setAllGroups() {
    this.permissionsService.getGroups().subscribe(res =>{
      this.groups = res.data;
    });
  };

  getPagePermissions(){
    this.permissionsService.getAllPages().subscribe(res =>{
      this.pagePermissionsTableData = res.data;
    });
  }

  //get permission for selected group in the list
  groupChange(){
    this.getPermissionForSelectedGroup(this.selectedGroup.id);
  }

  //when group is cleard i will remove all permission and bak to defult page permission empty
  groupClear(){
    this.getPagePermissions();
    this.veiwAllPages = true;
  }

  //get permission for selected group in the list
  getPermissionForSelectedGroup(groupId:number){
	this.permissionsService.PermissionForSelectedGroup(groupId).subscribe(res =>{
    this.veiwAllPages = false;
		this.pagePermissionsTableData = res.data;
	  });
  }

  //if group have old permission than permission id will be number if not i will add new one;
  savePermissions(){
    this.pagePermissionsTableData.forEach(data =>{
        if(data.id == null){
          this.permissionsService.addGroupPermission(data).subscribe(res=>{
          });
        }else{
          this.permissionsService.updateGroupPermission(data).subscribe(res=>{
          });
        }
    });
    this.ms.add({severity:'success', summary: 'Success', detail: 'Add & Update Items Successfully'});
  }

  groupAdd(ev:any){
    this.groupModeldisplay = false;
    this.ms.add({severity:'success', summary: 'Success', detail: `${ev}`});
    this.setAllGroups();
  }

}


