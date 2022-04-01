import { HttpResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { UserManagementResponse } from '../models/userManagementResponse.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  public response?: HttpResponse<UserManagementResponse>;

  constructor(private userService: UserService) {
    this.userService
      .getUsers(
        this.userService.pagingData.currentPage,
        this.userService.pagingData.pageSize
      )
      .subscribe(
        (result) => {
          console.log('Response' + result);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  title = 'user-management';
}
