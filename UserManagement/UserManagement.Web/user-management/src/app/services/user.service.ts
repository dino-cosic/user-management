import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { PagingData } from '../models/pagingData.model';
import { User } from '../models/user.model';
import { UserManagementResponse } from '../models/userManagementResponse.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  apiURL: string = 'https://localhost:44338';

  pagingData = {} as PagingData;

  constructor(private httpClient: HttpClient) {}

  public createUser(user: User) {
    return this.httpClient.post(`${this.apiURL}/User/`, user);
  }

  public updateUser(user: User) {
    return this.httpClient.put(`${this.apiURL}/User/`, user);
  }

  public deleteUser(id: number) {
    return this.httpClient.delete(`${this.apiURL}/User/${id}`);
  }

  public getUserById(id: number) {
    return this.httpClient.get(`${this.apiURL}/User/${id}`);
  }

  public getUsers(pageNumber?: number, pageSize?: number) {
    if (pageNumber && pageSize) {
      return this.httpClient
        .get<UserManagementResponse>(
          `${this.apiURL}/User?PageNumber${pageNumber}&PageSize${pageSize}`,
          { observe: 'response' }
        )
        .pipe(
          tap((res) => {
            this.retrieveRaginationData(res);
          })
        );
    }

    return this.httpClient
      .get<UserManagementResponse>(
        `${this.apiURL}/User?PageNumber1&PageSize=10`,
        { observe: 'response' }
      )
      .pipe(
        tap((res) => {
          this.retrieveRaginationData(res);
        })
      );
  }

  retrieveRaginationData(response) {
    const linkHeader = response.headers.get('x-pagination');
    this.pagingData = JSON.parse(linkHeader);
  }
}
