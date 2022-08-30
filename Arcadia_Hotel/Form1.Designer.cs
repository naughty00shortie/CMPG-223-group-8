namespace Arcadia_Hotel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMenu = new System.Windows.Forms.TabPage();
            this.tpReservation = new System.Windows.Forms.TabPage();
            this.tpChangeReservation = new System.Windows.Forms.TabPage();
            this.tpAdmin = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMakeR = new System.Windows.Forms.Button();
            this.btnEditR = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddR = new System.Windows.Forms.Button();
            this.btnBackMR = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lbBookingInfo = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpMenu.SuspendLayout();
            this.tpReservation.SuspendLayout();
            this.tpChangeReservation.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMenu);
            this.tabControl1.Controls.Add(this.tpReservation);
            this.tabControl1.Controls.Add(this.tpChangeReservation);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpAdmin);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1112, 613);
            this.tabControl1.TabIndex = 0;
            // 
            // tpMenu
            // 
            this.tpMenu.Controls.Add(this.button5);
            this.tpMenu.Controls.Add(this.btnExit);
            this.tpMenu.Controls.Add(this.btnAdmin);
            this.tpMenu.Controls.Add(this.btnEditR);
            this.tpMenu.Controls.Add(this.btnMakeR);
            this.tpMenu.Location = new System.Drawing.Point(4, 22);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpMenu.Size = new System.Drawing.Size(1104, 587);
            this.tpMenu.TabIndex = 0;
            this.tpMenu.Text = "Menu";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // tpReservation
            // 
            this.tpReservation.Controls.Add(this.panel2);
            this.tpReservation.Controls.Add(this.panel1);
            this.tpReservation.Controls.Add(this.btnBackMR);
            this.tpReservation.Controls.Add(this.btnAddR);
            this.tpReservation.Location = new System.Drawing.Point(4, 22);
            this.tpReservation.Name = "tpReservation";
            this.tpReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tpReservation.Size = new System.Drawing.Size(1104, 587);
            this.tpReservation.TabIndex = 1;
            this.tpReservation.Text = "Make Reservation";
            this.tpReservation.UseVisualStyleBackColor = true;
            // 
            // tpChangeReservation
            // 
            this.tpChangeReservation.Controls.Add(this.button2);
            this.tpChangeReservation.Location = new System.Drawing.Point(4, 22);
            this.tpChangeReservation.Name = "tpChangeReservation";
            this.tpChangeReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tpChangeReservation.Size = new System.Drawing.Size(1104, 587);
            this.tpChangeReservation.TabIndex = 2;
            this.tpChangeReservation.Text = "Edit Reservation";
            this.tpChangeReservation.UseVisualStyleBackColor = true;
            // 
            // tpAdmin
            // 
            this.tpAdmin.Controls.Add(this.button3);
            this.tpAdmin.Controls.Add(this.label3);
            this.tpAdmin.Controls.Add(this.button1);
            this.tpAdmin.Controls.Add(this.label2);
            this.tpAdmin.Controls.Add(this.label1);
            this.tpAdmin.Controls.Add(this.textBox1);
            this.tpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tpAdmin.Name = "tpAdmin";
            this.tpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdmin.Size = new System.Drawing.Size(1104, 587);
            this.tpAdmin.TabIndex = 3;
            this.tpAdmin.Text = "Admin";
            this.tpAdmin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Admin gaan Maintain Employees, Maintain Roles en Maintain Rooms";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Admin Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin Sign-in:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(420, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnMakeR
            // 
            this.btnMakeR.Location = new System.Drawing.Point(31, 29);
            this.btnMakeR.Name = "btnMakeR";
            this.btnMakeR.Size = new System.Drawing.Size(163, 65);
            this.btnMakeR.TabIndex = 0;
            this.btnMakeR.Text = "Make Reservation";
            this.btnMakeR.UseVisualStyleBackColor = true;
            // 
            // btnEditR
            // 
            this.btnEditR.Location = new System.Drawing.Point(31, 117);
            this.btnEditR.Name = "btnEditR";
            this.btnEditR.Size = new System.Drawing.Size(163, 65);
            this.btnEditR.TabIndex = 1;
            this.btnEditR.Text = "Edit Reservation";
            this.btnEditR.UseVisualStyleBackColor = true;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(31, 292);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(163, 65);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(31, 478);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 41);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAddR
            // 
            this.btnAddR.Location = new System.Drawing.Point(131, 420);
            this.btnAddR.Name = "btnAddR";
            this.btnAddR.Size = new System.Drawing.Size(128, 57);
            this.btnAddR.TabIndex = 0;
            this.btnAddR.Text = "Add Reservation";
            this.btnAddR.UseVisualStyleBackColor = true;
            // 
            // btnBackMR
            // 
            this.btnBackMR.Location = new System.Drawing.Point(1024, 543);
            this.btnBackMR.Name = "btnBackMR";
            this.btnBackMR.Size = new System.Drawing.Size(77, 36);
            this.btnBackMR.TabIndex = 1;
            this.btnBackMR.Text = "Back";
            this.btnBackMR.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1019, 543);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(985, 501);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(37, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 315);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.lbBookingInfo);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.monthCalendar2);
            this.panel2.Controls.Add(this.monthCalendar1);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(421, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 499);
            this.panel2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Guest Information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Booking Information";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(162, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Surname:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Name:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(162, 96);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(116, 20);
            this.textBox3.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Email:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Phone Number:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(162, 170);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(116, 20);
            this.textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(162, 238);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(116, 20);
            this.textBox5.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(235, 462);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Price:";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(275, 459);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(102, 20);
            this.textBox6.TabIndex = 9;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(49, 275);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 10;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(363, 275);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Check In:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(388, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Check Out:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Select Room Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // sqliteCommand1
            // 
            this.sqliteCommand1.CommandTimeout = 30;
            this.sqliteCommand1.Connection = null;
            this.sqliteCommand1.Transaction = null;
            this.sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(360, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Room Amount:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(443, 39);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown1.TabIndex = 17;
            // 
            // lbBookingInfo
            // 
            this.lbBookingInfo.FormattingEnabled = true;
            this.lbBookingInfo.Location = new System.Drawing.Point(204, 170);
            this.lbBookingInfo.Name = "lbBookingInfo";
            this.lbBookingInfo.Size = new System.Drawing.Size(202, 69);
            this.lbBookingInfo.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(201, 147);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Booking Info:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(238, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 43);
            this.button4.TabIndex = 20;
            this.button4.Text = "Add Room To Booking";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1104, 587);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Edit Personal Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 207);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 65);
            this.button5.TabIndex = 4;
            this.button5.Text = "Edit Guest Personal Info";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 613);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Arcadia Hotel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpMenu.ResumeLayout(false);
            this.tpReservation.ResumeLayout(false);
            this.tpChangeReservation.ResumeLayout(false);
            this.tpAdmin.ResumeLayout(false);
            this.tpAdmin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMenu;
        private System.Windows.Forms.TabPage tpReservation;
        private System.Windows.Forms.TabPage tpChangeReservation;
        private System.Windows.Forms.TabPage tpAdmin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnEditR;
        private System.Windows.Forms.Button btnMakeR;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBackMR;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lbBookingInfo;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label14;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

