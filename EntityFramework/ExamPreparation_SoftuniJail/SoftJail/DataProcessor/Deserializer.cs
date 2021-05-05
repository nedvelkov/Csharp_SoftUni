namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departments = new List<Department>();
            var departmentDto = JsonConvert.DeserializeObject<List<DepartmentInputJsonModel>>(jsonString);
            foreach (var currentDto in departmentDto)
            {

                //   if ((currentDto.Name.Length<3 || currentDto.Name.Length>25) ||currentDto.Cells.Count==0
                //       || currentDto.Cells.Any(x=>x.CellNumber<1 || x.CellNumber>1000))

                    if(!IsValid(currentDto) 
                    || !currentDto.Cells.All(IsValid)
                    || !currentDto.Cells.Any())

                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = currentDto.Name,
                    Cells = currentDto.Cells
                    .Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };
                sb.AppendLine($"Imported {currentDto.Name} with {currentDto.Cells.Count()} cells");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}