﻿namespace Cinema.DataProcessor.ImportDto
{
    using Cinema.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class MovieImportDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
                public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [Required]
        public string Duration { get; set; }
        [Required]
        [Range(1,10)]
        public double Rating { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Director { get; set; }
    }
}
/*
 * •	Id – integer, Primary Key
•	Title – text with length [3, 20] (required)
•	Genre – enumeration of type Genre, with possible values (Action, Drama, Comedy, Crime, Western, Romance, Documentary, Children, Animation, Musical) (required)
•	Duration – TimeSpan (required)
•	Rating – double in the range [1,10] (required)
•	Director – text with length [3, 20] (required)
•	Projections - collection of type Projection

 *   {
    "Title": "Little Big Man",
    "Genre": "Western",
    "Duration": "01:58:00",
    "Rating": 28,
    "Director": "Duffie Abrahamson"
  },
*/