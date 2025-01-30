
using System.Runtime.InteropServices.Marshalling;
using System.Windows.Forms;
using System.IO;
using System;
using System.Drawing;

namespace libCore
{
    public class WorkingWithWindow
    {
        private string str = "";
        private string[,] map;
        private string[,] buf_map;
        private string buf_str;
        private string buf_typ;
        private Random rnd = new Random();
        private Bitmap b;
        private Bitmap buf_b;
        private Bitmap elemets;
        private Bitmap b1;
        private int shiftX = 0;
        private int shiftY = 0;
        private double scale = 1;
        private int HeightElements;
        private int WidthElements;
        private int standard_size = 60;
        private int standard_size_Elements = 60;
        private int standard_size_Elements_w;
        private int standard_size_Elements_h;
        private int colms;
        private int rows;
        private int colmsb1 = 4;
        private int rowsb1 = 4;
        private int colmsElements = 4;
        private int rowsElements = 3;
        private int selected_i;
        private int selected_j;
        private int width = 0;
        private int height = 0;
        private Graphics g;
        private Graphics buf_g;
        private Graphics g2;
        private Graphics g1;
        private int cellWidthElements;
        private int cellHeightElements;
        private Dictionary<string, List<List<int>>> book = new();
        private List<List<int>> bookElements = new();
        private List<string> mas_decor = new();
        private SolidBrush brush;
        public Bitmap B { get { return b; } }
        public Bitmap buf_B { get { return buf_b; } }
        public int Colms { get { return colms; } }
        public int Rows { get { return rows; } }
        public WorkingWithWindow(int pWidth, int pHeight)
        {
            HeightElements = pHeight;
            WidthElements = pWidth;
            brush = new SolidBrush(Color.White);
            b1 = new Bitmap(standard_size_Elements, standard_size_Elements);

            width = b1.Width / colmsb1;
            height = b1.Height / rowsb1;

            standard_size_Elements_w = WidthElements / colmsElements;
            standard_size_Elements_h = HeightElements / rowsElements;

            elemets = new Bitmap(standard_size * colmsElements, standard_size * rowsElements);
            g2 = Graphics.FromImage(elemets);
            g1 = Graphics.FromImage(b1);
            cellWidthElements = 1024 / colmsElements;
            cellHeightElements = 768 / rowsElements;

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });

