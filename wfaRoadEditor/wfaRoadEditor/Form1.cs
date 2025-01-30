namespace wfaRoadEditor;
using libCore;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

public partial class Form1 : Form
{
    private int RowsWorkingSurface;
    private int ColsWorkingSurface;
    private Point startMouseDown;
    private Point startPoint = new Point(0, 0);
    private Point startPoint_Druw = new Point(0, 0);
    private Point finishPoint_Druw = new Point(0, 0);
    private Bitmap b;
    private Bitmap bWorkingArea;
    private Bitmap buf;
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
    public Form1()
    {
        InitializeComponent();
        WWW = new WorkingWithWindow(Elements.Width, Elements.Height);
        brush = new SolidBrush(Color.Black);

        Elements.MouseClick += Elements_MouseClick;
        WorkingArea.Paint += (s, e) => e.Graphics.DrawImage(bWorkingArea, startPoint);
        WorkingArea.MouseClick += WorkingArea_MouseClick;
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

        bWorkingArea =new Bitmap(WorkingArea.Width, WorkingArea.Height);

        b = new Bitmap(Elements.Width, Elements.Height);
        g = Graphics.FromImage(b);
        gWorkingArea = Graphics.FromImage(bWorkingArea);
        g.FillRectangle(brush, 0, 0, b.Width, b.Height);
        Elements.Image=(Bitmap)b.Clone();

        g = Graphics.FromImage(Elements.Image);
        g.DrawImage(
            WWW.DrawGrid(false),
            new Rectangle(0, 0, Elements.Image.Width, Elements.Image.Height),
            new Rectangle(0,0, WWW.DrawGrid(false).Width, WWW.DrawGrid(false).Height),
            GraphicsUnit.Pixel);
    }

    private void WorkingArea_MouseUp(object? sender, MouseEventArgs e)
    {
        if(Shapse)
        {
            WWW.Synchronization();
        }
        //WWW.Image_Optimization();
    }

    private void WorkingArea_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            startMouseDown = e.Location;
        }
        if(e.Button == MouseButtons.Left)
        {
            startPoint_Druw = e.Location;
        }
    }

    private void BuShapes_Click(object? sender, EventArgs e)
    {
        Clear = false;
        Brush = false;
        Shapse = true;
    }

    private void BuBrush_Click(object? sender, EventArgs e)
    {
        Clear = false;
        Brush = true;
        Shapse = false;
    }

    private void BuClear_Click(object? sender, EventArgs e)
    {
        Clear = true;
        Brush = false;
        Shapse = false;
    }

    private void BuDownload_diagram_Click(object? sender, EventArgs e)
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "Image Files(*.txt)| *.txt | All files(*.*) | *.*";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            WWW.Download_diagram(dialog.FileName);
            bWorkingArea = WWW.B;
            EdLine.Text = WWW.Rows.ToString();
            EdColumns.Text = WWW.Colms.ToString();
        }
        WorkingArea.Invalidate();
    }

    private void BuSave_as_Click(object? sender, EventArgs e)
    {
        var dialog = new SaveFileDialog();
        dialog.Filter = "Image Files(*.png)| *.png | All files(*.*) | *.*";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            WWW.Save_as(dialog.FileName, dialog.Filter);
        }
    }

    private void BuSave_diagram_Click(object? sender, EventArgs e)
    {
        var dialog = new SaveFileDialog();
        dialog.Filter = "Image Files(*.txt)| *.txt | All files(*.*) | *.*";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            WWW.Save_diagram(dialog.FileName);
        }
    }

    private void BuApply_Click(object? sender, EventArgs e)
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

    private void Start()
    {
        WWW.Init(ColsWorkingSurface, RowsWorkingSurface);
        bWorkingArea = WWW.DrawGrid(true);
        gWorkingArea = Graphics.FromImage(bWorkingArea);
        WorkingArea.Invalidate();
    }

    private void WorkingArea_MouseWheel(object? sender, MouseEventArgs e)
    {
        if (sender is PictureBox)
        {
            scale_local = 1.0;
            scale_local += e.Delta * 0.0001;
            scale += e.Delta * 0.0001;

            buf = bWorkingArea;
            bWorkingArea = new Bitmap((int)(buf.Width * scale_local), (int)(buf.Height * scale_local));
            gWorkingArea = Graphics.FromImage(bWorkingArea);
            gWorkingArea.DrawImage(
                buf,
                new Rectangle(0, 0, bWorkingArea.Width, bWorkingArea.Height),
                new Rectangle(0, 0, buf.Width, buf.Height),
                GraphicsUnit.Pixel);
            WorkingArea.Invalidate();
        }
    }


    private void WorkingArea_MouseMove(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {

            startPoint.X += e.X - startMouseDown.X;
            startPoint.Y += e.Y - startMouseDown.Y;

            startMouseDown = e.Location;

            shiftX = startPoint.X;
            shiftY = startPoint.Y;

            WorkingArea.Invalidate();
        }
        if (e.Button == MouseButtons.Left)
        {
            ClickL(e);
        }
    }

    private void WorkingArea_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ClickL(e);
        }
    }

    private void ClickL(MouseEventArgs e)
    {
        if (Brush)
        {
            WWW.DrawCells(e.X, e.Y, shiftX, shiftY, scale);
        }
        if(Clear)
        {
            WWW.Clear_Cells(e.X, e.Y, shiftX, shiftY, scale);
        }
        if(Shapse)
        {
            finishPoint_Druw = e.Location;
            WWW.Draw_Shapse(startPoint_Druw, finishPoint_Druw, shiftX, shiftY, scale);
        }
        bWorkingArea = new Bitmap((int)(WWW.B.Width * scale), (int)(WWW.B.Height * scale));
        gWorkingArea = Graphics.FromImage(bWorkingArea);
        gWorkingArea.DrawImage(
                Shapse?WWW.buf_B:WWW.B,
                new Rectangle(0, 0, bWorkingArea.Width, bWorkingArea.Height),
                new Rectangle(0, 0, WWW.B.Width, WWW.B.Height),
                GraphicsUnit.Pixel);
        WorkingArea.Invalidate();
    }

    private void Elements_MouseClick(object? sender, MouseEventArgs e)
    {

        if (e.Button == MouseButtons.Left && sender is PictureBox)
        {
            b = new Bitmap(SelectedItem.Width, SelectedItem.Height);
            g = Graphics.FromImage(b);
            g.FillRectangle(brush, 0, 0, b.Width, b.Height);
            SelectedItem.Image = (Bitmap)b.Clone();

            g = Graphics.FromImage(SelectedItem.Image);
            g.DrawImage(
                WWW.DrawsElemets(e.X, e.Y),
                new Rectangle(0, 0, SelectedItem.Width, SelectedItem.Height),
                new Rectangle(0, 0, WWW.DrawsElemets(e.X, e.Y).Width, WWW.DrawsElemets(e.X, e.Y).Height),
                GraphicsUnit.Pixel);

        }
    }
}
