using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RectangleAndCircle
{
    public partial class Form1 : Form
    {
        private int centerX = 300;
        private int centerY = 300;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var radius = (int) radiusEditor.Value;
            var epsilon = (int) epsilonEditor.Value;

            var rectangleGenerator = new RandomRectangleGenerator(epsilon);
            var inCircleChecker = new InCircleChecker();
            var compactor = new Compactor(radius, inCircleChecker);
            var circleFiller = new CircleFiller(rectangleGenerator, compactor);

            var rectangles = circleFiller.GetRectangles();

            DrawRectangles(rectangles, radius);
        }

        private void DrawRectangles(IEnumerable<RectangleD> revtangles, int radius)
        {
            var pen = new Pen(Color.Black, 1);
            var g = panel1.CreateGraphics();

            g.Clear(Color.White);

            var diametr = radius * 2;
            g.DrawEllipse(pen,
                centerX - radius,
                centerY - radius,
                diametr,
                diametr);

            foreach (var rectangleD in revtangles)
            {
                var recX = (float) rectangleD.X + centerX;
                var recY = (float)  - rectangleD.Y + centerY;
                var recWidth = (float) rectangleD.Width;
                var recHeight = (float) rectangleD.Height;
                g.DrawRectangle(pen,
                    recX,
                    recY,
                    recWidth,
                    recHeight);
            }
        }
    }
}