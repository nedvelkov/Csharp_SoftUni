namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var projectsFromXml = XmlConverter
                .Deserializer<ProjectInputXml>(xmlString, "Projects");
            var projects = new List<Project>();
            foreach (var projectDto in projectsFromXml)
            {
                if (IsValid(projectDto) == false)
                {

                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validDueDate = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);
                var openProjectDate = DateTime.ParseExact(projectDto.OpenDate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openProjectDate,
                    DueDate = validDueDate ? (DateTime?)dueDate : null
                };
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (IsValid(taskDto) == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var openTaskDate = DateTime.ParseExact(taskDto.OpenDate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var dueTaskDate = DateTime.ParseExact(taskDto.DueDate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if(openTaskDate<openProjectDate )
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (validDueDate && dueTaskDate > dueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = openTaskDate,
                        DueDate = dueTaskDate,
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType)

                    };
                    project.Tasks.Add(task);
                }
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
                projects.Add(project);
            }
            context.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
           // throw new NotImplementedException();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var empolyees = new List<Employee>();

            var employeesJsonImport = JsonConvert.DeserializeObject<EmployeeInputJson[]>(jsonString);

            foreach (var employeeDto in employeesJsonImport)
            {
                if (IsValid(employeeDto)==false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var allTask = context.Tasks.Select(x => x.Id).ToList();

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };
                foreach (var taksId in employeeDto.Tasks.Distinct())
                {
                    if (allTask.Contains(taksId))
                    {
                        var employeeTas = new EmployeeTask
                        {
                            TaskId = taksId
                        };
                    employee.EmployeesTasks.Add(employeeTas);
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }

                empolyees.Add(employee);

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(empolyees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();


          //  throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}