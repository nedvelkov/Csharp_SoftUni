
namespace CarDealer
{
    using System;
    using CarDealer.Data;
    using CarDealer.DataTransferModels.Input;
    using CarDealer.DataTransferModels.Output;
    using CarDealer.Models;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using CarDealer.XMLHelper;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            var context = new CarDealerContext();
            /*
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            var supplierXML = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXML = File.ReadAllText("../../../Datasets/parts.xml");
            var carXML = File.ReadAllText("../../../Datasets/cars.xml");
            var customerXML = File.ReadAllText("../../../Datasets/customers.xml");
            var saleXML = File.ReadAllText("../../../Datasets/sales.xml");
            ImportSuppliers(context, supplierXML);
            ImportParts(context, partsXML);
            ImportCars(context, carXML);
            ImportCustomers(context, customerXML);
            ImportSales(context, saleXML);
            */
            
            Console.WriteLine(GetCarsFromMakeBmw(context)); 

            ;
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var textReader = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textReader) as SupplierInputModel[];

            var supplier = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            })
                .ToList();

            context.Suppliers.AddRange(supplier);
            context.SaveChanges();

            return $"Successfully imported {supplier.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";

            var partInputModels = XmlConverter.Deserializer<PartsInputModel>(inputXml, root);

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partInputModels
                .Where(s => supplierIds.Contains(s.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var carInputModels = XmlConverter.Deserializer<CarInputModel>(inputXml, root);

            var partsId = context.Parts
                .Select(x => x.Id)
                .ToList();
            var cars = new List<Car>();

            foreach (var car in carInputModels)
            {
                var uniqueParts = car.CarPartInputs.Select(x => x.Id).Distinct();
                var parts = uniqueParts.Intersect(partsId);
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };
                    currentCar.PartCars.Add(partCar);
                }
                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";


            // return null;
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            var customerInputModels = XmlConverter.Deserializer<CustomerInputModel>(inputXml, root);

            var customers = customerInputModels
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";

            // return null;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var saleInputModels = XmlConverter.Deserializer<SalesInputModel>(inputXml, root);

            var cars = context.Cars
                .Select(x => x.Id)
                .ToList();

            var sales = saleInputModels
                .Where(s => cars.Contains(s.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";


          //  return null;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(m => m.Make)
                .ThenBy(m => m.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer=new XmlSerializer(typeof(CarOutputModel[]),new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("","");

            xmlSerializer.Serialize(textWriter, cars,ns);


            return textWriter.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(m => m.Make == "BMW")
                .Select(x => new BmwOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var result = XmlConverter.Serialize(cars, "cars");


            return result;
        }

    }

}