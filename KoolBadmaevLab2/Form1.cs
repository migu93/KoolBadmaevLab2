using KoolBadmaevLab2;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace KoolBadmaevLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        public Bitmap globalBitmap;
        private Graphics g;
        private int countPointInSostBezier = 0;
        private int countMinusSostPoints = 0;
        bool firstRaz = false;
        public SolidBrush _fillBrush = new SolidBrush(Color.Red);
        int countClick = 0;
        List<Point> points = new List<Point>();
        private CSpline _model;
        public Color ColorLine { get; set; } = Color.Black;
        //Метод, устанавливающий пиксел на форме с заданными цветом и прозрачностью
        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            if (alpha < 0)
            {
                alpha = 0;
            }
            else if (alpha > 255)
            {
                alpha = 255;
            }

            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }
        private static void PutPixelFloat(Graphics g, Color col, int x, int y, float alpha)
        {

            g.FillRectangle(new SolidBrush(Color.Black), x, y, 1, 1);
        }

        //Статический метод, реализующий отрисовку 4-связной линии
        static public void BresenhamLine(Graphics g, Color clr, int x0, int y0, int x1, int y1)
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
        #region Splines

        private void SetD1ToModel()
        {
            _model.GenerateSplines(ColorLine);
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
                Draw();
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            txtArray.Clear();
            points.Add(new Point(e.X, e.Y));

            foreach (var item in points)
            {
                txtArray.Text += $"X: {item.X}  \nY: {item.Y}" + Environment.NewLine;
            }
            countClick++;
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, points[countClick - 1].X, points[countClick - 1].Y, 2, 2);

            if (e.Button == MouseButtons.Left && sostKrivaya.Checked)
            {
                countPointInSostBezier++;
                lblSostPointsCount.Text = countPointInSostBezier.ToString();
            }

            if (rb_fill.Checked)
            {
                globalBitmap.SetPixel(e.X, e.Y, Color.Red);
                pictureBox1.Image = globalBitmap;
            }
        }

        private void FloodFill(Graphics g, Point pt, Color fillColor, Color targetColor)
        {
            // Implement a recursive flood fill algorithm to fill the shape
            if (targetColor.ToArgb() == fillColor.ToArgb())
            {
                return;
            }
            if (g == null)
            {
                throw new ArgumentNullException(nameof(g));
            }
            if (pt.X < 0 || pt.X >= pictureBox1.Width || pt.Y < 0 || pt.Y >= pictureBox1.Height)
            {
                return;
            }
            Bitmap bitmap = (Bitmap)pictureBox1.Image;
            Color pixelColor = bitmap.GetPixel(pt.X, pt.Y);
            if (pixelColor.ToArgb() != targetColor.ToArgb())
            {
                return;
            }
            bitmap.SetPixel(pt.X, pt.Y, fillColor);
            FloodFill(g, new Point(pt.X - 1, pt.Y), fillColor, targetColor);
            FloodFill(g, new Point(pt.X + 1, pt.Y), fillColor, targetColor);
            FloodFill(g, new Point(pt.X, pt.Y - 1), fillColor, targetColor);
            FloodFill(g, new Point(pt.X, pt.Y + 1), fillColor, targetColor);
        }
        public void SmoothBresenhamLine(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            float intensity = 1.0f;
            float intensityStep = 1.0f / (Math.Max(dx, dy) + 1);

            while (true)
            {
                float x = x0 + 0.5f;
                float y = y0 + 0.5f;
                float dist = DistanceToLine(x0, y0, x1, y1, x, y);
                Color color = Color.FromArgb((int)(clr.R * intensity), (int)(clr.G * intensity), (int)(clr.B * intensity));
                PutPixelFloat(g, color, (int)x, (int)y, (int)(255 * intensity));

                if (x0 == x1 && y0 == y1) break;

                float err2 = 2 * err;
                if (err2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }
                if (err2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }

                intensity -= intensityStep * (dist - 0.5f);
            }
        }

        static float DistanceToLine(int x1, int y1, int x2, int y2, float px, float py)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float mag = (float)Math.Sqrt(dx * dx + dy * dy);
            dx /= mag;
            dy /= mag;
            float proj = (px - x1) * dx + (py - y1) * dy;
            float qx = x1 + proj * dx;
            float qy = y1 + proj * dy;
            float dist = (float)Math.Sqrt((px - qx) * (px - qx) + (py - qy) * (py - qy));
            return dist;
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
            bool FirstPainting = false;
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
                        SmoothBresenhamLine(g, ColorLine, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
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
                else if (sostKrivaya.Checked)
                {
                    if (firstRaz)
                        countMinusSostPoints--;

                    List<PointF> pointsS = new List<PointF>();

                    for (int i = countMinusSostPoints; i < points.Count; i++)
                    {
                        pointsS.Add(points[i]);
                    }

                    BezierCurve curve = new BezierCurve(pointsS);
                    curve.dataPointsN = pointsS;

                    g = Graphics.FromHwnd(pictureBox1.Handle);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    curve.DrawN(g, ColorLine);
                    firstRaz = true;
                }
            }
            if (sostKrivaya.Checked && e.Button == MouseButtons.Right)
            {
                countMinusSostPoints = countPointInSostBezier;
                bydetOtris.Text = countMinusSostPoints.ToString();
            }
            globalBitmap = (Bitmap)pictureBox1.Image;
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
                Draw();
            }
        }

        private void btnSelectColor_Click_1(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorLine = colorDialog1.Color;
            pictureBox2.BackColor = ColorLine;
        }

        private void sostKrivaya_MouseCaptureChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Составная кривая автивирована");
        }
    }
}