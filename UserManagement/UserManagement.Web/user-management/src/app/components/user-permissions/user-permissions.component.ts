import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Permission } from 'src/app/models/permission.model';
import { RemovePermissionRequest } from 'src/app/models/remove-permission-request.model';
import { UpdatePermission } from 'src/app/models/updatePermission.model';
import { PermissionService } from 'src/app/services/permission.service';

@Component({
  selector: 'app-user-permissions',
  templateUrl: './user-permissions.component.html',
  styleUrls: ['./user-permissions.component.css'],
})
export class UserPermissionsComponent implements OnInit {
  configuredPermissions: Permission[];
  userPermissions: Permission[];
  userId: number;
  isButtonDisabled: boolean;

  constructor(
    private permissionService: PermissionService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {
    this.route.paramMap.subscribe(
      (paramMap) => (this.userId = Number(paramMap.get('userId')))
    );
  }

  ngOnInit(): void {
    this.isButtonDisabled = true;
    let allPermissons = [];
    this.permissionService.getUserPermissions(this.userId).subscribe(
      (res) => {
        this.userPermissions = res.data;
        this.permissionService.getAllPermissions().subscribe(
          (res) => {
            allPermissons = res.data;
            this.userPermissions.forEach((element) => {
              allPermissons = allPermissons.filter((p) => p.id !== element.id);
            });
            this.configuredPermissions = allPermissons;
          },
          (err) => {
            this.toastr.warning(
              'Could not retrieve configured permissions from database.',
              'Warning'
            );
          }
        );
      },
      (err) => {
        this.toastr.warning(
          'Could not retrieve configured permissions from database.',
          'Warning'
        );
      }
    );
  }

  applyPermissions() {
    let checkboxs = document.querySelectorAll('input[type="checkbox"]:checked');
    if (checkboxs.length) {
      let selectedValues = Array.from(checkboxs).map((x) => Number(x.id));
      let updatePermissionRequest: UpdatePermission = {
        permissionIds: selectedValues,
        userId: this.userId,
      };
      this.permissionService
        .assignPermissionToUser(updatePermissionRequest)
        .subscribe(
          (res) => {
            this.toastr.success(
              'The permission was added successfully.',
              'Permission Added'
            );
            this.ngOnInit();
          },
          (err) => {
            this.toastr.warning(
              'Unable to assign permissions to the user',
              'Warning'
            );
          }
        );
    }
  }
  checked() {
    let checkboxes = document.querySelectorAll(
      'input[type="checkbox"]:checked'
    );
    this.isButtonDisabled = checkboxes.length == 0;
  }

  deletePermission(id: number) {
    let removePermission: RemovePermissionRequest = {
      permissionId: id,
      userId: this.userId,
    };
    this.permissionService.removePerimssionFromUser(removePermission).subscribe(
      (res) => {
        this.toastr.success(
          'The permission was deleted successfully.',
          'Permission Deleted'
        );
        this.ngOnInit();
      },
      (err) => {
        this.toastr.warning('Permission was not deleted.', 'Warning');
      }
    );
  }
}
