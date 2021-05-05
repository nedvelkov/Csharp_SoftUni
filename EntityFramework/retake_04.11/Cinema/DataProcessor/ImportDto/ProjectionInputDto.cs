using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
   public class ProjectionInputDto
    {
        [XmlElement("MovieId")]
        public int MovieId { get; set; }
        [XmlElement("DateTime")]
        public string DateTime { get; set; }
    }
}
/*  <Projection>
    <MovieId>38</MovieId>
    <DateTime>2019-04-27 13:33:20</DateTime>
  </Projection>
*/