namespace KUN_AT3
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumberOfKUN = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фаилToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrinterSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EngineNum4 = new System.Windows.Forms.TextBox();
            this.EngineNum3 = new System.Windows.Forms.TextBox();
            this.EngineNum2 = new System.Windows.Forms.TextBox();
            this.EngineNum1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumBoardAircraft5 = new System.Windows.Forms.TextBox();
            this.NumBoardAircraft4 = new System.Windows.Forms.TextBox();
            this.NumBoardAircraft3 = new System.Windows.Forms.TextBox();
            this.NumBoardAircraft2 = new System.Windows.Forms.TextBox();
            this.NumBoardAircraft1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DateOfKUN = new System.Windows.Forms.DateTimePicker();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumberOfKUN
            // 
            this.NumberOfKUN.Location = new System.Drawing.Point(412, 27);
            this.NumberOfKUN.MaxLength = 4;
            this.NumberOfKUN.Name = "NumberOfKUN";
            this.NumberOfKUN.Size = new System.Drawing.Size(35, 20);
            this.NumberOfKUN.TabIndex = 0;
            this.NumberOfKUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOfKUN_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фаилToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фаилToolStripMenuItem
            // 
            this.фаилToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.PrinterSetup,
            this.выходToolStripMenuItem});
            this.фаилToolStripMenuItem.Name = "фаилToolStripMenuItem";
            this.фаилToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.фаилToolStripMenuItem.Text = "Фаил";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // PrinterSetup
            // 
            this.PrinterSetup.Name = "PrinterSetup";
            this.PrinterSetup.Size = new System.Drawing.Size(132, 22);
            this.PrinterSetup.Text = "Печать";
            this.PrinterSetup.Click += new System.EventHandler(this.PrinterSetupToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Карточка учета неисправности авиатехники №";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(50, 16);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(33, 13);
            this.Date.TabIndex = 3;
            this.Date.Text = "Дата";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EngineNum4);
            this.groupBox1.Controls.Add(this.EngineNum3);
            this.groupBox1.Controls.Add(this.EngineNum2);
            this.groupBox1.Controls.Add(this.EngineNum1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NumBoardAircraft5);
            this.groupBox1.Controls.Add(this.NumBoardAircraft4);
            this.groupBox1.Controls.Add(this.NumBoardAircraft3);
            this.groupBox1.Controls.Add(this.NumBoardAircraft2);
            this.groupBox1.Controls.Add(this.NumBoardAircraft1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DateOfKUN);
            this.groupBox1.Controls.Add(this.Date);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // EngineNum4
            // 
            this.EngineNum4.Location = new System.Drawing.Point(472, 33);
            this.EngineNum4.Name = "EngineNum4";
            this.EngineNum4.Size = new System.Drawing.Size(18, 20);
            this.EngineNum4.TabIndex = 9;
            // 
            // EngineNum3
            // 
            this.EngineNum3.Location = new System.Drawing.Point(448, 33);
            this.EngineNum3.Name = "EngineNum3";
            this.EngineNum3.Size = new System.Drawing.Size(18, 20);
            this.EngineNum3.TabIndex = 9;
            // 
            // EngineNum2
            // 
            this.EngineNum2.Location = new System.Drawing.Point(424, 33);
            this.EngineNum2.Name = "EngineNum2";
            this.EngineNum2.Size = new System.Drawing.Size(18, 20);
            this.EngineNum2.TabIndex = 9;
            // 
            // EngineNum1
            // 
            this.EngineNum1.Location = new System.Drawing.Point(400, 33);
            this.EngineNum1.Name = "EngineNum1";
            this.EngineNum1.Size = new System.Drawing.Size(18, 20);
            this.EngineNum1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Аэропорт посадки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Предприятие владелец ВС";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "№ двигателя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Тип ВС";
            // 
            // NumBoardAircraft5
            // 
            this.NumBoardAircraft5.Location = new System.Drawing.Point(244, 33);
            this.NumBoardAircraft5.MaxLength = 1;
            this.NumBoardAircraft5.Name = "NumBoardAircraft5";
            this.NumBoardAircraft5.Size = new System.Drawing.Size(16, 20);
            this.NumBoardAircraft5.TabIndex = 6;
            this.NumBoardAircraft5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumBoardAircraft1_KeyPress);
            this.NumBoardAircraft5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumBoardAircraft5_KeyUp);
            // 
            // NumBoardAircraft4
            // 
            this.NumBoardAircraft4.Location = new System.Drawing.Point(222, 33);
            this.NumBoardAircraft4.MaxLength = 1;
            this.NumBoardAircraft4.Name = "NumBoardAircraft4";
            this.NumBoardAircraft4.Size = new System.Drawing.Size(16, 20);
            this.NumBoardAircraft4.TabIndex = 6;
            this.NumBoardAircraft4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumBoardAircraft1_KeyPress);
            this.NumBoardAircraft4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumBoardAircraft4_KeyUp);
            // 
            // NumBoardAircraft3
            // 
            this.NumBoardAircraft3.Location = new System.Drawing.Point(200, 33);
            this.NumBoardAircraft3.MaxLength = 1;
            this.NumBoardAircraft3.Name = "NumBoardAircraft3";
            this.NumBoardAircraft3.Size = new System.Drawing.Size(16, 20);
            this.NumBoardAircraft3.TabIndex = 6;
            this.NumBoardAircraft3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumBoardAircraft1_KeyPress);
            this.NumBoardAircraft3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumBoardAircraft3_KeyUp);
            // 
            // NumBoardAircraft2
            // 
            this.NumBoardAircraft2.Location = new System.Drawing.Point(179, 33);
            this.NumBoardAircraft2.MaxLength = 1;
            this.NumBoardAircraft2.Name = "NumBoardAircraft2";
            this.NumBoardAircraft2.Size = new System.Drawing.Size(16, 20);
            this.NumBoardAircraft2.TabIndex = 6;
            this.NumBoardAircraft2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumBoardAircraft1_KeyPress);
            this.NumBoardAircraft2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumBoardAircraft2_KeyUp);
            // 
            // NumBoardAircraft1
            // 
            this.NumBoardAircraft1.Location = new System.Drawing.Point(157, 33);
            this.NumBoardAircraft1.MaxLength = 1;
            this.NumBoardAircraft1.Name = "NumBoardAircraft1";
            this.NumBoardAircraft1.Size = new System.Drawing.Size(16, 20);
            this.NumBoardAircraft1.TabIndex = 6;
            this.NumBoardAircraft1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumBoardAircraft1_KeyPress);
            this.NumBoardAircraft1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumBoardAircraft1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Борт № ВС";
            // 
            // DateOfKUN
            // 
            this.DateOfKUN.Location = new System.Drawing.Point(7, 33);
            this.DateOfKUN.Name = "DateOfKUN";
            this.DateOfKUN.Size = new System.Drawing.Size(120, 20);
            this.DateOfKUN.TabIndex = 4;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 521);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberOfKUN);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumberOfKUN;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фаилToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NumBoardAircraft1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateOfKUN;
        private System.Windows.Forms.TextBox NumBoardAircraft5;
        private System.Windows.Forms.TextBox NumBoardAircraft4;
        private System.Windows.Forms.TextBox NumBoardAircraft3;
        private System.Windows.Forms.TextBox NumBoardAircraft2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem PrinterSetup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EngineNum4;
        private System.Windows.Forms.TextBox EngineNum3;
        private System.Windows.Forms.TextBox EngineNum2;
        private System.Windows.Forms.TextBox EngineNum1;
    }
}

