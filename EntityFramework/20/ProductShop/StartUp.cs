namespace ProductShop
{
    using ProductShop.Data;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
         /*
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
         */
            var inputXml = File.ReadAllText("../../../Datasets/users.xml");




            ;

        }


        public static string ImportUsers(ProductShopContext context, string inputXml)
        {


            return null;
        }
    }
}