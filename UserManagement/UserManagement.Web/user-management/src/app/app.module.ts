import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app.component';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { UserTableComponent } from './components/user-table/user-table.component';

@NgModule({
  declarations: [AppComponent, UserTableComponent, CreateUserComponent],
  imports: [BrowserModule, HttpClientModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
