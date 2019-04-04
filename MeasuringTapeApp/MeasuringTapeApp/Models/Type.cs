using System;
using System.Collections.Generic;
using System.Text;

namespace MeasuringTapeApp.Models
{
    public class Type
    {
        private static string[] statusList;
        public static string[] StatusList => statusList ??
        (
            statusList = new string[]{
                "Linear",
                "Multi-Linear"
            }
        );

        private static string[] unit;
        public static string[] Units => unit ??
        (
            unit = new string[]{
                "Meters (m)",
                "Centimeters (cm)",
                "Yards (yd)",
                "Feet (ft)",
                "Kilometers (km)",
                "Miles (mi)",
                "Inches (in)"
            }
        );
    }
}
