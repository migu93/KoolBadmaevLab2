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
            pictureBox1 = new PictureBox();
            txtArray = new TextBox();
            button1 = new Button();
            btnSelectColor = new Button();
            pictureBox2 = new PictureBox();
            rbBrezenhem = new RadioButton();
            rbBrizenhemPlus = new RadioButton();
            rbCurveBize = new RadioButton();
            rbBizeN = new RadioButton();
            colorDialog1 = new ColorDialog();
            sostKrivaya = new RadioButton();
            label5 = new Label();
            lblSostPointsCount = new Label();
            label7 = new Label();
            bydetOtris = new Label();
            rb_fill = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(32, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(873, 352);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown_1;
            // 
            // txtArray
            // 
            txtArray.Location = new Point(32, 403);
            txtArray.Multiline = true;
            txtArray.Name = "txtArray";
            txtArray.ReadOnly = true;
            txtArray.ScrollBars = ScrollBars.Vertical;
            txtArray.Size = new Size(145, 121);
            txtArray.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(731, 415);
            button1.Name = "button1";
            button1.Size = new Size(174, 50);
            button1.TabIndex = 4;
            button1.Text = "Просчитать сплайн";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Location = new Point(731, 475);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(123, 33);
            btnSelectColor.TabIndex = 5;
            btnSelectColor.Text = "Выбрать цвет";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectColor_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(872, 475);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 33);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.BackColorChanged += pictureBox2_BackColorChanged;
            // 
            // rbBrezenhem
            // 
            rbBrezenhem.AutoSize = true;
            rbBrezenhem.Location = new Point(417, 415);
            rbBrezenhem.Name = "rbBrezenhem";
            rbBrezenhem.Size = new Size(75, 24);
            rbBrezenhem.TabIndex = 7;
            rbBrezenhem.Text = "Линия";
            rbBrezenhem.UseVisualStyleBackColor = true;
            // 
            // rbBrizenhemPlus
            // 
            rbBrizenhemPlus.AutoSize = true;
            rbBrizenhemPlus.Location = new Point(417, 445);
            rbBrizenhemPlus.Name = "rbBrizenhemPlus";
            rbBrizenhemPlus.Size = new Size(161, 24);
            rbBrizenhemPlus.TabIndex = 8;
            rbBrizenhemPlus.Text = "Сглаженная линия";
            rbBrizenhemPlus.UseVisualStyleBackColor = true;
            // 
            // rbCurveBize
            // 
            rbCurveBize.AutoSize = true;
            rbCurveBize.Location = new Point(417, 475);
            rbCurveBize.Name = "rbCurveBize";
            rbCurveBize.Size = new Size(155, 24);
            rbCurveBize.TabIndex = 9;
            rbCurveBize.Text = "Кривая 4 порядка";
            rbCurveBize.UseVisualStyleBackColor = true;
            // 
            // rbBizeN
            // 
            rbBizeN.AutoSize = true;
            rbBizeN.Location = new Point(417, 505);
            rbBizeN.Name = "rbBizeN";
            rbBizeN.Size = new Size(155, 24);
            rbBizeN.TabIndex = 10;
            rbBizeN.Text = "Кривая n порядка";
            rbBizeN.UseVisualStyleBackColor = true;
            // 
            // sostKrivaya
            // 
            sostKrivaya.AutoSize = true;
            sostKrivaya.Checked = true;
            sostKrivaya.Location = new Point(417, 535);
            sostKrivaya.Name = "sostKrivaya";
            sostKrivaya.Size = new Size(155, 24);
            sostKrivaya.TabIndex = 19;
            sostKrivaya.TabStop = true;
            sostKrivaya.Text = "Составная кривая";
            sostKrivaya.UseVisualStyleBackColor = true;
            sostKrivaya.MouseCaptureChanged += sostKrivaya_MouseCaptureChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 535);
            label5.Name = "label5";
            label5.Size = new Size(183, 20);
            label5.TabIndex = 20;
            label5.Text = "Точек составной кривой:";
            // 
            // lblSostPointsCount
            // 
            lblSostPointsCount.AutoSize = true;
            lblSostPointsCount.Location = new Point(220, 551);
            lblSostPointsCount.Name = "lblSostPointsCount";
            lblSostPointsCount.Size = new Size(0, 20);
            lblSostPointsCount.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 561);
            label7.Name = "label7";
            label7.Size = new Size(156, 20);
            label7.TabIndex = 23;
            label7.Text = "Будет отрисовано от:";
            // 
            // bydetOtris
            // 
            bydetOtris.AutoSize = true;
            bydetOtris.Location = new Point(197, 561);
            bydetOtris.Name = "bydetOtris";
            bydetOtris.Size = new Size(0, 20);
            bydetOtris.TabIndex = 24;
            // 
            // rb_fill
            // 
            rb_fill.AutoSize = true;
            rb_fill.Location = new Point(417, 565);
            rb_fill.Name = "rb_fill";
            rb_fill.Size = new Size(86, 24);
            rb_fill.TabIndex = 25;
            rb_fill.Text = "Заливка";
            rb_fill.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 619);
            Controls.Add(rb_fill);
            Controls.Add(bydetOtris);
            Controls.Add(label7);
            Controls.Add(lblSostPointsCount);
            Controls.Add(label5);
            Controls.Add(sostKrivaya);
            Controls.Add(rbBizeN);
            Controls.Add(rbCurveBize);
            Controls.Add(rbBrizenhemPlus);
            Controls.Add(rbBrezenhem);
            Controls.Add(pictureBox2);
            Controls.Add(btnSelectColor);
            Controls.Add(button1);
            Controls.Add(txtArray);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            MouseDown += Form1_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtArray;
        private Button button1;
        private Button btnSelectColor;
        private PictureBox pictureBox2;
        private RadioButton rbBrezenhem;
        private RadioButton rbBrizenhemPlus;
        private RadioButton rbCurveBize;
        private RadioButton rbBizeN;
        private ColorDialog colorDialog1;
        private RadioButton sostKrivaya;
        private Label label5;
        private Label lblSostPointsCount;
        private Label label7;
        private Label bydetOtris;
        private RadioButton rb_fill;
    }
}