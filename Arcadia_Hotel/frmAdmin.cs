﻿using System;                                                                                                                                                                                                                                      
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcadia_Hotel_DB;
using DGVPrinterHelper;

namespace Arcadia_Hotel
{
    public partial class frmAdmin : Form
    {
        List<BookingModel> bookings = new List<BookingModel>();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<GuestModel> guests = new List<GuestModel>();
        List<RoleModel> roles = new List<RoleModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void LoadModels()
        {
            bookings = DataAccess.loadBooking();
            employees = DataAccess.loadEmployee();
            guests = DataAccess.loadGuest();
            roles = DataAccess.loadRole();
            rooms = DataAccess.loadRoom();

            dgvAddRoom.DataSource = rooms;
            cmbRoleIDDR.Items.Clear();
            cmbRoleIDAE.Items.Clear();
            cmbRoleUR.Items.Clear();
            comboBox2.Items.Clear();

            cmbCategorizeRoomSize.Items.Clear();
            cmbCategorizeRole.Items.Clear();
            cmbCategorizeRole.Items.Add("All");
            foreach (var role in roles)
            {
                cmbRoleIDAE.Items.Add(role.Role_ID);
                cmbRoleIDDR.Items.Add(role.Role_ID);
                cmbRoleUR.Items.Add(role.Role_ID);
                comboBox2.Items.Add(role.Role_ID);               
                cmbCategorizeRole.Items.Add(role.Role_Description);
            }           

            dgvRoleAR.DataSource = roles;
            dgvAddEmployee.DataSource = employees;
            dgvRoleEmployee.DataSource = roles;

            cmbRoomID.Items.Clear();
            cmbID.Items.Clear();
            cmbCategorizeRoomSize.Items.Clear();
            cmbCategorizeRoomSize.Items.Add("All");
            foreach (var room in rooms)
            {
                cmbRoomID.Items.Add(room.Room_Number);
                cmbID.Items.Add(room.Room_Number);
            }

            dgvDeleteRoom.DataSource = rooms;

            comboBox1.Items.Clear();
            cmbEmployeeIDUE.Items.Clear();
            cmbAdminName.Items.Clear();
            foreach (var employee in employees)
            {
                comboBox1.Items.Add(employee.Employee_ID);
                cmbEmployeeIDUE.Items.Add(employee.Employee_ID);
                foreach (var role in roles)
                {
                    if (employee.Role_ID == role.Role_ID && role.Role_Description == "Admin")
                        cmbAdminName.Items.Add(employee.Employee_Name + " " + employee.Employee_Surname);
                }
            }
            dgvDeleteEmployee.DataSource = employees;

            

            dgvRoleDR.DataSource = roles;
            dgvRoleUR.DataSource = roles;
            dgvRoomUpdate.DataSource = rooms;

            dataGridView1.DataSource = employees;
            dataGridView2.DataSource = roles;

            List<RoomModel> uniqueRooms = DataAccess.loadUniqueRoom();
            foreach (RoomModel room in uniqueRooms)
            {
                cmbCategorizeRoomSize.Items.Add(room.Room_Size);
            }

            

        }

        private Form1 form1;
        public frmAdmin(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }



        private void deleteRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 3;
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadModels();


            // Tab Control Make Visible
            xuiFlatTab1.Appearance = TabAppearance.FlatButtons;
            xuiFlatTab1.ItemSize = new Size(0, 1);
            xuiFlatTab1.SizeMode = TabSizeMode.Fixed;
            xuiFlatTab1.ActiveTextColor = Color.FromArgb(60, 60, 60);
            xuiFlatTab1.InActiveTextColor = Color.FromArgb(60, 60, 60);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            RoomModel room = new RoomModel();

