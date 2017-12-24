﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                parseInputAndExportGEOFile();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Oh crap, I screwed up: " + ex.Message);
            }
        }

        private void parseInputAndExportGEOFile()
        {
            ArrayList commandList = new ArrayList();

            string[] commandLines = inputBox.Text.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            
            for (int i=0; i < commandLines.Length; i++)
            {
                if (commandLines[i].Contains("ARC")) {
                    commandList.Add(processArc(i, commandLines));
                }
                else if (commandLines[i].Contains("CIRCLE")) {
                    commandList.Add(processCircle(i, commandLines));
                }
                else if (commandLines[i].Contains("LWPOLYLINE")) {
                    commandList.Add(processPolyline(i, commandLines));
                }
                else if (commandLines[i].Contains("LINE")) {
                    commandList.Add(processLine(i, commandLines));
                }
            }

            MessageBox.Show("Processed " + commandList.Count + " commands.", "Success");

            writeOutGeoFile(commandList);
        }

        private void writeOutGeoFile(ArrayList commandList)
        {
            using (TextWriter writer = File.CreateText(@"C:\Users\Boreas\Desktop\GeoOutput.txt"))
            {
                for (int i = 0; i < commandList.Count; i++)
                {
                    commandList[i].GetType();

                    if (commandList[i].GetType().Equals("GeoWriter.Arc"))
                    {
                        Arc arcToWrite = new Arc();
                        arcToWrite = (Arc)commandList[i];
                        MessageBox.Show(arcToWrite.writeCommand());
                    }
                    else if (commandList[i].GetType().Equals("GeoWriter.Circle"))
                    {
                        
                    }
                    else if (commandList[i].GetType().Equals("GeoWriter.Polyline"))
                    {
                        writer.WriteLine("Polyline currently not supported at this time.");
                    }
                    else if (commandList[i].GetType().Equals("GeoWriter.Line"))
                    {
                        
                    }

                    writer.WriteLine(commandList[i].GetType());
                }
            }
        }

        private object processPolyline(int i, string[] commandLines)
        {
            //Get first 3 lines
            //while line doesnt equal bulge
            //  add atPoint to list
            //

            return "Crap";
        }

        private object processLine(int i, string[] commandLines)
        {
            Line line = new Line();

            int xFrom = commandLines[i + 3].IndexOf("X=");
            int yFrom = commandLines[i + 3].IndexOf("Y=");
            int zFrom = commandLines[i + 3].IndexOf("Z=");
            line.from.Add(decimal.Parse(commandLines[i + 3].Substring(xFrom + 2, 9)));
            line.from.Add(decimal.Parse(commandLines[i + 3].Substring(yFrom + 2, 9)));
            line.from.Add(decimal.Parse(commandLines[i + 3].Substring(zFrom + 2, 9)));

            int xTo = commandLines[i + 4].IndexOf("X=");
            int yTo = commandLines[i + 4].IndexOf("Y=");
            int zTo = commandLines[i + 4].IndexOf("Z=");
            line.to.Add(decimal.Parse(commandLines[i + 4].Substring(xTo + 2, 9)));
            line.to.Add(decimal.Parse(commandLines[i + 4].Substring(yTo + 2, 9)));
            line.to.Add(decimal.Parse(commandLines[i + 4].Substring(zTo + 2, 9)));

            int lengthPos = commandLines[i + 5].IndexOf("Length =");
            line.length = decimal.Parse(commandLines[i + 5].Substring(lengthPos + 8, 9));

            int anglePos = commandLines[i + 5].IndexOf("Angle in XY Plane =");
            line.angle = double.Parse(commandLines[i + 5].Substring(anglePos + 19, 7));

            int xDelta = commandLines[i + 6].IndexOf("Delta X =");
            int yDelta = commandLines[i + 6].IndexOf("Delta Y =");
            int zDelta = commandLines[i + 6].IndexOf("Delta Z =");
            line.delta.Add(decimal.Parse(commandLines[i + 6].Substring(xDelta + 9, 9)));
            line.delta.Add(decimal.Parse(commandLines[i + 6].Substring(yDelta + 9, 10)));
            line.delta.Add(decimal.Parse(commandLines[i + 6].Substring(zDelta + 9, 9)));

            return line;
        }

        private object processCircle(int i, string[] commandLines)
        {
            Circle circle = new Circle();

            int xCenter = commandLines[i + 3].IndexOf("X=");
            int yCenter = commandLines[i + 3].IndexOf("Y=");
            int zCenter = commandLines[i + 3].IndexOf("Z=");
            circle.centerPoint.Add(decimal.Parse(commandLines[i + 3].Substring(xCenter + 2, 9)));
            circle.centerPoint.Add(decimal.Parse(commandLines[i + 3].Substring(yCenter + 2, 9)));
            circle.centerPoint.Add(decimal.Parse(commandLines[i + 3].Substring(zCenter + 2, 9)));

            int radiusPos = commandLines[i + 4].IndexOf("radius");
            circle.radius = decimal.Parse(commandLines[i + 4].Substring(radiusPos + 6, 10));

            int circumferencePos = commandLines[i + 5].IndexOf("circumference");
            circle.circumference = decimal.Parse(commandLines[i + 5].Substring(circumferencePos + 13, 10));

            int areaPos = commandLines[i + 6].IndexOf("area");
            circle.area = decimal.Parse(commandLines[i + 6].Substring(areaPos + 4, 10));

            return circle;
        }

        private object processArc(int i, string[] commandLines)
        {
            Arc arc = new Arc();

            int xCenter = commandLines[i + 3].IndexOf("X=");
            int yCenter = commandLines[i + 3].IndexOf("Y=");
            int zCenter = commandLines[i + 3].IndexOf("Z=");
            arc.centerPoint.Add(decimal.Parse(commandLines[i + 3].Substring(xCenter + 2, 9)));
            arc.centerPoint.Add(decimal.Parse(commandLines[i + 3].Substring(yCenter + 2, 9)));
            arc.centerPoint.Add(decimal.Parse(commandLines[i + 3].Substring(zCenter + 2, 9)));

            int radiusPos = commandLines[i + 4].IndexOf("radius");
            arc.radius = decimal.Parse(commandLines[i + 4].Substring(radiusPos + 6, 10));

            int startAnglePos = commandLines[i + 5].IndexOf("start angle");
            arc.startAngle = double.Parse(commandLines[i + 5].Substring(startAnglePos + 11, 7));

            int endAnglePos = commandLines[i + 6].IndexOf("end angle");
            arc.endAngle = double.Parse(commandLines[i + 6].Substring(endAnglePos + 9, 7));

            int lengthPos = commandLines[i + 7].IndexOf("length");
            arc.length = decimal.Parse(commandLines[i + 7].Substring(lengthPos + 6, 10));

            return arc;
        }

        private void clearInput_Click(object sender, EventArgs e)
        {
            inputBox.Clear();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
