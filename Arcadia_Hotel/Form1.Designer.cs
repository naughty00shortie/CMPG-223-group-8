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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpChangeReservation.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMenu);
            this.tabControl1.Controls.Add(this.tpReservation);
            this.tabControl1.Controls.Add(this.tpChangeReservation);
            this.tabControl1.Controls.Add(this.tpAdmin);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1387, 792);
            this.tabControl1.TabIndex = 0;
            // 
            // tpMenu
            // 
            this.tpMenu.Location = new System.Drawing.Point(4, 22);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpMenu.Size = new System.Drawing.Size(1379, 766);
            this.tpMenu.TabIndex = 0;
            this.tpMenu.Text = "Menu";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // tpReservation
            // 
            this.tpReservation.Location = new System.Drawing.Point(4, 22);
            this.tpReservation.Name = "tpReservation";
            this.tpReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tpReservation.Size = new System.Drawing.Size(1379, 766);
            this.tpReservation.TabIndex = 1;
            this.tpReservation.Text = "Make Reservation";
            this.tpReservation.UseVisualStyleBackColor = true;
            // 
            // tpChangeReservation
            // 
            this.tpChangeReservation.Controls.Add(this.label4);
            this.tpChangeReservation.Location = new System.Drawing.Point(4, 22);
            this.tpChangeReservation.Name = "tpChangeReservation";
            this.tpChangeReservation.Padding = new System.Windows.Forms.Padding(3);
            this.tpChangeReservation.Size = new System.Drawing.Size(1379, 766);
            this.tpChangeReservation.TabIndex = 2;
            this.tpChangeReservation.Text = "Edit Reservation";
            this.tpChangeReservation.UseVisualStyleBackColor = true;
            // 
            // tpAdmin
            // 
            this.tpAdmin.Controls.Add(this.label3);
            this.tpAdmin.Controls.Add(this.button1);
            this.tpAdmin.Controls.Add(this.label2);
            this.tpAdmin.Controls.Add(this.label1);
            this.tpAdmin.Controls.Add(this.textBox1);
            this.tpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tpAdmin.Name = "tpAdmin";
            this.tpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdmin.Size = new System.Drawing.Size(1379, 766);
            this.tpAdmin.TabIndex = 3;
            this.tpAdmin.Text = "Admin";
            this.tpAdmin.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(420, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Admin Password";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Admin gaan Maintain Employees, Maintain Roles en Maintain Rooms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hier gaan Maintain Booking en Maintain Guest wees";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 792);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Arcadia Hotel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpChangeReservation.ResumeLayout(false);
            this.tpChangeReservation.PerformLayout();
            this.tpAdmin.ResumeLayout(false);
            this.tpAdmin.PerformLayout();
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
        private System.Windows.Forms.Label label4;
    }
}

