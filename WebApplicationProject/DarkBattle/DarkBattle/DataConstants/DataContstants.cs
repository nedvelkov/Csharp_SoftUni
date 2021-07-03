using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkBattle.DataConstants
{
    public class DataContstants
    {
        public const string ImageRegex = @"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)";
        public const int NameMinLenght = 3;
        public const int NameMaxLenght = 15;

        //Creature
        public const int MinValue = 1;
        public const int MaxValueCreature = 100;
        public const int MaxGoldDrop=250;

        //ChamponVali
    }
}
