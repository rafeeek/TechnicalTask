import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GroupsService {
constructor(private http: HttpClient) { }

addGroup(data:any):Observable<any>{
  return this.http.post<any>(environment.serverUrl + `/api/Group`, data);
}

}
