using System;
using System.Collections;

namespace GeoWriter
{
    internal class Circle
    {
        public ArrayList centerPoint = new ArrayList();
        public decimal radius;
        public decimal circumference;
        public decimal area;

        internal string writeCommand()
        {
            return "My awesome circle: " + radius.ToString() + circumference.ToString() + area.ToString();
        }
    }
}