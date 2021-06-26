namespace GitWebApp.Services
{
    using System.Collections.Generic;
    using GitWebApp.Models;

   public interface IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserModel model);
    }
}
