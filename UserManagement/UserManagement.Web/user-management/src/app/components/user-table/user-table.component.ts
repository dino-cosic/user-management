import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Status } from 'src/app/models/enums/status.enum';
import { PagingData } from 'src/app/models/pagingData.model';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { ConfirmationModalComponent } from '../confirmation-modal/confirmation-modal.component';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.css'],
})
export class UserTableComponent implements OnInit {
  constructor(
    private router: Router,
    private userService: UserService,
    private modalService: NgbModal,
    private toastr: ToastrService
  ) {}

  users: User[];
  status = Status;
  pagingData: PagingData;

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      (res) => {
        this.users = res.body.data;
        this.pagingData = this.userService.pagingData;
      },
      (err) => {
        this.toastr.warning('Could not retrieve users.', 'Warning');
      }
    );
  }

  openModal(id: number) {
    this.modalService.open(ConfirmationModalComponent).result.then((result) => {
      if (result === 'save') {
        this.userService.deleteUser(id).subscribe(
          (res) => {
            this.toastr.success(
              'The user was deleted successfully.',
              'User Deleted'
            );
            this.ngOnInit();
          },
          (err) => {
            this.toastr.warning('User was not deleted.', 'Warning');
          }
        );
      } else {
        this.modalService.dismissAll();
      }
    });
  }

  onNextClick() {
    if (!this.pagingData.HasNext) return;
    this.userService
      .getUsers(this.pagingData.CurrentPage + 1, this.pagingData.PageSize)
      .subscribe(
        (res) => {
          this.users = res.body.data;
          this.pagingData = this.userService.pagingData;
        },
        (err) => {
          this.toastr.warning('Could not retrieve users.', 'Warning');
        }
      );
  }

  onPreviousClick() {
    if (!this.pagingData.HasPrevious) return;
    this.userService
      .getUsers(this.pagingData.CurrentPage - 1, this.pagingData.PageSize)
      .subscribe(
        (res) => {
          this.users = res.body.data;
          this.pagingData = this.userService.pagingData;
        },
        (err) => {
          this.toastr.warning('Could not retrieve users.', 'Warning');
        }
      );
  }

  navigateToEditUser(id: number) {
    this.router.navigate(['/edit-user', id]);
  }

  navigateToEditPermissions(id: number) {
    this.router.navigate(['/edit-permissions', id]);
  }

  navigateToAddNewUser() {
    this.router.navigate(['/add-new-user']);
  }
}
