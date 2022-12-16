namespace KoolBadmaevLab2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.txtArray = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rbBrezenhem = new System.Windows.Forms.RadioButton();
            this.rbBrizenhemPlus = new System.Windows.Forms.RadioButton();
            this.rbCurveBize = new System.Windows.Forms.RadioButton();
            this.rbBizeN = new System.Windows.Forms.RadioButton();
            this.textBox_df1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ddf1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_dfn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ddfn = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(32, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(873, 352);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(3, 21);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(26, 376);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(912, 21);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(26, 376);
            this.vScrollBar2.TabIndex = 2;
            this.vScrollBar2.ValueChanged += new System.EventHandler(this.vScrollBar2_ValueChanged);
            // 
            // txtArray
            // 
            this.txtArray.Location = new System.Drawing.Point(32, 403);
            this.txtArray.Multiline = true;
            this.txtArray.Name = "txtArray";
            this.txtArray.ReadOnly = true;
            this.txtArray.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArray.Size = new System.Drawing.Size(145, 121);
            this.txtArray.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(731, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Просчитать сплайн";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(731, 475);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(123, 33);
            this.btnSelectColor.TabIndex = 5;
            this.btnSelectColor.Text = "Выбрать цвет";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(872, 475);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.BackColorChanged += new System.EventHandler(this.pictureBox2_BackColorChanged);
            // 
            // rbBrezenhem
            // 
            this.rbBrezenhem.AutoSize = true;
            this.rbBrezenhem.Checked = true;
            this.rbBrezenhem.Location = new System.Drawing.Point(417, 415);
            this.rbBrezenhem.Name = "rbBrezenhem";
            this.rbBrezenhem.Size = new System.Drawing.Size(75, 24);
            this.rbBrezenhem.TabIndex = 7;
            this.rbBrezenhem.TabStop = true;
            this.rbBrezenhem.Text = "Линия";
            this.rbBrezenhem.UseVisualStyleBackColor = true;
            // 
            // rbBrizenhemPlus
            // 
            this.rbBrizenhemPlus.AutoSize = true;
            this.rbBrizenhemPlus.Location = new System.Drawing.Point(417, 445);
            this.rbBrizenhemPlus.Name = "rbBrizenhemPlus";
            this.rbBrizenhemPlus.Size = new System.Drawing.Size(161, 24);
            this.rbBrizenhemPlus.TabIndex = 8;
            this.rbBrizenhemPlus.Text = "Сглаженная линия";
            this.rbBrizenhemPlus.UseVisualStyleBackColor = true;
            this.rbBrizenhemPlus.Visible = false;
            // 
            // rbCurveBize
            // 
            this.rbCurveBize.AutoSize = true;
            this.rbCurveBize.Location = new System.Drawing.Point(417, 475);
            this.rbCurveBize.Name = "rbCurveBize";
            this.rbCurveBize.Size = new System.Drawing.Size(155, 24);
            this.rbCurveBize.TabIndex = 9;
            this.rbCurveBize.Text = "Кривая 4 порядка";
            this.rbCurveBize.UseVisualStyleBackColor = true;
            // 
            // rbBizeN
            // 
            this.rbBizeN.AutoSize = true;
            this.rbBizeN.Location = new System.Drawing.Point(417, 505);
            this.rbBizeN.Name = "rbBizeN";
            this.rbBizeN.Size = new System.Drawing.Size(155, 24);
            this.rbBizeN.TabIndex = 10;
            this.rbBizeN.Text = "Кривая n порядка";
            this.rbBizeN.UseVisualStyleBackColor = true;
            // 
            // textBox_df1
            // 
            this.textBox_df1.Location = new System.Drawing.Point(60, 12);
            this.textBox_df1.Name = "textBox_df1";
            this.textBox_df1.Size = new System.Drawing.Size(90, 27);
            this.textBox_df1.TabIndex = 11;
            this.textBox_df1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "df1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "ddf1";
            // 
            // textBox_ddf1
            // 
            this.textBox_ddf1.Location = new System.Drawing.Point(220, 12);
            this.textBox_ddf1.Name = "textBox_ddf1";
            this.textBox_ddf1.Size = new System.Drawing.Size(90, 27);
            this.textBox_ddf1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(763, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "dfn";
            // 
            // textBox_dfn
            // 
            this.textBox_dfn.Location = new System.Drawing.Point(809, 5);
            this.textBox_dfn.Name = "textBox_dfn";
            this.textBox_dfn.Size = new System.Drawing.Size(90, 27);
            this.textBox_dfn.TabIndex = 17;
            this.textBox_dfn.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(603, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "ddfn";
            // 
            // textBox_ddfn
            // 
            this.textBox_ddfn.Location = new System.Drawing.Point(649, 5);
            this.textBox_ddfn.Name = "textBox_ddfn";
            this.textBox_ddfn.Size = new System.Drawing.Size(90, 27);
            this.textBox_ddfn.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 536);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_dfn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ddfn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_ddf1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_df1);
            this.Controls.Add(this.rbBizeN);
            this.Controls.Add(this.rbCurveBize);
            this.Controls.Add(this.rbBrizenhemPlus);
            this.Controls.Add(this.rbBrezenhem);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtArray);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private VScrollBar vScrollBar1;
        private VScrollBar vScrollBar2;
        private TextBox txtArray;
        private Button button1;
        private Button btnSelectColor;
        private PictureBox pictureBox2;
        private RadioButton rbBrezenhem;
        private RadioButton rbBrizenhemPlus;
        private RadioButton rbCurveBize;
        private RadioButton rbBizeN;
        private TextBox textBox_df1;
        private Label label1;
        private Label label2;
        private TextBox textBox_ddf1;
        private Label label3;
        private TextBox textBox_dfn;
        private Label label4;
        private TextBox textBox_ddfn;
        private ColorDialog colorDialog1;
    }
}