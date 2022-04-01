import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RemovePermissionRequest } from '../models/remove-permission-request.model';
import { UpdatePermission } from '../models/updatePermission.model';
import { UserManagementResponse } from '../models/userManagementResponse.model';

@Injectable({
  providedIn: 'root',
})
export class PermissionService {
  apiURL: string = 'https://localhost:44338';

  constructor(private httpClient: HttpClient) {}

  public getAllPermissions(): Observable<UserManagementResponse> {
    return this.httpClient.get<UserManagementResponse>(
      `${this.apiURL}/Permission`
    );
  }

  public getUserPermissions(
    userId: number
  ): Observable<UserManagementResponse> {
    return this.httpClient.get<UserManagementResponse>(
      `${this.apiURL}/Permission/User/${userId}`
    );
  }

  public assignPermissionToUser(updatePermission: UpdatePermission) {
    return this.httpClient.post(
      `${this.apiURL}/Permission/AssignToUser`,
      updatePermission
    );
  }

  public removePerimssionFromUser(updatePermission: RemovePermissionRequest) {
    return this.httpClient.put(
      `${this.apiURL}/Permission/RemoveFromUser`,
      updatePermission
    );
  }
}
