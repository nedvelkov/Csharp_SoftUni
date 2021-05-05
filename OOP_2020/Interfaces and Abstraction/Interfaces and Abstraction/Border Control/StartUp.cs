namespace BorderControl
{
    using System.Collections.Generic;
    using Contracts;
    using BorderControl.Core;
   
    using Models;
   public class StartUp
    {
        static void Main()
        {
           
            Engine engine = new Engine();
            //  engine.ChekID();
            //  engine.SelebrateBirthday();
            engine.AddBuyers();
            engine.SellFood();
            
        }
    }
}
