using KoolBadmaevLab2;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace KoolBadmaevLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int countClick = 0;
        List<Point> points = new List<Point>();
        private CSpline _model;
        public Color ColorLine { get; set; } = Color.Black;
        //Метод, устанавливающий пиксел на форме с заданными цветом и прозрачностью
        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }

        //Статический метод, реализующий отрисовку 4-связной линии
        static public void BresenhamLine(Graphics g, Color clr, int x0, int y0,int x1, int y1)
        {
            //Изменения координат
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);
            //Направление приращения
            int sx = (x1 >= x0) ? (1) : (-1);
            int sy = (y1 >= y0) ? (1) : (-1);

            if (dy < dx)
            {
                int d = (dy << 1) - dx;
                int d1 = dy << 1;
                int d2 = (dy - dx) << 1;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0 + sx;
                int y = y0;
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                        d += d1;
                    PutPixel(g, clr, x, y, 255);
                    x += sx;
                }
            }
            else
            {
                int d = (dx << 1) - dy;
                int d1 = dx << 1;
                int d2 = (dx - dy) << 1;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0;
                int y = y0 + sy;
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                        d += d1;
                    PutPixel(g, clr, x, y, 255);
                    y += sy;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            txtArray.Clear();
            points.Add(new Point(e.X, e.Y));

            foreach (var item in points)
            {
                txtArray.Text += $"X: {item.X}  \nY: {item.Y}" + Environment.NewLine;
            }
            countClick++;
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, points[countClick - 1].X, points[countClick - 1].Y, 2, 2);
            if (points.Count > 4)
            {
                rbCurveBize.Checked = false;
                rbBizeN.Checked = true;
            }
        }

        #region Splines

        private void SetD1ToModel()
        {
            _model.GenerateSplines(ColorLine);
        }

        private void GetDerivatesFromModel()
        {
            textBox_df1.Text = $"{-_model.Df1:0.0000}";
            textBox_dfn.Text = $"{-_model.Dfn:0.0000}";
            textBox_ddf1.Text = $"{-_model.Ddf1:0.0000}";
            textBox_ddfn.Text = $"{-_model.Ddfn:0.0000}";
        }

        private void Draw()
        {
            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            var canvas = Graphics.FromImage(bmp);

            _model.Draw(canvas);

            pictureBox1.Image = bmp;
        }
        #endregion
        private void pictureBox2_BackColorChanged(object sender, EventArgs e)
        {
            CSplineSubinterval.ColorLine = ColorLine;
            if (_model != null & points.Count > 1)
            {
                SetD1ToModel();
                GetDerivatesFromModel();
                Draw();
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            txtArray.Clear();
            points.Add(new Point(e.X, e.Y));

            foreach (var item in points)
            {
                txtArray.Text += $"X: {item.X}  \nY: {item.Y}" + Environment.NewLine;
            }
            countClick++;
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, points[countClick - 1].X, points[countClick - 1].Y, 2, 2);
            if (points.Count > 4)
            {
                rbCurveBize.Checked = false;
                rbBizeN.Checked = true;
            }
        }

        static void DrawLineInt(Graphics g, Point startPoint, Point endPoint, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            // Calculate the delta values for the x and y axes
            int deltaX = Math.Abs(endPoint.X - startPoint.X);
            int deltaY = Math.Abs(endPoint.Y - startPoint.Y);

            // Set the initial values for the x and y axes
            int x = startPoint.X;
            int y = startPoint.Y;

            // Set the step values for the x and y axes
            int stepX = (startPoint.X < endPoint.X) ? 1 : -1;
            int stepY = (startPoint.Y < endPoint.Y) ? 1 : -1;

            // Set the value for the decision parameter
            int decision;

            // Check if the line is steep (more than 45 degrees)
            if (deltaY > deltaX)
            {
                // Swap the x and y values and the delta values
                int temp = deltaX;
                deltaX = deltaY;
                deltaY = temp;
                temp = x;
                x = y;
                y = temp;
                temp = stepX;
                stepX = stepY;
                stepY = temp;

                // Set the initial value for the decision parameter
                decision = 2 * deltaY - deltaX;

                // Loop through the points along the x axis
                for (int i = 0; i <= deltaX; i++)
                {
                    // Draw the current point
                    g.FillRectangle(Brushes.Black, x, y, 1, 1);

                    // Update the decision parameter
                    if (decision > 0)
                    {
                        y += stepY;
                        decision -= 2 * deltaX;
                    }

                    decision += 2 * deltaY;
                    x += stepX;
                }
            }
            else
            {
                // Set the initial value for the decision parameter
                decision = 2 * deltaX - deltaY;

                // Loop through the points along the y axis
                for (int i = 0; i <= deltaY; i++)
                {
                    // Draw the current point
                    g.FillRectangle(brush, x, y, 1, 1);

                    // Update the decision parameter
                    if (decision > 0)
                    {
                        x += stepX;
                        decision -= 2 * deltaY;
                    }

                    decision += 2 * deltaX;
                    y += stepY;
                }
            }
        }
        private void DrawLineS(int x1, int y1, int x2, int y2)
        {
            // Initialize a Bitmap object with the desired width and height
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Calculate the slope of the line
            float slope = (float)(y2 - y1) / (x2 - x1);

            // Iterate through each pixel on the line
            for (int x = x1; x <= x2; x++)
            {
                // Determine the y-coordinate of the pixel using the slope
                int y = (int)(slope * (x - x1) + y1);

                // Use an anti-aliasing algorithm to smooth the line
                Color color = AntiAliasing(x, y, bmp);

                // Set the pixel color for the current pixel
                bmp.SetPixel(x, y, color);
            }

            // Display the Bitmap object on the PictureBox control
            pictureBox1.Image = bmp;
        }

        private Color AntiAliasing(int x, int y, Bitmap bmp)
        {
            // Initialize the sum of the red, green, and blue values to 0
            int redSum = 0;
            int greenSum = 0;
            int blueSum = 0;

            // Initialize the total weight to 0
            int totalWeight = 0;

            // Iterate through the surrounding pixels
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Calculate the distance of the current pixel from the center pixel
                    float distance = (float)Math.Sqrt(i * i + j * j);

                    // Calculate the weight of the current pixel based on its distance from the center
                    float weight = 1.0f / (1.0f + distance);

                    // Add the weighted values of the red, green, and blue channels to the sums
                    redSum += (int)(bmp.GetPixel(x + i, y + j).R * weight);
                    greenSum += (int)(bmp.GetPixel(x + i, y + j).G * weight);
                    blueSum += (int)(bmp.GetPixel(x + i, y + j).B * weight);

                    // Add the weight of the current pixel to the total weight
                    totalWeight += (int)weight;
                }
            }

            // Calculate the weighted average values for the red, green, and blue channels
            int red = (int)(redSum / totalWeight);
            int green = (int)(greenSum / totalWeight);
            int blue = (int)(blueSum / totalWeight);

            // Return the resulting color
            return Color.FromArgb(red, green, blue);
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
            Graphics g = pictureBox1.CreateGraphics();

            if (e.Button == MouseButtons.Right)
            {
                if (rbBrezenhem.Checked)
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        BresenhamLine(g, ColorLine, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                    }
                }
                else if (rbBrizenhemPlus.Checked)
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        DrawLineS(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                    }
                }
                // Кривая по 4 точкам
                else if (rbCurveBize.Checked && points.Count == 4)
                {
                    PointF[] pointFs = new PointF[4];
                    for (int i = 0; i < points.Count; i++)
                    {
                        pointFs[i] = points[i];
                    }
                    BezierCurve curve = new BezierCurve(pointFs);
                    curve.Draw(g);
                }
                // Кривая Бизье n порядка
                else if (rbBizeN.Checked)
                {
                    List<PointF> pointFs = new List<PointF>();
                    BezierCurve curve = new BezierCurve(pointFs);
                    foreach (var item in points)
                    {
                        pointFs.Add(item);
                    }
                    curve.dataPointsN = pointFs;
                    g = Graphics.FromHwnd(pictureBox1.Handle);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    curve.DrawN(g, ColorLine);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var random = new Random();

            var spline = new CPoint[points.Count];
            var interval = (pictureBox1.Width - 20) / points.Count;

            for (var i = 0; i < points.Count; i++)
            {
                spline[i] = new CPoint(points[i].X, points[i].Y);
            }

            _model = new CSpline(spline);
            if (points.Count > 1)
            {
                SetD1ToModel();
                GetDerivatesFromModel();
                Draw();
            }
        }

        private void btnSelectColor_Click_1(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorLine = colorDialog1.Color;
            pictureBox2.BackColor = ColorLine;
        }
    }
}