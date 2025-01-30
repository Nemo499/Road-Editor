namespace wfaRoadEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            buShapes = new Button();
            buBrush = new Button();
            buClear = new Button();
            buDownload_diagram = new Button();
            buSave_diagram = new Button();
            buSave_as = new Button();
            Elements = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            SelectedItem = new PictureBox();
            buApply = new Button();
            EdColumns = new TextBox();
            EdLine = new TextBox();
            label2 = new Label();
            label1 = new Label();
            WorkingArea = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Elements).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WorkingArea).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.Controls.Add(buShapes);
            panel1.Controls.Add(buBrush);
            panel1.Controls.Add(buClear);
            panel1.Controls.Add(buDownload_diagram);
            panel1.Controls.Add(buSave_diagram);
            panel1.Controls.Add(buSave_as);
            panel1.Controls.Add(Elements);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(SelectedItem);
            panel1.Controls.Add(buApply);
            panel1.Controls.Add(EdColumns);
            panel1.Controls.Add(EdLine);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 7);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 772);
            panel1.TabIndex = 2;
            // 
            // buShapes
            // 
            buShapes.Location = new Point(62, 453);
            buShapes.Name = "buShapes";
            buShapes.Size = new Size(112, 23);
            buShapes.TabIndex = 16;
            buShapes.Text = "Рисовать фигуру";
            buShapes.UseVisualStyleBackColor = true;
            // 
            // buBrush
            // 
            buBrush.Location = new Point(40, 424);
            buBrush.Name = "buBrush";
            buBrush.Size = new Size(152, 23);
            buBrush.TabIndex = 15;
            buBrush.Text = "Свободное рисование";
            buBrush.UseVisualStyleBackColor = true;
            // 
            // buClear
            // 
            buClear.Location = new Point(61, 395);
            buClear.Name = "buClear";
            buClear.Size = new Size(113, 23);
            buClear.TabIndex = 14;
            buClear.Text = "Очистить очейку";
            buClear.UseVisualStyleBackColor = true;
            // 
            // buDownload_diagram
            // 
            buDownload_diagram.Location = new Point(61, 366);
            buDownload_diagram.Name = "buDownload_diagram";
            buDownload_diagram.Size = new Size(113, 23);
            buDownload_diagram.TabIndex = 13;
            buDownload_diagram.Text = "Загрузить схему";
            buDownload_diagram.UseVisualStyleBackColor = true;
            // 
            // buSave_diagram
            // 
            buSave_diagram.Location = new Point(61, 337);
            buSave_diagram.Name = "buSave_diagram";
            buSave_diagram.Size = new Size(113, 23);
            buSave_diagram.TabIndex = 12;
            buSave_diagram.Text = "Сохранить схему";
            buSave_diagram.UseVisualStyleBackColor = true;
            // 
            // buSave_as
            // 
            buSave_as.Location = new Point(61, 296);
            buSave_as.Name = "buSave_as";
            buSave_as.Size = new Size(113, 23);
            buSave_as.TabIndex = 11;
            buSave_as.Text = "Сохрнаить как";
            buSave_as.UseVisualStyleBackColor = true;
            // 
            // Elements
            // 
            Elements.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Elements.Location = new Point(4, 630);
            Elements.Name = "Elements";
            Elements.Size = new Size(225, 138);
            Elements.TabIndex = 10;
            Elements.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(62, 600);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 9;
            label4.Text = "Рабочие элементы";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 107);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 8;
            label3.Text = "Выбранный элемент";
            // 
            // SelectedItem
            // 
            SelectedItem.ImageLocation = "";
            SelectedItem.Location = new Point(40, 134);
            SelectedItem.Margin = new Padding(2);
            SelectedItem.Name = "SelectedItem";
            SelectedItem.Size = new Size(144, 144);
            SelectedItem.TabIndex = 7;
            SelectedItem.TabStop = false;
            // 
            // buApply
            // 
            buApply.Location = new Point(82, 76);
            buApply.Margin = new Padding(2);
            buApply.Name = "buApply";
            buApply.Size = new Size(78, 20);
            buApply.TabIndex = 4;
            buApply.Text = "Применить";
            buApply.UseVisualStyleBackColor = true;
            // 
            // EdColumns
            // 
            EdColumns.Location = new Point(108, 38);
            EdColumns.Margin = new Padding(2);
            EdColumns.Name = "EdColumns";
            EdColumns.Size = new Size(106, 23);
            EdColumns.TabIndex = 3;
            // 
            // EdLine
            // 
            EdLine.Location = new Point(108, 12);
            EdLine.Margin = new Padding(2);
            EdLine.Name = "EdLine";
            EdLine.Size = new Size(106, 23);
            EdLine.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 38);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Кол-во стобцов";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 12);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Кол-во строк";
            // 
            // WorkingArea
            // 
            WorkingArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WorkingArea.Location = new Point(244, 7);
            WorkingArea.Name = "WorkingArea";
            WorkingArea.Size = new Size(1005, 772);
            WorkingArea.TabIndex = 3;
            WorkingArea.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1252, 787);
            Controls.Add(WorkingArea);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Elements).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)WorkingArea).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button buApply;
        private TextBox EdColumns;
        private TextBox EdLine;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private PictureBox SelectedItem;
        private PictureBox WorkingArea;
        private PictureBox Elements;
        private Button buSave_diagram;
        private Button buSave_as;
        private Button buDownload_diagram;
        private Button buShapes;
        private Button buBrush;
        private Button buClear;
    }
}
