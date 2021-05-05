using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ProjectAttributeXml
    {
        [XmlAttribute("Project")]
        public int TasksCount { get; set; }
        [XmlArray("Project")]
        public ExportProjectsXml[] Tasks { get; set; }
    }

    [XmlType("Project")]
    public class ExportProjectsXml
    {

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TaskExport[] Tasks { get; set; }
    }

    [XmlType("Tasks")]
    public class TaskExport
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
/*
 *   <Project TasksCount="10">
    <ProjectName>Hyster-Yale</ProjectName>
    <HasEndDate>No</HasEndDate>
    <Tasks>
      <Task>
        <Name>Broadleaf</Name>
        <Label>JavaAdvanced</Label>
      </Task>
*/