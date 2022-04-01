import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { UserPermissionsComponent } from './components/user-permissions/user-permissions.component';
import { UserTableComponent } from './components/user-table/user-table.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'user-management',
    pathMatch: 'full',
  },
  {
    path: 'user-management',
    component: UserTableComponent,
  },
  { path: 'edit-user/:userId', component: CreateUserComponent },
  { path: 'edit-permissions/:userId', component: UserPermissionsComponent },
  { path: 'add-new-user', component: CreateUserComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
