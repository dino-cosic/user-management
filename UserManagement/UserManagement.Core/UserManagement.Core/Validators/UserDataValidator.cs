using System.Text.RegularExpressions;
using UserManagement.Core.Exceptions;
using UserManagement.Models;

namespace UserManagement.Core.Validators
{
    public static class UserDataValidator
    {
        public static void ValidateUserData(User user)
        {
            // validate email address
            if (!Regex.IsMatch(user.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")) throw new BusinessDataValidationException(nameof(user.Email), user.Email);

            // validate first and last name
            if (!Regex.IsMatch(user.FirstName, @"^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$")) throw new BusinessDataValidationException(nameof(user.FirstName), user.FirstName);

            if (!Regex.IsMatch(user.LastName, @"^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$")) throw new BusinessDataValidationException(nameof(user.LastName), user.LastName);

            // validate password - 8 chars min, 1 uppercase at least, 1 lowercase, 1 number, can contain special chars
            if (!Regex.IsMatch(user.Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"))
                throw new BusinessDataValidationException(nameof(user.Password), user.Password,
                    "The password must have at least 8 characters, 1 uppercase and 1 lowercase letter. Symbols are allowed.");
        }
    }
}