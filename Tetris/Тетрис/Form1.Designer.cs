namespace Тетрис
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this._points = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._level = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._lines = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rec10 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.rec9 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.rec8 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.rec7 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.rec6 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.rec5 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.rec4 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.rec3 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.rec2 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.rec1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(235, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Счет";
            // 
            // _points
            // 
            this._points.AutoSize = true;
            this._points.Location = new System.Drawing.Point(138, 33);
            this._points.Name = "_points";
            this._points.Size = new System.Drawing.Size(17, 19);
            this._points.TabIndex = 3;
            this._points.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Уровень";
            // 
            // _level
            // 
            this._level.AutoSize = true;
            this._level.Location = new System.Drawing.Point(138, 69);
            this._level.Name = "_level";
            this._level.Size = new System.Drawing.Size(17, 19);
            this._level.TabIndex = 5;
            this._level.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Удалено строк";
            // 
            // _lines
            // 
            this._lines.AutoSize = true;
            this._lines.Location = new System.Drawing.Point(138, 106);
            this._lines.Name = "_lines";
            this._lines.Size = new System.Drawing.Size(17, 19);
            this._lines.TabIndex = 7;
            this._lines.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this._lines);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._points);
            this.panel1.Controls.Add(this._level);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.Location = new System.Drawing.Point(563, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 157);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GreenYellow;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 307);
            this.panel2.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 21);
            this.label11.TabIndex = 20;
            this.label11.Text = "Закончить";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(143, 263);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 21);
            this.label20.TabIndex = 21;
            this.label20.Text = "Esc";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 21);
            this.label14.TabIndex = 18;
            this.label14.Text = "Пауза";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(143, 227);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 21);
            this.label15.TabIndex = 19;
            this.label15.Text = "Y";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 21);
            this.label16.TabIndex = 14;
            this.label16.Text = "Вправо";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(143, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 21);
            this.label17.TabIndex = 15;
            this.label17.Text = "→";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(143, 186);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 21);
            this.label18.TabIndex = 17;
            this.label18.Text = "↑";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 186);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 21);
            this.label19.TabIndex = 16;
            this.label19.Text = "Повернуть";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "Влево";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "←";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(143, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 21);
            this.label12.TabIndex = 11;
            this.label12.Text = "↓";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 21);
            this.label13.TabIndex = 10;
            this.label13.Text = "Вниз";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Управление";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(563, 306);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 217);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(563, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Начать игру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(118, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Стартовый уровень";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(13, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 54);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel4.Controls.Add(this.rec10);
            this.panel4.Controls.Add(this.label31);
            this.panel4.Controls.Add(this.rec9);
            this.panel4.Controls.Add(this.label33);
            this.panel4.Controls.Add(this.rec8);
            this.panel4.Controls.Add(this.label35);
            this.panel4.Controls.Add(this.rec7);
            this.panel4.Controls.Add(this.label37);
            this.panel4.Controls.Add(this.rec6);
            this.panel4.Controls.Add(this.label39);
            this.panel4.Controls.Add(this.rec5);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.rec4);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.rec3);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.rec2);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.rec1);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(13, 427);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 184);
            this.panel4.TabIndex = 17;
            // 
            // rec10
            // 
            this.rec10.AutoSize = true;
            this.rec10.Location = new System.Drawing.Point(120, 130);
            this.rec10.Name = "rec10";
            this.rec10.Size = new System.Drawing.Size(0, 13);
            this.rec10.TabIndex = 20;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(99, 130);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(25, 13);
            this.label31.TabIndex = 19;
            this.label31.Text = "10. ";
            // 
            // rec9
            // 
            this.rec9.AutoSize = true;
            this.rec9.Location = new System.Drawing.Point(120, 110);
            this.rec9.Name = "rec9";
            this.rec9.Size = new System.Drawing.Size(0, 13);
            this.rec9.TabIndex = 18;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(105, 110);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(16, 13);
            this.label33.TabIndex = 17;
            this.label33.Text = "9.";
            // 
            // rec8
            // 
            this.rec8.AutoSize = true;
            this.rec8.Location = new System.Drawing.Point(120, 90);
            this.rec8.Name = "rec8";
            this.rec8.Size = new System.Drawing.Size(0, 13);
            this.rec8.TabIndex = 16;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(105, 90);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(16, 13);
            this.label35.TabIndex = 15;
            this.label35.Text = "8.";
            // 
            // rec7
            // 
            this.rec7.AutoSize = true;
            this.rec7.Location = new System.Drawing.Point(120, 70);
            this.rec7.Name = "rec7";
            this.rec7.Size = new System.Drawing.Size(0, 13);
            this.rec7.TabIndex = 14;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(105, 70);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(16, 13);
            this.label37.TabIndex = 13;
            this.label37.Text = "7.";
            // 
            // rec6
            // 
            this.rec6.AutoSize = true;
            this.rec6.Location = new System.Drawing.Point(120, 50);
            this.rec6.Name = "rec6";
            this.rec6.Size = new System.Drawing.Size(0, 13);
            this.rec6.TabIndex = 12;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(105, 50);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(19, 13);
            this.label39.TabIndex = 11;
            this.label39.Text = "6. ";
            // 
            // rec5
            // 
            this.rec5.AutoSize = true;
            this.rec5.Location = new System.Drawing.Point(45, 130);
            this.rec5.Name = "rec5";
            this.rec5.Size = new System.Drawing.Size(0, 13);
            this.rec5.TabIndex = 10;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(30, 130);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(19, 13);
            this.label27.TabIndex = 9;
            this.label27.Text = "5. ";
            // 
            // rec4
            // 
            this.rec4.AutoSize = true;
            this.rec4.Location = new System.Drawing.Point(45, 110);
            this.rec4.Name = "rec4";
            this.rec4.Size = new System.Drawing.Size(0, 13);
            this.rec4.TabIndex = 8;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(30, 110);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(16, 13);
            this.label29.TabIndex = 7;
            this.label29.Text = "4.";
            // 
            // rec3
            // 
            this.rec3.AutoSize = true;
            this.rec3.Location = new System.Drawing.Point(45, 90);
            this.rec3.Name = "rec3";
            this.rec3.Size = new System.Drawing.Size(0, 13);
            this.rec3.TabIndex = 6;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(30, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 5;
            this.label25.Text = "3.";
            // 
            // rec2
            // 
            this.rec2.AutoSize = true;
            this.rec2.Location = new System.Drawing.Point(45, 70);
            this.rec2.Name = "rec2";
            this.rec2.Size = new System.Drawing.Size(0, 13);
            this.rec2.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(30, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 13);
            this.label23.TabIndex = 3;
            this.label23.Text = "2.";
            // 
            // rec1
            // 
            this.rec1.AutoSize = true;
            this.rec1.Location = new System.Drawing.Point(45, 50);
            this.rec1.Name = "rec1";
            this.rec1.Size = new System.Drawing.Size(0, 13);
            this.rec1.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "1. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(55, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Рекорды:";
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 623);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Тетрис";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _points;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _level;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lines;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label rec10;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label rec9;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label rec8;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label rec7;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label rec6;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label rec5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label rec4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label rec3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label rec2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label rec1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
    }
}