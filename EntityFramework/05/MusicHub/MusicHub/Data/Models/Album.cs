namespace MusicHub.Data.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="Date")]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => this.Songs.Select(x=>x.Price).Sum();

        public int? ProducerId { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}
/*
 * •	Id – Integer, Primary Key
•	Name – Text with max length 40 (required)
•	ReleaseDate – Date (required)
•	Price – calculated property (the sum of all song prices in the album)
•	ProducerId – integer, Foreign key
•	Producer – the album’s producer
•	Songs – collection of all Songs in the Album 
*/
