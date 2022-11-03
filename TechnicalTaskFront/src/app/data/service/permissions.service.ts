import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Groups } from '../models/groups';

@Injectable({
  providedIn: 'root'
})
export class PermissionsService {

constructor(private http: HttpClient) { }
  getGroups():Observable<Groups>{
    return this.http.get<any>(environment.serverUrl + "/api/Group/GroupGetList");
  }

  getPagePermissions():Observable<any>{
    return this.http.get<any>(environment.serverUrl + "/api/GroupPermission/GroupPermissionGetAll");
  }

  getAllPages():Observable<any>{
    return this.http.get<any>(environment.serverUrl + "/api/Pages/PagesGetList");
  }

  PermissionForSelectedGroup(groupId:number):Observable<any>{
    return this.http.get<any>(environment.serverUrl + `/api/GroupPermission/GroupPermissionGetAll/${groupId}`);
  }

  addGroupPermission(data:any):Observable<any>{
    return this.http.post<any>(environment.serverUrl + `/api/GroupPermission/GroupPermissionAdd`, data);
  }

  updateGroupPermission(data:any):Observable<any>{
    console.log(data)
    return this.http.put<any>(environment.serverUrl + `/api/GroupPermission/GroupPermissionUpdate`, data);
  }

}
