namespace CarDealer.DataTransferModels.Input
{
    using System.Xml.Serialization;
    [XmlType("partId")]

    public class CarPartInputs
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}/*    <parts>
      <partId id="38"/>
*/