namespace GitWebApp.Services
{

    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using GitWebApp.Models;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > UserMaxUsername)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {UserMaxUsername} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > UserMaxPassword)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {UserMaxPassword} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
