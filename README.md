# user-management

The goal is to create a User Management system that will allow us to:
- View a list of all available users.
- Edit existing user.
- Delete user.
- Create a new user.
- Assign permissions to the user
- View assigned permissions to the user


User needs to have a minimum of the following attributes:
- First name
- Last name
- Username
- Password
- Email
- Status

Minimum permission’s attributes are:
- Code
- Description

User stories that need to be covered are given below:
- Upon starting the application, the **User List** page should show up
- **User List** page should show a list of users.
- **User List** page should support pagination (10 users per page).
- **User List** page should support ordering by any of the a.m. minimum attributes
- **User List** page should support filtering by any of the a.m. minimum attributes.
- Every record on the **User List** page should have an Edit button. Clicking on the button should lead to
  the Edit User page.
- **Edit User** page should allow editing of the existing user. First name, Last name, email, status fields
  should be editable. The appropriate API method should be called on the Save button click event.
- Every record on the **User List** page should have a Delete button. Clicking on the button should display
  a modal asking the user, “Are you sure you want to delete this user”. When confirmed, the DELETE API
  endpoint should be called, and the user list updated accordingly.
- **Create User** page should allow creating a new user with min. set of attributes.
- Every record on the **User List** page should have an Assign button. Clicking on the button should lead
  to the Assign Permission page.
- **Assign Permission** page should allow to add or remove permissions for the selected user and call
  appropriate API
  
 Tech stack:
 ![image](https://user-images.githubusercontent.com/102690675/161164978-8b8ccfb4-404a-499f-b32a-5ddcefdf7078.png)
![image](https://user-images.githubusercontent.com/102690675/161165011-1ab56843-9754-4ca0-9ce4-17f5375de23f.png)
