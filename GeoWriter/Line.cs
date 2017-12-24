using System.Collections;

namespace GeoWriter
{
    internal class Line
    {
        public ArrayList from = new ArrayList();
        public ArrayList to = new ArrayList();
        public decimal length;
        public double angle;
        public ArrayList delta = new ArrayList();
    }
}