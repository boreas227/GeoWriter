
using System;
using System.Collections;

namespace GeoWriter
{
    internal class Arc
    {
        public ArrayList centerPoint = new ArrayList();
        public decimal radius;
        public double startAngle;
        public double endAngle;
        public decimal length;

        internal string writeCommand()
        {
            throw new NotImplementedException();
        }
    }
}