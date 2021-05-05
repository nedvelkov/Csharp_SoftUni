using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferModels.Output
{
    [XmlType("car")]
    public class CarOutputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
/*
 <?xml version="1.0" encoding="utf-16"?>
<cars>
  <car>
    <make>BMW</make>
    <model>1M Coupe</model>
    <travelled-distance>39826890</travelled-distance>
  </car>
*/