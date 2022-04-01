import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDialogService } from 'ngx-modal-dialog';
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
    private modalService: ModalDialogService,
    private viewRef: ViewContainerRef,
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
      (err) => {}
    );
  }

  openModal(id: number) {
    this.modalService.openDialog(this.viewRef, {
      title: 'Warning',
      data: id,
      onClose: () => this.deleteUser(id),
      childComponent: ConfirmationModalComponent,
    });
  }

  deleteUser(id: number): boolean {
    this.userService.deleteUser(id).subscribe(
      (res) => {
        this.toastr.success(
          'The user was deleted successfully.',
          'User Deleted'
        );
      },
      (err) => {
        this.toastr.warning('User was not deleted.', 'Warning');
      }
    );
    return true;
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
        (err) => {}
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
        (err) => {}
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
