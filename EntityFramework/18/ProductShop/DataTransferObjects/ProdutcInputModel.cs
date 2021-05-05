using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DataTransferObjects
{
    public class ProdutcInputModel
    {
        public  string Name { get; set; }
        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public int? BuyerId { get; set; }

    }
}
/*
 *     "Name": "CLARINS Ever Matte SPF 15 - 105 Nude",
    "Price": 696.06,
    "SellerId": 39,
    "BuyerId": 56
*/