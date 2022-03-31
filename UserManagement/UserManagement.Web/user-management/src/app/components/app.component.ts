import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  public response?: UserManagementResponse;

  constructor(http: HttpClient) {
    http
      .get<UserManagementResponse>(
        'https://localhost:44338/User?PageNumber=1&PageSize=5'
      )
      .subscribe(
        (result) => {
          this.response = result;
        },
        (error) => console.error(error)
      );
  }

  title = 'user-management';
}

interface UserManagementResponse {
  succes: boolean;
  errorMessage: string;
  data: any;
}

interface User {
  email: string;
  firstName: string;
  id: number;
  lastName: number;
  password: string;
  status: number;
  username: number;
}
