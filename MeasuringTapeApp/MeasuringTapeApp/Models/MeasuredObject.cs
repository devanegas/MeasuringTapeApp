using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MeasuringTapeApp.Models
{
    public class MeasuredObject
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Measurement { get; set; }
        public string Units { get; set; }
        public string UnitSystem { get; set; }

        public string Print
        {
            get => $"\u2022 Name: {Name}\n\u2022 Type: {Type}\n\u2022 Measurement: {Measurement}\n\u2022 Units: {Units}\n";

        }
    }
}
