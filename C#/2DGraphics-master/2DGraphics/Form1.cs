namespace _2DGraphics
{
    public partial class Form1 : Form
    {
        //color from hex code https://stackoverflow.com/questions/2109756/how-do-i-get-the-color-from-a-hexadecimal-color-code-using-net
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 750;
            this.BackColor = ColorTranslator.FromHtml("#008F8C");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(ColorTranslator.FromHtml("#023535"), 15.0F);
            Brush lightestTealBrush = new SolidBrush(ColorTranslator.FromHtml("#0FC2C0"));
            Brush lighterTealBrush = new SolidBrush(ColorTranslator.FromHtml("#0CABAB"));

            //draws hexagon in background
            g.DrawPolygon(pen, new Point[] { new Point(350, 100), new Point(200, 375), new Point(350, 650), new Point(650, 650), new Point(800,375), new Point(650, 100) });

            //draws ellipses for buttons
            pen.Width = 5.0F;
            pen.Color = ColorTranslator.FromHtml("#015958");
            g.DrawEllipse(pen, 350, 145, 300, 100);
            g.DrawEllipse(pen, 350, 265, 300, 100);
            g.DrawEllipse(pen, 350, 385, 300, 100);
            g.DrawEllipse(pen, 350, 505, 300, 100);

            //draws text in each button
            g.DrawString("Continue", new Font("Agency FB", 30), lighterTealBrush, new PointF(415, 155));
            g.DrawString("Save", new Font("Agency FB", 30), lighterTealBrush, new PointF(447, 275));
            g.DrawString("Settings", new Font("Agency FB", 30), lighterTealBrush, new PointF(420, 395));
            g.DrawString("Exit", new Font("Agency FB", 30), lighterTealBrush, new PointF(460, 515));

            //draws pause button in upper right corner
            g.FillRectangle(lightestTealBrush, 910, 10, 10, 50);
            g.FillPolygon(lightestTealBrush, new Point[] { new Point(930, 10), new Point(955, 35), new Point(930, 60) });

            //draws player info in upper left corner
            pen.Color = ColorTranslator.FromHtml("#0FC2C0");
            g.DrawEllipse(pen, 35, 20, 50, 50);
            g.DrawArc(pen, 35, 70, 50, 75, 12, -204);
            pen.Color = ColorTranslator.FromHtml("#015958");
            g.DrawRectangle(pen, 10, 10, 100, 100);
            g.FillPie(lighterTealBrush, 120, 35, 50, 50, -90, -285);
            g.DrawString("Progress", new Font("Agency FB", 12), lighterTealBrush, new PointF(120, 10));
        }
    }
}