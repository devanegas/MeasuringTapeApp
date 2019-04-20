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
        public string ImageUri { get; set; }

        //Hola Dieguin, ya vas a ver que si va a funcionar perro<3
        public string Print
        {
            get => $"Name: {Name}\nType: {Type}\nMeasurement: {Measurement}\nUnits: {Units}\n";

        }
    }
}
