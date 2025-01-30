using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using libCore;
using Microsoft.Win32;

namespace wpfRoadEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int RowsWorkingSurface;
        private int ColsWorkingSurface;
        private System.Windows.Point startMouseDown;
        private System.Windows.Point startPoint = new System.Windows.Point(0, 0);
        private System.Windows.Point startPoint_Druw = new System.Windows.Point(0, 0);
        private System.Windows.Point finishPoint_Druw = new System.Windows.Point(0, 0);
        private Bitmap b;
        private Bitmap bWorkingArea;
        private Bitmap buf;
        private Bitmap ElementsB;
        private Graphics g;
        private Graphics gWorkingArea;

        private int shiftX = 0;
        private int shiftY = 0;
        private double scale = 1.0;
        private double scale_local = 1;
        private bool Clear = false;
        private bool Brush = false;
        private bool Shapse = false;
        private WorkingWithWindow WWW;
        SolidBrush brush;
        public MainWindow()
        {
            InitializeComponent();
            WWW = new WorkingWithWindow((int)Elements.Width, (int)Elements.Height);
            brush = new SolidBrush(System.Drawing.Color.Black);

            Elements.MouseLeftButtonDown += Elements_MouseLeftButtonDown;
            WorkingArea.MouseLeftButtonDown += WorkingArea_MouseLeftButtonDown;
            WorkingArea.MouseRightButtonDown += WorkingArea_MouseRightButtonDown;
            WorkingArea.MouseDown += WorkingArea_MouseDown; /*(s, e) => startMouseDown = e.Location;*/
            WorkingArea.MouseMove += WorkingArea_MouseMove;
            WorkingArea.MouseWheel += WorkingArea_MouseWheel;
            WorkingArea.MouseUp += WorkingArea_MouseUp;
            buApply.Click += BuApply_Click;
            buSave_diagram.Click += BuSave_diagram_Click;
            buSave_as.Click += BuSave_as_Click;
            buDownload_diagram.Click += BuDownload_diagram_Click;
            buClear.Click += BuClear_Click;
            buBrush.Click += BuBrush_Click;
            buShapes.Click += BuShapes_Click;

            ElementsB = new Bitmap((int)Elements.Width, (int)Elements.Height);

            //bWorkingArea = new Bitmap((int)WorkingArea.Width, (int)WorkingArea.Height);

            b = new Bitmap((int)Elements.Width, (int)Elements.Height);
            g = Graphics.FromImage(b);
            //gWorkingArea = Graphics.FromImage(bWorkingArea);
            g.FillRectangle(brush, 0, 0, b.Width, b.Height);
            Elements.Source = CСonvert(b);

            g = Graphics.FromImage(ElementsB);
            g.DrawImage(
                WWW.DrawGrid(false),
                new System.Drawing.Rectangle(0, 0, (int)Elements.Width, (int)Elements.Height),
                new System.Drawing.Rectangle(0, 0, WWW.DrawGrid(false).Width, WWW.DrawGrid(false).Height),
                GraphicsUnit.Pixel);
        }

        private void WorkingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {

                startPoint.X += e.GetPosition().X - startMouseDown.X;
                startPoint.Y += e.GetPosition().Y - startMouseDown.Y;

                startMouseDown = e.GetPosition();

                shiftX = (int)startPoint.X;
                shiftY = (int)startPoint.Y;

                //WorkingArea.Invalidate();
            }
            if (e.ChangedButton == MouseButtons.Left)
            {
                ClickL(e);
            }
        }

        private void Start()
        {
            WWW.Init(ColsWorkingSurface, RowsWorkingSurface);
            bWorkingArea = WWW.DrawGrid(true);
            gWorkingArea = Graphics.FromImage(bWorkingArea);
        }

        private void BuShapes_Click(object sender, RoutedEventArgs e)
        {
            Clear = false;
            Brush = false;
            Shapse = true;
        }

        private void BuBrush_Click(object sender, RoutedEventArgs e)
        {
            Clear = false;
            Brush = true;
            Shapse = false;
        }

        private void BuClear_Click(object sender, RoutedEventArgs e)
        {
            Clear = true;
            Brush = false;
            Shapse = false;
        }

        private void BuDownload_diagram_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.txt)| *.txt | All files(*.*) | *.*";
            if (dialog.ShowDialog() == true)
            {
                WWW.Download_diagram(dialog.FileName);
                bWorkingArea = WWW.B;
                EdLine.Text = WWW.Rows.ToString();
                EdColumns.Text = WWW.Colms.ToString();
            }
        }

        private void BuSave_as_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Image Files(*.png)| *.png | All files(*.*) | *.*";
            if (dialog.ShowDialog() == true)
            {
                WWW.Save_as(dialog.FileName, dialog.Filter);
            }
        }

        private void BuSave_diagram_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Image Files(*.txt)| *.txt | All files(*.*) | *.*";
            if (dialog.ShowDialog() == true)
            {
                WWW.Save_diagram(dialog.FileName);
            }
        }

        private void BuApply_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(EdLine.Text) > 0 && Convert.ToInt32(EdColumns.Text) > 0)
            {
                RowsWorkingSurface = Convert.ToInt32(EdLine.Text);
                ColsWorkingSurface = Convert.ToInt32(EdColumns.Text);
                Start();
            }
            else
            {
                MessageBox.Show("Число строк и столбцов не может быть меньше 1!");
            }
        }

        private void WorkingArea_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Shapse)
            {
                WWW.Synchronization();
            }
        }

        private void WorkingArea_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            
                scale_local = 1.0;
                scale_local += e.Delta * 0.0001;
                scale += e.Delta * 0.0001;

                buf = bWorkingArea;
                bWorkingArea = new Bitmap((int)(buf.Width * scale_local), (int)(buf.Height * scale_local));
                gWorkingArea = Graphics.FromImage(bWorkingArea);
                gWorkingArea.DrawImage(
                    buf,
                    new System.Drawing.Rectangle(0, 0, bWorkingArea.Width, bWorkingArea.Height),
                    new System.Drawing.Rectangle(0, 0, buf.Width, buf.Height),
                    GraphicsUnit.Pixel);
        }



        private void ClickL(MouseEventArgs e)
        {
            if (Brush)
            {
                WWW.DrawCells(e.GetPosition().X, e.GetPosition().Y, shiftX, shiftY, scale);
            }
            if (Clear)
            {
                WWW.Clear_Cells(e.GetPosition().X, e.GetPosition().Y, shiftX, shiftY, scale);
            }
            if (Shapse)
            {
                finishPoint_Druw = e.GetPosition();
                WWW.Draw_Shapse(startPoint_Druw, finishPoint_Druw, shiftX, shiftY, scale);
            }
            bWorkingArea = new Bitmap((int)(WWW.B.Width * scale), (int)(WWW.B.Height * scale));
            gWorkingArea = Graphics.FromImage(bWorkingArea);
            gWorkingArea.DrawImage(
                    Shapse ? WWW.buf_B : WWW.B,
                    new Rectangle(0, 0, bWorkingArea.Width, bWorkingArea.Height),
                    new Rectangle(0, 0, WWW.B.Width, WWW.B.Height),
                    GraphicsUnit.Pixel);
            //WorkingArea.Invalidate();
        }

        private void WorkingArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                startMouseDown = e.GetPosition();
            }
            if (e.ChangedButton == MouseButton.Left)
            {
                startPoint_Druw = e.GetPosition();
            }
        }

        private void WorkingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void WorkingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClickL(e);
        }

        private void Elements_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
                b = new Bitmap((int)SelectedItem.Width, (int)SelectedItem.Height);
                g = Graphics.FromImage(b);
                g.FillRectangle(brush, 0, 0, b.Width, b.Height);
                SelectedItem.Image = (Bitmap)b.Clone();

                g = Graphics.FromImage(SelectedItem.Image);
                g.DrawImage(
                    WWW.DrawsElemets(e.GetPosition(this).X, e.GetPosition(this).Y),
                    new Rectangle(0, 0, SelectedItem.Width, SelectedItem.Height),
                    new Rectangle(0, 0, WWW.DrawsElemets(e.GetPosition().X, e.GetPosition().Y).Width, WWW.DrawsElemets(e.GetPosition().X, e.GetPosition().Y).Height),
                    GraphicsUnit.Pixel);
        }
        private BitmapImage CСonvert(Bitmap buf2)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                buf2.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    }
}