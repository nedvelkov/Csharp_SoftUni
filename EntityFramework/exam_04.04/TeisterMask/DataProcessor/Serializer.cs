namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {


            return null;
            //throw new NotImplementedException();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(d => d.Task.OpenDate >= date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                                        .Select(t => new
                                        {
                                            TaskName = t.Task.Name,
                                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                            LabelType = t.Task.LabelType.ToString(),
                                            ExecutionType = t.Task.ExecutionType.ToString()
                                        }).ToList()
                })
                .ToList()
                .OrderByDescending(c => c.Tasks.Count())
                .ThenBy(x => x.Username);


            string jsonString = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return jsonString;


            // throw new NotImplementedException();
        }
    }
}