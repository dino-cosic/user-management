import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './components/app.component';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { UserTableComponent } from './components/user-table/user-table.component';
import { UserPermissionsComponent } from './components/user-permissions/user-permissions.component';

@NgModule({
  declarations: [AppComponent, UserTableComponent, CreateUserComponent, UserPermissionsComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