            if(txtRoomDescription.Text == "")
            {
                MessageBox.Show("Enter Room Description", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtRoomSize.Text == "")
            {
                MessageBox.Show("Enter Room Size", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtRoomPrice.Text == "")
            {
                MessageBox.Show("Enter Room Price", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtRoomPrice.Text, out decimal yeet))
            {
                MessageBox.Show("Invalid Price", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            room.Room_Description = txtRoomDescription.Text;
            room.Room_Size = txtRoomSize.Text;
            room.Room_Price_Per_Night = decimal.Parse(txtRoomPrice.Text);

            DataAccess.insertRoom(room);
            LoadModels();

        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            RoleModel role = new RoleModel();
            
            if(cmbRoleUR.SelectedItem == null)
            {
                MessageBox.Show("Select a Role", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cmbRoleUR.Text == "")
            {
                MessageBox.Show("Enter Role ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtDescriptionRU.Text == "")
            {
                MessageBox.Show("Enter Role Description", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtSalaryUR.Text == "")
            {
                MessageBox.Show("Enter Role Salary", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtHoursUR.Text == "")
            {
                MessageBox.Show("Enter Role Hours", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            role.Role_ID = int.Parse(cmbRoleUR.Text);
            role.Role_Description = txtDescriptionRU.Text;
            role.Role_Salary = decimal.Parse(txtSalaryUR.Text);
            role.Role_Hours_Per_Day = int.Parse(txtHoursUR.Text);

            DataAccess.updateRole(role);
            LoadModels();
            cmbRoleUR.Text = "";

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
           EmployeeModel employee = new EmployeeModel();
            
            if(cmbRoleIDAE.SelectedItem == null)
            {
                MessageBox.Show("Select a Role", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cmbRoleIDAE.Text == "")
            {
                MessageBox.Show("Select Role", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtSurnameAE.Text == "")
            {
                MessageBox.Show("Enter Employee Surname", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtNameAE.Text == "")
            {
                MessageBox.Show("Enter Employee Name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtEmailAE.Text == "")
            {
                MessageBox.Show("Enter Employee Email", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dtpBirthDateAE.Text == "")
            {
                MessageBox.Show("Enter Employee Date of Birth", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           employee.Role_ID = int.Parse(cmbRoleIDAE.Text);
           employee.Employee_Surname = txtSurnameAE.Text;
           employee.Employee_Name = txtNameAE.Text; 
           employee.Employee_Email = txtEmailAE.Text;
           employee.Employee_Date_Of_Birth = DateTime.Parse(dtpBirthDateAE.Text) ;

           DataAccess.insertEmployee(employee);
           LoadModels();
        }

        private void btnAddRole_Click(object sender, EventArgs e)////////////papi wenjo
        {
            RoleModel role = new RoleModel();

            if(redRoleDescription.Text == "")
            {
                MessageBox.Show("Enter Role Description", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtSalaryAR.Text == "")
            {
                MessageBox.Show("Enter Role Salary", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtHoursAR.Text == "")
            {
                MessageBox.Show("Enter Role Hours", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!decimal.TryParse(txtSalaryAR.Text, out decimal yeet))
            {
                MessageBox.Show("invalid Salary", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtHoursAR.Text, out int yoot))
            {
                MessageBox.Show("invalid Salary", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            role.Role_Description = redRoleDescription.Text;
            role.Role_Salary = decimal.Parse(txtSalaryAR.Text);
            role.Role_Hours_Per_Day = int.Parse(txtHoursAR.Text);

            DataAccess.insertRole(role);
            LoadModels();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (cmbRoomID.SelectedItem == null)
            {
                MessageBox.Show("Room ID invalid", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            foreach (var booking in bookings)
            {
                if (booking.Room_Number == int.Parse(cmbRoomID.Text))
                {
                    MessageBox.Show("Room is Restricted and cannot be deleted", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataAccess.deleteRoom(int.Parse(cmbRoomID.Text));
            LoadModels();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Invalid combobox", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            DataAccess.deleteEmployee(int.Parse(comboBox1.Text));
            LoadModels();
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if(cmbID.SelectedItem == null)
            {
                MessageBox.Show("Select a ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(cmbID.Text == "")
            {
                MessageBox.Show("Enter Room number", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox7.Text == "")
            {
                MessageBox.Show("Enter Room Description", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtSizeUR.Text == "")
            {
                MessageBox.Show("Enter Room size", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPriceUR.Text == "")
            {
                MessageBox.Show("Enter Room Price", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPriceUR.Text, out decimal yeet))
            {
                MessageBox.Show("Enter Room Price", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RoomModel room = new RoomModel();
            room.Room_Number = int.Parse(cmbID.Text);
            room.Room_Description = textBox7.Text;
            room.Room_Size = txtSizeUR.Text;
            room.Room_Price_Per_Night = decimal.Parse(txtPriceUR.Text);
            DataAccess.updateRoom(room);
            LoadModels();
            cmbID.Text = "";
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {

            if(cmbRoleIDDR.SelectedItem == null)
            {
                MessageBox.Show("Select a ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var employee in employees)
            {
                if (employee.Role_ID == int.Parse(cmbRoleIDDR.Text))
                {
                    MessageBox.Show("Role is Restricted. Cannot be deleted", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataAccess.deleteRole(int.Parse(cmbRoleIDDR.Text));
            LoadModels();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (cmbEmployeeIDUE.SelectedItem == null)
            {
                MessageBox.Show("Select a Employee ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Select Role ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(cmbEmployeeIDUE.Text == "")
            {
                MessageBox.Show("Enter Employee ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox4.Text == "")
            {
                MessageBox.Show("Enter Employee Surname", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox5.Text == "")
            {
                MessageBox.Show("Enter Employee Name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(comboBox2.Text == "")
            {
                MessageBox.Show("Select Role ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dateTimePicker1.Text == "")
            {
                MessageBox.Show("Enter Employee Date of Birth", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox6.Text == "")
            {
                MessageBox.Show("Enter Employee Email", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            EmployeeModel employee = new EmployeeModel();
            employee.Employee_ID = int.Parse(cmbEmployeeIDUE.Text);
            employee.Employee_Surname = textBox4.Text;
            employee.Employee_Name = textBox5.Text;
            employee.Role_ID = int.Parse(comboBox2.Text);
            employee.Employee_Date_Of_Birth = DateTime.Parse(dateTimePicker1.Text);
            employee.Employee_Email = textBox6.Text;
            DataAccess.updateEmployee(employee);

            LoadModels();
            cmbEmployeeIDUE.Text = "";
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #region MenuStrip

        private void xuiButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 10;
        }

        private void backToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void addRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 0;
        }

        private void updateRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 6;
        }

        private void hireEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 1;
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 8;
        }

        private void removeEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 4;
        }

        private void addRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 2;
        }

        private void updateRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 7;
        }

        private void removeRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 5;
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xuiFlatTab1.SelectedIndex = 9;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var room in rooms)
                if (room.Room_Number == int.Parse(cmbID.Text))
                {
                    textBox7.Text = room.Room_Description;
                    txtSizeUR.Text = room.Room_Size;
                    txtPriceUR.Text = room.Room_Price_Per_Night.ToString();
                    return;
                }
        }

        private void cmbRoleUR_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var role in roles)
                if (role.Role_ID == int.Parse(cmbRoleUR.Text))
                {
                    txtDescriptionRU.Text = role.Role_Description;
                    txtSalaryUR.Text = role.Role_Salary.ToString();
                    txtHoursUR.Text = role.Role_Hours_Per_Day.ToString();
                    return;
                }
        }

        private void cmbEmployeeIDUE_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var employee in employees)
                if (employee.Employee_ID == int.Parse(cmbEmployeeIDUE.Text))
                {
                    textBox4.Text = employee.Employee_Surname;
                    textBox5.Text = employee.Employee_Name;
                    comboBox2.Text = employee.Role_ID.ToString();
                    dateTimePicker1.Text = employee.Employee_Date_Of_Birth.ToString();
                    textBox6.Text = employee.Employee_Email;

                }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            // Info
            DGVPrinter printer = new DGVPrinter();
            string sReport = cmbReportType.Text;
            string sAdminName = cmbAdminName.Text;
            string sReportName = txtReportName.Text;
            string sSubtitle = "";
            string sFooter = "";

            DataTable dt = new DataTable();


            // Check if text boxes is written in
            if (cmbAdminName.Text == "")
            {
                MessageBox.Show("Select admin name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtReportName.Text == "")
            {
                MessageBox.Show("Enter the report name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Create Report

            string dToday = DateTime.Today.ToString("yyyy-MM-dd");
            string dLastMonth = DateTime.Parse(dToday).AddMonths(-1).ToString("yyyy-MM-dd");




            if (sReport == "Room")                  // Room report sql
            {
                printer.Title = "Room Price Report of the Month";

                if (cmbCategorizeRoomSize.Text == "All")
                {
                    dt = DataAccess.queryReport($"SELECT R.Room_Description, R.Room_Price_Per_Night, COUNT(B.Room_Number) AS 'Guests', SUM(R.Room_Price_Per_Night) AS 'Total money received' FROM Room R, Booking B WHERE R.Room_Number = B.Room_Number AND B.Booking_Check_Out  BETWEEN '{DateTime.Parse(dLastMonth)}' AND '{DateTime.Parse(dToday)}' GROUP BY R.Room_Description, R.Room_Price_Per_Night ORDER BY R.Room_Price_Per_Night DESC");
                    sSubtitle += "Room size used in report: All\n";
                }
                   
                else if (cmbCategorizeRoomSize.Text == "")
                {
                    MessageBox.Show("Select a categorize option", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    dt = DataAccess.queryReport($"SELECT R.Room_Description, R.Room_Price_Per_Night, COUNT(B.Room_Number) AS 'Guests', SUM(R.Room_Price_Per_Night) AS 'Total money received' FROM Room R, Booking B WHERE R.Room_Number = B.Room_Number AND R.Room_Size = '{cmbCategorizeRoomSize.Text}' AND B.Booking_Check_Out  BETWEEN '{DateTime.Parse(dLastMonth)}' AND '{DateTime.Parse(dToday)}' GROUP BY R.Room_Description, R.Room_Price_Per_Night ORDER BY R.Room_Price_Per_Night DESC");
                    sSubtitle += "Room size used in report: " + cmbCategorizeRoomSize.Text + "\n";
                }
                   
            }
            else if (sReport == "Employee")             // Employee report sql
            {
                printer.Title = "Employee Report";

                if (cmbCategorizeRole.Text == "All")
                    dt = DataAccess.queryReport("SELECT E.Employee_Surname, E.Employee_Name, R.Role_Description, E.Employee_Email, R.Role_Salary FROM Employee E, Role R WHERE E.Role_ID = R.Role_ID ORDER BY R.Role_Salary DESC");
                else if (cmbCategorizeRole.Text == "")
                {
                    MessageBox.Show("Select a categorize option", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    dt = DataAccess.queryReport($"SELECT E.Employee_Surname, E.Employee_Name, R.Role_Description, E.Employee_Email, R.Role_Salary FROM Employee E, Role R WHERE E.Role_ID = R.Role_ID AND R.Role_Description = '{cmbCategorizeRole.Text}' ORDER BY R.Role_Salary DESC");
            }
            else
            {
                MessageBox.Show("Select a report", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView3.DataSource = dt;

            if (cbPageNumbers.Checked)          // Add numbers to report
            {
                printer.PageNumbers = true;
                printer.PageNumberInHeader = true;
            }

            if (cbDate.Checked)                // Add date to report
                sSubtitle += DateTime.Now.ToString("d") + "\n";

            if (cbReportName.Checked)           // Add Report name to report
                sSubtitle += sReportName + "\n";

            if (cbUserName.Checked)         // Add admin who pulled report to report
                sSubtitle += sAdminName + "\n";

            // Get summary info
            double dTotal = 0.00;
            double dMax = 0.00;
            double dMin = 5000.00;

            if(sReport == "Room")
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dTotal += double.Parse(dt.Rows[i][3].ToString());
                    if (double.Parse(dt.Rows[i][3].ToString()) <= dMin)
                        dMin = double.Parse(dt.Rows[i][3].ToString());
                    if (double.Parse(dt.Rows[i][3].ToString()) >= dMax)
                        dMax = double.Parse(dt.Rows[i][3].ToString());
                }


                 if (cbSummation.Checked)
                     sFooter += "Sum of total money received:\t" + dTotal.ToString() + "\n";

                 if (cbShowMax.Checked)
                     sFooter += "Max money received from single room:\t" + dMax.ToString() + "\n";

                 if (cbShowMinimum.Checked)
                     sFooter += "Min money received from single room:\t" + dMin.ToString() + "\n";
            }

            else if (sReport == "Employee")
            {
                string sHighest = "";
                string sLowest = cmbCategorizeRole.Text;
                string sKeep = "";


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    sKeep = dt.Rows[i][2].ToString();


                    dTotal += double.Parse(dt.Rows[i][4].ToString());

                    if (double.Parse(dt.Rows[i][4].ToString()) <= dMin)
                    {
                        dMin = double.Parse(dt.Rows[i][4].ToString());
                        sLowest = sKeep;
                    }
                    else if (double.Parse(dt.Rows[i][4].ToString()) >= dMax)
                    {
                        dMax = double.Parse(dt.Rows[i][4].ToString());
                        sHighest = sKeep;
                    }

                }



                if (cbSummation.Checked)
                    sFooter += "Sum of total salaries to pay:\t"+ dTotal.ToString() + "\n";

                if (cbShowMax.Checked)
                    sFooter += "Max paying employee role:\t"+ sHighest + "\n";

                if (cbShowMinimum.Checked)
                    sFooter += "Min paying employee role:\t"+ sLowest + "\n";
            }


            printer.SubTitle = sSubtitle;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit;

            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;

            
            printer.Footer = sFooter;
            printer.FooterSpacing = 15;

            printer.PrintDataGridView(dataGridView3);

        }

        private static bool IsValidEmail(String EmailToCheck)
        {
            try
            {
                MailAddress mail = new MailAddress(EmailToCheck);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Boolean bflag = false;//Boolean value to test if the password is in the textfile
            int i = 0;//Die counter om die array te populate
            String[] textfilePassword = new String[10000];//Die array wat elke keur eers die passwords gaan lees en seker maak of hulle bestaan

            StreamReader ReadFile;
            ReadFile = File.OpenText("Append.txt");
            while (!ReadFile.EndOfStream)
            {
                i++;
                textfilePassword[i] = ReadFile.ReadLine();//Bernard en Frikkie
            }
            ReadFile.Close();

            String oldPassword = textBox1.Text;//Password wat bestaan etc Bernard en Frikkie
            String newPassword = textBox3.Text; // Nuwe password 
            String doubleNewPassword = textBox2.Text; //Confirm nuwe password

            if (textBox1 != null && textBox2 != null && textBox1 != null)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (textfilePassword[j] == oldPassword)
                    {
                        if (newPassword == doubleNewPassword)
                        {
                            textfilePassword[j] = doubleNewPassword;
                            bflag = true;
                        }
                    }
                }
                if (!bflag)
                {
                    MessageBox.Show("Password doesn't exist in the textbox or the password wasn't typed in correctly the second time.");
                }
            }

            if (bflag)
            {
                File.WriteAllText(@"Append.txt", "");//CHANGE THIS TO COMPUTER PATH
                StreamWriter AppendFile;
                try
                {
                    AppendFile = File.AppendText("Append.txt");
                    for (int j = 1; j <= i; j++)
                    {
                        AppendFile.WriteLine(textfilePassword[j]);
                    }
                    MessageBox.Show("Password changed sucessfully!");
                    AppendFile.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbReportType.Text == "Employee")
            {
                cmbCategorizeRole.Visible = true;
                label51.Visible = false;
                label52.Visible = true;
                cmbCategorizeRoomSize.Visible = false;
            }            
            else if(cmbReportType.Text == "Room")
            {
                cmbCategorizeRole.Visible = false;
                label51.Visible = true;
                label52.Visible = false;
                cmbCategorizeRoomSize.Visible = true;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
