namespace SharedTrip.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using SharedTrip.Models.Users;
    using SharedTrip.Data;

    using static Data.DataConstants;
    using System.Text.RegularExpressions;
    using SharedTrip.Models.Trips;
    using System.Net;
    using System.Globalization;
    using System;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(AddTripForm model)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(model.StartPoint) || model.StartPoint.Contains(" "))
            {
                errors.Add("Start point cannot be empty");
            }

            if (string.IsNullOrEmpty(model.EndPoint) || model.EndPoint.Contains(" "))
            {
                errors.Add("End point cannot be empty");
            }

            if(model.Seats<SeatsMinCount || model.Seats>SeatsMaxCount)
            {
                errors.Add($"The provided seats are not valid. They must be between {UserMinPassword} and {DefaultMaxLength}.");
            }

            if (DateTime.TryParse(model.DepartureTime, out var date)==false)
            {
                errors.Add($"Date of trim is not a valid");
            }

            //if (IsImageUrl(model.ImagePath) == false)
            //{
            //    errors.Add($"The provided image URL iS not valid.");

            //}
            return errors;
        }

        public ICollection<string> ValidateUser(RegisterViewForm model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        private bool IsImageUrl(string URL)
        {
            var req = (HttpWebRequest)HttpWebRequest.Create(URL);
            req.Method = "HEAD";
            using (var resp = req.GetResponse())
            {
                return resp.ContentType.ToLower(CultureInfo.InvariantCulture)
                           .StartsWith("image/");
            }
        }
    }
}
