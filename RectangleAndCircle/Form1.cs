using System;
using System.Drawing;
using System.Windows.Forms;

namespace RectangleAndCircle
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Pen pen;
        private int centerX = 300;
        private int centerY = 300;
        private readonly ICircleFiller _circleFiller;

        public Form1()
        {
            InitializeComponent();

            pen = new Pen(Color.Black, 1);
            g = panel1.CreateGraphics();
            var rectangleGenerator = new RectangleGenerator();
            _circleFiller = new CircleFiller(rectangleGenerator);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var radius = (float) radiusEditor.Value;
            var minRectangleSize = (float) minRectangleSizeEditor.Value;

            var revtangles = _circleFiller.GetRectangles(radius, minRectangleSize);

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