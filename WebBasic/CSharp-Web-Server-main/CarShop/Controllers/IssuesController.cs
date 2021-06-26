namespace CarShop.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Issues;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly CarShopDbContext data;

        public IssuesController(IUserService userService, CarShopDbContext data)
        {
            this.userService = userService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!this.userService.IsMechanic(this.User.Id))
            {
                var userOwnsCar = this.data.Cars
                    .Any(c => c.Id == carId && c.OwnerId == this.User.Id);

                if (!userOwnsCar)
                {
                    return Error("You do not have access to this car.");
                }
            }

            var carWithIssues = this.data
                .Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Issues = c.Issues.Select(i => new IssueListingViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed
                    })
                })
                .FirstOrDefault();

            if (carWithIssues == null)
            {
                return Error("You do not have access to this car.");
            }

            return View(carWithIssues);
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issue = this.data.Issues.First(x => x.Id == issueId);
            this.data.Remove(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?CarId={carId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId,string carId)
        {
 
            if (!this.userService.IsMechanic(this.User.Id))
            {
                return Error("You can not apply fix to the car.");
            }

            var issue = this.data.Issues.First(x => x.Id == issueId);
            this.data.Remove(issue);

            issue.IsFixed = true;
            var issueFix = new Issue
            {
                CarId = issue.CarId,
                IsFixed = true,
                Description = issue.Description
            };

            this.data.Issues.Add(issueFix);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?CarId={carId}");

        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            var model = new AddIssueViewModel
            {
                CarId = carId
            };
            return View(model); 
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddIssueViewModel model)
        {
            
            var issue = new Issue
            {
                CarId = model.CarId,
                Description = model.Description,
            };

            this.data.Issues.Add(issue);

            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?CarId={model.CarId}");
        }
    }
}
