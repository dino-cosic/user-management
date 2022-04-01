import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { MustMatch } from 'src/app/validators/mustMatch.validator';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css'],
})
export class CreateUserComponent implements OnInit {
  userForm: FormGroup;
  submitted = false;
  isEdit = false;
  editUserId: number = 0;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.userForm = this.formBuilder.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        username: ['', [Validators.required, Validators.minLength(5)]],
        password: [
          '',
          [
            Validators.required,
            Validators.pattern(
              /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/
            ),
          ],
        ],
        confirmPassword: ['', Validators.required],
      },
      {
        validator: MustMatch('password', 'confirmPassword'),
      }
    );

    if (this.isEdit && this.editUserId > 0) {
      this.userService.getUserById(this.editUserId).subscribe(
        (res) => {
          const { firstName, lastName, email, username, password } = res.data;

          this.userForm.patchValue({
            firstName,
            lastName,
            email,
            username,
            password,
            confirmPassword: password,
          });
        },
        (err) => {}
      );
    }
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.userForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.userForm.invalid) {
      return;
    }

    let user = new User(this.userForm.value);

    if (!this.isEdit && this.editUserId === 0) {
      this.callCreate(user);
    } else {
      this.callUpdate(user);
    }

    this.onReset();
  }

  callCreate(user: User) {
    this.userService.createUser(user).subscribe(
      (res) => {
        this.toastr.success(
          'The user was created successfully.',
          'User Created'
        );
      },
      (err) => {
        console.log(err);
      }
    );
  }

  callUpdate(user: User) {
    user.id = this.editUserId;

    this.userService.updateUser(user).subscribe(
      (res) => {
        this.toastr.success(
          'The user data was updated successfully.',
          'User Updated'
        );
      },
      (err) => {
        console.log(err);
      }
    );
  }

  onReset() {
    this.submitted = false;
    this.userForm.reset();
  }
}