            book.Add("00", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });

            book.Add("10", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("20", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("30", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });

            book.Add("01", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });

            book.Add("11", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("21", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("31", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("02", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 1, 1, 1 });

            book.Add("12", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 1, 1, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 0, 0, 0, 0 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("22", bookElements);

            bookElements.Clear();

            bookElements.Add(new List<int> { 1, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 1 });
            bookElements.Add(new List<int> { 0, 0, 0, 1 });
            bookElements.Add(new List<int> { 1, 0, 0, 1 });

            book.Add("32", bookElements);
        }
        public void Init(int pcolms, int prows)
        {
            str = "";
            b = new Bitmap(standard_size * pcolms, standard_size * prows);
            g = Graphics.FromImage(b);
            colms = pcolms;
            rows = prows;
            map = new string[rows, colms];
            str = colms.ToString()+ " " + rows.ToString() + "\n";
            g.FillRectangle(brush, 0, 0, b.Width, b.Height);
        }
        private void Init2()
        {
            b.Dispose();
            b = new Bitmap(standard_size * colms, standard_size * rows);
            g = Graphics.FromImage(b);
            g.FillRectangle(brush, 0, 0, b.Width, b.Height);
        }
        public void DrawCells(int x, int y, int pshiftX, int pshiftY, double pscale)
        {
            scale = pscale;
            shiftX = pshiftX;
            shiftY = pshiftY;
            int i = 0;
            int j = 0;
            Coordinate_Search(x, y, ref i, ref j);
            g.DrawImage(
                b1,
                new Rectangle(i * standard_size, j * standard_size, standard_size, standard_size),
                new Rectangle(0, 0, b1.Width, b1.Height),
                GraphicsUnit.Pixel);
            Filling_Сhart_Сard(i, j, true);
            MessageBox.Show(buf_str + buf_typ);
        }

        private void Filling_Сhart_Сard(int i, int j, bool flag)
        {
            buf_str = selected_i.ToString() + " " + selected_j.ToString() + " " + i.ToString() + " " + j.ToString() + "\n";

            if (mas_decor.Count() != 0)
            {
                for (int s = 0; s < mas_decor.Count(); s++)
                {
                    buf_str += mas_decor[s];
                }
                for (int s = 0; s < 3 - mas_decor.Count(); s++)
                {
                    buf_str += "-" + "\n";
                }
            }
            else
            {
                buf_str += "-" + "\n" + "-" + "\n" + "-" + "\n";
            }

            if (i < colms && j < rows && i > -1 && j > -1)
            {
                if (flag)
                {
                    map[j, i] = buf_str;
                }
                else
                {
                    buf_map[j, i] = buf_str;
                }
            }
        }

        private void Coordinate_Search(int x, int y, ref int i, ref int j)
        {
            for (; i <= colms; i++)
            {
                if ((double)(i * standard_size) * scale > x - shiftX)
                {
                    i--;
                    break;
                }
            }
            for (; j <= rows; j++)
            {
                if ((double)(j * standard_size) * scale > y - shiftY)
                {
                    j--;
                    break;
                }
            }
        }

        public Bitmap DrawsElemets(int x, int y)
        {
            g1 = Graphics.FromImage(b1);
            Bitmap buf = new Bitmap(2, 2);
            int i = 0;
            int j = 0;
            string key = "";
            int pi = 0;
            int pj = 0;
            int typ = 0;
            for (; i < colmsElements; i++)
            {
                if (i * standard_size_Elements_w > x)
                {
                    i--;
                    break;
                }
            }
            if (i == 4)
            {
                i--;
            }
            for (; j < rowsElements; j++)
            {
                if (j * standard_size_Elements_h > y)
                {
                    j--;
                    break;
                }
            }
            if (j == 3)
            {
                j--;
            }
            Draw_Element(i, j, width, height, ref key, ref pi, ref pj, ref typ);

            return b1;
        }

        private void Draw_Element(int i, int j, int width, int height, ref string key, ref int pi, ref int pj, ref int typ)
        {
            Bitmap buf = new Bitmap(2, 2);
            g1.DrawImage(
                            new Bitmap(new MemoryStream(Properties.Resources.Roads)),
                            new Rectangle(0, 0, b1.Width, b1.Height),
                            new Rectangle(i * cellWidthElements, j * cellHeightElements, cellWidthElements, cellHeightElements),
                            GraphicsUnit.Pixel);
            selected_i = i;
            selected_j = j;
            mas_decor.Clear();
            if (rnd.Next(2) % 2 == 0)
            {
                key = i.ToString() + j.ToString();
                typ = rnd.Next(4);
                buf_typ = key;
                for (int s = 0; s < 3; s++)
                {
                    pi = rnd.Next(4);
                    pj = rnd.Next(4);
                    var ij = book[key][pj][pi];
                    if (ij == 1)
                    {
                        switch (typ)
                        {
                            case 0:
                                buf = new Bitmap(new MemoryStream(Properties.Resources.Bush1));
                                break;
                            case 1:
                                buf = new Bitmap(new MemoryStream(Properties.Resources.Bush2));
                                break;
                            case 2:
                                buf = new Bitmap(new MemoryStream(Properties.Resources.Sakura));
                                break;
                            case 3:
                                buf = new Bitmap(new MemoryStream(Properties.Resources.Tree1));
                                break;
                        }
                        mas_decor.Add(pi.ToString() + " " + pj.ToString() + " " + typ.ToString() + "\n");
                        g1.DrawImage(
                                buf,
                                new Rectangle(pi * width, pj * height, width, height),
                                new Rectangle(0, 0, buf.Width, buf.Height),
                                GraphicsUnit.Pixel);
                    }
                }
            }
        }

        public Bitmap DrawGrid(bool flag)
        {
            if (flag)
            {
                for(int i = 0; i <= colms; i++)
                {
                    g.DrawLine(new Pen(Color.Black), i * standard_size, 0, i * standard_size, b.Height);
                }
                for(int j = 0; j <= rows; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 0, j * standard_size, b.Width, j * standard_size);
                }
            }
            else
            {
                for (int i = 0; i <= colmsElements; i++)
                {
                    g2.DrawLine(new Pen(Color.White), i * standard_size_Elements_w, 0, i * standard_size_Elements_w, elemets.Height);
                }
                for (int j = 0; j <= rowsElements; j++)
                {
                    g2.DrawLine(new Pen(Color.White), 0, j * standard_size_Elements_h, elemets.Width, j * standard_size_Elements_h);
                }
                for(int i = 0; i < colmsElements; i++)
                {
                    for(int j = 0; j < rowsElements; j++)
                    {
                        g2.DrawImage(
                        new Bitmap(new MemoryStream(Properties.Resources.Roads)),
                        new Rectangle(i * standard_size, j * standard_size, standard_size, standard_size),
                        new Rectangle(i * cellWidthElements, j * cellHeightElements, cellWidthElements, cellHeightElements),
                        GraphicsUnit.Pixel);
                    }
                }
            }
            Bitmap pb = new Bitmap(flag?b:elemets);
            return pb;
        }

        public void Save_as(string path, string filter)
        {
            var save = System.Drawing.Imaging.ImageFormat.Png;
            b.Save(path, save);
        }
        public void Save_diagram(string path)
        {
            StreamWriter file = new StreamWriter(path);
            for(int i = 0;i < colms;i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    str += map[i, j];
                }
            }
            file.WriteLine(str);
            file.Close();
        }
        public void Download_diagram(string path)
        {
            StreamReader file = new StreamReader(path);
            string input = file.ReadLine();
            string[] parts = input.Split(' ');
            if (int.Parse(parts[0]) > 0 && int.Parse(parts[1]) > 0)
            {
                Init(int.Parse(parts[0]), int.Parse(parts[1]));
                DrawGrid(true);
                int i = 0;
                int j = 0;

                int pi = 0;
                int pj = 0;
                string typ = "";

                int width = b1.Width / colmsb1;
                int height = b1.Height / rowsb1;

                while ((input = file.ReadLine()) != null)
                {
                    if (input != "")
                    {


                        parts = input.Split(' ');
                        selected_i = int.Parse(parts[0]);
                        selected_j = int.Parse(parts[1]);
                        i = int.Parse(parts[2]);
                        j = int.Parse(parts[3]);
                        buf_str = input;


                        g1.DrawImage(
                        new Bitmap(new MemoryStream(Properties.Resources.Roads)),
                        new Rectangle(0, 0, b1.Width, b1.Height),
                        new Rectangle(selected_i * cellWidthElements, selected_j * cellHeightElements, cellWidthElements, cellHeightElements),
                        GraphicsUnit.Pixel);
                        for (int s = 0; s < 3; s++)
                        {
                            if ((input = file.ReadLine()) != null)
                            {
                                buf_str += input;
                                Draw_Bush(ref pi, ref pj, ref typ, width, height, ref input);
                            }
                        }

                        g.DrawImage(
                           b1,
                           new Rectangle(i * standard_size, j * standard_size, standard_size, standard_size),
                           new Rectangle(0, 0, b1.Width, b1.Height),
                           GraphicsUnit.Pixel);
                        map[j, i] = buf_str;
                    }

                }
            }
            else
            {
                MessageBox.Show("Число строк и столбцов не может быть меньше 1!");
            }
            file.Close();
        }

        public void Clear_Cells(int x, int y, int pshiftX, int pshiftY, double pscale)
        {
            scale = pscale;
            shiftX = pshiftX;
            shiftY = pshiftY;
            int i = 0;
            int j = 0;
            int pi = 0;
            int pj = 0;
            string typ = "";
            Coordinate_Search(x, y, ref i, ref j);
            map[j, i] = null;
            g.FillRectangle(brush, i * standard_size, j * standard_size, standard_size, standard_size);
            DrawGrid(true);
        }

        private void Draw_Bush(ref int pi, ref int pj, ref string typ, int width, int height, ref string input)
        {
            Bitmap buf = new Bitmap(2, 2);
            if (input != "-")
            {
                string[] parts = input.Split(' ');
                pi = int.Parse(parts[0]);
                pj = int.Parse(parts[1]);
                typ = parts[2];

                switch (typ)
                {
                    case "0":
                        buf = new Bitmap(new MemoryStream(Properties.Resources.Bush1));
                        break;
                    case "1":
                        buf = new Bitmap(new MemoryStream(Properties.Resources.Bush2));
                        break;
                    case "2":
                        buf = new Bitmap(new MemoryStream(Properties.Resources.Sakura));
                        break;
                    case "3":
                        buf = new Bitmap(new MemoryStream(Properties.Resources.Tree1));
                        break;
                }
                g1.DrawImage(
                        buf,
                        new Rectangle(pi * width, pj * height, width, height),
                        new Rectangle(0, 0, buf.Width, buf.Height),
                        GraphicsUnit.Pixel);
            }
        }

        public void Draw_Shapse(Point start_Point, Point finish_Point, int pshiftX, int pshiftY, double pscale)
        {
            buf_b = (Bitmap)b.Clone();
            buf_map = new string[rows, colms];
            buf_g = Graphics.FromImage(buf_b);
            Point point;
            scale = pscale;
            shiftX = pshiftX;
            shiftY = pshiftY;
            int i = 0;
            int j = 0;
            int i2 = 0;
            int j2 = 0;
            string key = "";
            int pi = 0;
            int pj = 0;
            int typ = 0;
            int ei = rnd.Next(colmsElements);
            int ej = rnd.Next(rowsElements);
            if (start_Point.X == finish_Point.X && start_Point.Y > finish_Point.Y || start_Point.X > finish_Point.X && start_Point.Y == finish_Point.Y || start_Point.X > finish_Point.X && start_Point.Y > finish_Point.Y)
            {
                point = start_Point;
                start_Point = finish_Point;
                finish_Point = point;
            }
            else
            {
                if (start_Point.Y > finish_Point.Y)
                {
                    point = start_Point;
                    start_Point.Y = finish_Point.Y;
                    finish_Point.Y = point.Y;
                }
                if(start_Point.X > finish_Point.X)
                {
                    point = start_Point;
                    start_Point.X = finish_Point.X;
                    finish_Point.X = point.X;
                }
            }
            Coordinate_Search(start_Point.X, start_Point.Y, ref i, ref j);
            Coordinate_Search(finish_Point.X, finish_Point.Y, ref i2, ref j2);
            if (i == i2 && j == j2)
            {
                Draw_Element(ei, ej, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(i * standard_size, j * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(i, j, false);
            }
            else if(i == i2 )
            {
                Druw_Vertical(i, j, j2, width, height, ref key, ref pi, ref pj, ref typ);
            }
            else if (j == j2 )
            {
                Druw_Horizontal(i, j, i2, width, height, ref key, ref pi, ref pj, ref typ);
            }
            else
            {
                Druw_Vertical(i, j + 1, j2 - 1, width, height, ref key, ref pi, ref pj, ref typ);
                Druw_Horizontal(i + 1, j, i2 - 1, width, height, ref key, ref pi, ref pj, ref typ);
                Druw_Vertical(i2, j + 1, j2 - 1, width, height, ref key, ref pi, ref pj, ref typ);
                Druw_Horizontal(i + 1, j2, i2 - 1, width, height, ref key, ref pi, ref pj, ref typ);

                Draw_Element(2, 1, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(i * standard_size, j * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(i, j, false);

                Draw_Element(3, 1, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(i2 * standard_size, j * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(i2, j, false);

                Draw_Element(1, 0, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(i * standard_size, j2 * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(i, j2, false);

                Draw_Element(0, 1, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(i2 * standard_size, j2 * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(i2, j2, false);
            }
        }

        private void Druw_Vertical(int i, int j, int j2, int width, int height, ref string key, ref int pi, ref int pj, ref int typ)
        {
            for (int a = j; a <= j2; a++)
            {
                Draw_Element(3, 0, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(i * standard_size, a * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(i, a, false);
            }
        }

        private void Druw_Horizontal(int i, int j, int i2, int width, int height, ref string key, ref int pi, ref int pj, ref int typ)
        {
            for (int a = i; a <= i2; a++)
            {
                Draw_Element(0, 0, width, height, ref key, ref pi, ref pj, ref typ);
                buf_g.DrawImage(
                    b1,
                    new Rectangle(a * standard_size, j * standard_size, standard_size, standard_size),
                    new Rectangle(0, 0, b1.Width, b1.Height),
                    GraphicsUnit.Pixel);
                Filling_Сhart_Сard(a, j, false);
            }
        }
        public void Synchronization()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colms; j++)
                {
                    if (buf_map[i, j] != null)
                    {
                        map[i, j] = buf_map[i, j];
                        b = (Bitmap)buf_b.Clone();
                        g = Graphics.FromImage(b);
                    }
                }
            }
        }
        public void Image_Optimization()
        {
            int i = 0;
            int j = 0;
            int pi = 0;
            int pj = 0;
            string typ = "";
            Init2();
            DrawGrid(true);
            for (int a = 0; a < rows; a++)
            {
                for (int c = 0; c < colms; c++)
                {
                    if (map[a, c] != null)
                    {
                        string[] parts = map[a, c].Split('\n');
                        string[] parts2 = parts[0].Split(' ');
                        selected_i = int.Parse(parts2[0]);
                        selected_j = int.Parse(parts2[1]);
                        i = int.Parse(parts2[2]);
                        j = int.Parse(parts2[3]);
                        g1.DrawImage(
                        new Bitmap(new MemoryStream(Properties.Resources.Roads)),
                        new Rectangle(0, 0, b1.Width, b1.Height),
                        new Rectangle(selected_i * cellWidthElements, selected_j * cellHeightElements, cellWidthElements, cellHeightElements),
                        GraphicsUnit.Pixel);
                        for (int d = 1; d < 4; d++)
                        {
                            Draw_Bush(ref pi, ref pj, ref typ, width, height, ref parts[d]);
                        }
                        g.DrawImage(
                           b1,
                           new Rectangle(c * standard_size, a * standard_size, standard_size, standard_size),
                           new Rectangle(0, 0, b1.Width, b1.Height),
                           GraphicsUnit.Pixel);
                    }
                }
            }
        }
    }
}
