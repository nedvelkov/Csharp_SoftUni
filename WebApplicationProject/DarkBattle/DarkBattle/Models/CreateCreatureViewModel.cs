namespace DarkBattle.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using static DataConstants.DataContstants;
    public class CreateCreatureViewModel
    {
        [Required]
        [MinLength(NameMinLenght)]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(ImageRegex)]
        public string Image { get; set; }

        [Range(MinValue,MaxValueCreature)]
        public int Attack { get; set; }

        [Range(MinValue, MaxValueCreature)]
        public int Defense { get; set; }

        [Range(MinValue, MaxValueCreature)]
        public int Health { get; set; }

        [Range(MinValue, MaxValueCreature)]
        public int Block { get; set; }

        [Range(MinValue, MaxValueCreature)]
        public int Level { get; set; }

        [Range(MinValue, MaxValueCreature)]
        public int Gold { get; set; }

        [Range(MinValue,MaxValueCreature)]
        public int Expiriece { get; set; }

    }
}