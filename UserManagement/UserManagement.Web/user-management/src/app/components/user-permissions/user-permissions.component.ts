import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Permission } from 'src/app/models/permission.model';
import { PermissionService } from 'src/app/services/permission.service';

@Component({
  selector: 'app-user-permissions',
  templateUrl: './user-permissions.component.html',
  styleUrls: ['./user-permissions.component.css'],
})
export class UserPermissionsComponent implements OnInit {
  configuredPermissions: Permission[];

  constructor(
    private permissionService: PermissionService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.permissionService.getAllPermissions().subscribe(
      (res) => {
        this.configuredPermissions = res.data;
      },
      (err) => {
        this.toastr.warning(
          'Could not retrieve configured permissions from database.',
          'Warning'
        );
      }
    );
  }
}
