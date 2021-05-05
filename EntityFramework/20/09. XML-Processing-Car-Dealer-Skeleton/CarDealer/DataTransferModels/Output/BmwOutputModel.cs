using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

namespace CarDealer.DataTransferModels.Output
{
    [XmlType("cars")]
  public  class BmwOutputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance  { get; set; }
    }
}
/*
 *   <car id="7" model="1M Coupe" travelled-distance="39826890" />
*/
