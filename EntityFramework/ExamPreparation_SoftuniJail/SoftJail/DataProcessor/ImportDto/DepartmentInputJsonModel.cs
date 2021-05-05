using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
  public  class DepartmentInputJsonModel
    {
        [Required]
        [StringLength(25,MinimumLength =3)]
        public string Name { get; set; }

        public List<CellInputModel> Cells { get; set; }

    }
    // text with min length 3 and max length 25 (required)
    public class CellInputModel
    {
        [Range(1,1000)]
        public int CellNumber { get; set; }
        public bool HasWindow { get; set; }
    }
    //•	CellNumber – integer in the range [1, 1000] (required)
}
/*
 *   {
    "Name": "",
    "Cells": [
      {
        "CellNumber": 101,
        "HasWindow": true
      },
      {
        "CellNumber": 102,
        "HasWindow": false
      }
    ]
  },
  {
    "Name": "CSS",
    "Cells": [
      {
        "CellNumber": 0,
        "HasWindow": true
      },
      {
        "CellNumber": 202,
        "HasWindow": false
      }
    ]
  },
*/