namespace diplom
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
            this.BrowseB = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewTextB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // BrowseB
            // 
            this.BrowseB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseB.BackgroundImage")));
            this.BrowseB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BrowseB.Location = new System.Drawing.Point(50, 10);
            this.BrowseB.Name = "BrowseB";
            this.BrowseB.Size = new System.Drawing.Size(32, 32);
            this.BrowseB.TabIndex = 1;
            this.toolTip1.SetToolTip(this.BrowseB, "Открыть фоновое изображение");
            this.BrowseB.UseVisualStyleBackColor = true;
            this.BrowseB.Click += new System.EventHandler(this.browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 859);
            this.panel1.TabIndex = 2;
            // 
            // NewTextB
            // 
            this.NewTextB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewTextB.BackgroundImage")));
            this.NewTextB.Location = new System.Drawing.Point(88, 10);
            this.NewTextB.Name = "NewTextB";
            this.NewTextB.Size = new System.Drawing.Size(32, 32);
            this.NewTextB.TabIndex = 3;
            this.toolTip1.SetToolTip(this.NewTextB, "Добавить текст");
            this.NewTextB.UseVisualStyleBackColor = true;
            this.NewTextB.Click += new System.EventHandler(this.newText_Click);
            // 
            // saveB
            // 
            this.saveB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveB.BackgroundImage")));
            this.saveB.Location = new System.Drawing.Point(12, 10);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(32, 32);
            this.saveB.TabIndex = 6;
            this.toolTip1.SetToolTip(this.saveB, "Сохранить как изображение");
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(126, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 7;
            this.toolTip1.SetToolTip(this.button1, "Изменить цвет фона");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(164, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button2, "Удалить картинку");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Location = new System.Drawing.Point(240, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button3, "Справка");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.Location = new System.Drawing.Point(202, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 32);
            this.button4.TabIndex = 10;
            this.toolTip1.SetToolTip(this.button4, "Печать");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 921);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.NewTextB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BrowseB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Конструктор рекламных материалов";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BrowseB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NewTextB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}

