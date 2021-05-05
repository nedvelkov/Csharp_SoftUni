﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
   public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName =("varchar(255)"))]
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
