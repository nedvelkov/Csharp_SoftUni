using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.OrderBy(x => x.EmployeeId)

                .Select(y => new
                {
                    y.FirstName,
                    y.LastName,
                    y.MiddleName,
                    JobTitle = y.JobTitle,
                    Salary = $"{y.Salary:f2}"
                })
                .ToList();
            //.Take(10);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                List<string> valuesEmployee = new List<string>();
                foreach (var prop in employee.GetType().GetProperties())
                {
                    var type = prop.PropertyType.Name;
                    var value = prop.GetValue(employee);
                    if (value == null)
                    {
                        continue;
                    }
                    valuesEmployee.Add(value.ToString());
                }
                sb.AppendLine(string.Join(" ", valuesEmployee));
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Where(s => s.Salary > 50000)
                .OrderBy(x => x.FirstName)
                                .Select(y => new
                                {
                                    y.FirstName,
                                    Salary = $"{y.Salary:f2}"
                                })
                .ToList();
            //.Take(10);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                List<string> valuesEmployee = new List<string>();
                foreach (var prop in employee.GetType().GetProperties())
                {
                    var type = prop.PropertyType.Name;
                    var value = prop.GetValue(employee);
                    if (value == null)
                    {
                        continue;
                    }
                    valuesEmployee.Add(value.ToString());
                }
                sb.AppendLine(string.Join(" - ", valuesEmployee));
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(d => d.Department.Name == "Research and Development")
                .OrderBy(s => s.Salary)
                .ThenByDescending(f => f.FirstName)
                                .Select(y => new
                                {
                                    y.FirstName,
                                    y.LastName,
                                    y.Department.Name,
                                    Salary = $"- ${y.Salary:f2}"
                                })
                .ToList();
            //.Take(10);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                List<string> valuesEmployee = new List<string>();
                foreach (var prop in employee.GetType().GetProperties())
                {
                    var type = prop.PropertyType.Name;
                    var value = prop.GetValue(employee);
                    if (value == null)
                    {
                        continue;
                    }
                    valuesEmployee.Add(value.ToString());
                }
                sb.AppendLine(string.Join(" ", valuesEmployee));
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddres = new Address();
            newAddres.AddressText = "Vitoshka 15";
            newAddres.TownId = 4;
            var employee = context.Employees.FirstOrDefault(l => l.LastName == "Nakov");
            employee.Address = newAddres;
            context.SaveChanges();
            var employeesAdrres = context.Employees
                .OrderByDescending(a => a.AddressId)
                .Select(t => t.Address.AddressText)
                /*
                .Select(t => new
                {
                    t.FirstName,
                    t.LastName,
                    t.Address.AddressText
                })
                */
                .ToList()
                .Take(10);

            return string.Join(Environment.NewLine, employeesAdrres);
        }


        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x=> x.EmployeesProjects)
                .ThenInclude(x=>x.Project)
                .Where(p => p.EmployeesProjects
                            .Any(d => d.Project.StartDate.Year >= 2001 && d.Project.StartDate.Year <= 2003))
                .Select( x=> new 
                {
                x.FirstName,
                x.LastName,
                ManagerFirstName=x.Manager.FirstName,
                MamagerLastName=x.Manager.LastName,
                Projects = x.EmployeesProjects.Select( p=> new
                {
                   ProjectName= p.Project.Name,
                    p.Project.StartDate,
                    p.Project.EndDate
                }

                    )
                })
                .ToList()
                .Take(10);
                var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.MamagerLastName}");
                foreach (var project in employee.Projects)
                {
                    var endDate = project.EndDate.HasValue ?
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture) :
                        "not finished";
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDate}");
                }
              //  Console.WriteLine(sb.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(x => x.Employees)
                .Where(e => e.Employees.Count > 5)
                .OrderBy(c => c.Employees.Count)
                .ThenBy(n => n.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    EmployeesList = x.Employees
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a =>
                    new
                    {
                        EmployeeFirstName = a.FirstName,
                        EmployeeLastName = a.LastName,
                        EmployeJobTitle = a.JobTitle
                    })
                })
            .ToList();
            var sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.EmployeesList)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeJobTitle}");
                }
               // Console.WriteLine(sb.ToString());
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(d => d.StartDate)
                .Take(10)
                .OrderBy(n => n.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
              //  Console.WriteLine(sb.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(n => n.FirstName.StartsWith("Sa"))
                .OrderBy(f => f.FirstName)
                .ThenBy(l => l.LastName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($@"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employees = context.EmployeesProjects
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .Where(x => x.Employee.EmployeesProjects.Any(p => p.ProjectId == 2))
                .ToList();


           

            return null;    
        }
    }
}
