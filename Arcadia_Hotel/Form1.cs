using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Arcadia_Hotel_DB;
using Squirrel;
using XanderUI;
using System.Net.Mail;

namespace Arcadia_Hotel
{
    public partial class Form1 : Form
    {
        List<BookingModel> bookings = new List<BookingModel>();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<GuestModel> guests = new List<GuestModel>();
        List<RoleModel> roles = new List<RoleModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private int[] arrQry1 = Array.Empty<int>();
        private int[] arrQry2 = Array.Empty<int>();


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private async Task CheckForUpdates()
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager(@"https://github.com/naughty00shortie/Arcadia_Hotel_Installation"))
            {
                await mgr.UpdateApp();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadModels();
            loadUI();
            CheckForUpdates();

        }

        public void LoadModels()
        {

            bookings = DataAccess.loadBooking();
            employees = DataAccess.loadEmployee();
            guests = DataAccess.loadGuest();
            roles = DataAccess.loadRole();
            rooms = DataAccess.loadRoom();

            comboBox1.Items.Clear();
            List<RoomModel> uniqueRoomSizeList = DataAccess.loadUniqueRoom();
            foreach (var room in uniqueRoomSizeList)
                comboBox1.Items.Add(room.Room_Size);

            comboBox1.Items.Clear();
            List<RoomModel> uniqueRoomTypes = DataAccess.loadUniqueRoom();
            cmbTypeER.Items.Clear();
            cmbTypeER.Items.Clear();
            foreach (var room in uniqueRoomTypes)
            {
                comboBox1.Items.Add(room.Room_Size);
                cmbTypeER.Items.Add(room.Room_Size);
            }



            cmbBookingER.Items.Clear();
            foreach (var booking in bookings)
            {
                cmbBookingER.Items.Add(booking.Booking_Number);
            }

            cmbGuestIDEG.Items.Clear();
            foreach (var guest in guests)
            {
                cmbGuestIDEG.Items.Add(guest.Guest_ID);
            }

            dataGridView2.DataSource = bookings;
            dataGridView1.DataSource = guests;
            dataGridView3.DataSource = guests;


            foreach (var booking in bookings)
            {
                if (booking.Booking_Check_In > DateTime.Now && booking.Booking_Check_Out < DateTime.Now )
                    foreach (var room in rooms)
                    {
                        if (booking.Room_Number == room.Room_Number)
                        {
                            room.Room_Availability = 0;
                            DataAccess.updateRoom(room);
                        }
                    }
                else
                {
                    foreach (var room in rooms)
                    {
                        if (booking.Room_Number == room.Room_Number)
                        {
                            room.Room_Availability = 1;
                            DataAccess.updateRoom(room);
                        }
                    }
                }
            }

        }

        private void loadUI()
        {
            panel4.Visible = false;
            panel6.Visible = false;

            // Make Page Invisible
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.ActiveHeaderColor = Color.FromArgb(60, 60, 60);
            tabControl1.ActiveTextColor = Color.FromArgb(60, 60, 60);
            tabControl1.InActiveTextColor = Color.FromArgb(60, 60, 60);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            xuiButton4.BackgroundColor = Color.FromArgb(75, 80, 90);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddR_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox4.Text))
            {
                MessageBox.Show("Enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox5.Text.Length == 10)
            {
                if (!(int.TryParse(textBox5.Text, out int phonenum)))
                {
                    MessageBox.Show("Enter a valid phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter a valid phone number.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Enter Surname", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox3.Text == "")
            {
                MessageBox.Show("Enter Name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(lbBookingInfo.SelectedIndex == null)
            {
                MessageBox.Show("Select Room number", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if((DateTime.Parse(dtpCheckIn.Text) > DateTime.Parse(dtpCheckOut.Text)) || (DateTime.Parse(dtpCheckIn.Text) < DateTime.Today))
            {
                MessageBox.Show("Input valid Date", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GuestModel guest = new GuestModel();
            guest.Guest_Surname = textBox2.Text;
            guest.Guest_Name = textBox3.Text;
            guest.Guest_Email = textBox4.Text;
            guest.Guest_Phone_Number = textBox5.Text;

            BookingModel booking = new BookingModel();
            booking.Booking_Price_paid = decimal.Parse(txtPrice.Text);
            booking.Booking_Check_In = DateTime.Parse(dtpCheckIn.Text);
            booking.Booking_Check_Out = DateTime.Parse(dtpCheckOut.Text);
            booking.Room_Number = arrQry1[lbBookingInfo.SelectedIndex];

            frmConfirmation frmConfirmation = new frmConfirmation(this, guest, booking);
            frmConfirmation.Show();
            lbBookingInfo.Items.Clear();

            btnAddR.Visible = false;
        }

        public decimal calcBookingPrice(decimal price,DateTime beginDateTime, DateTime endDateTime)
        {

            int totalDays = (int)(endDateTime -  beginDateTime).TotalDays;

            return price * totalDays;
        }

        public void button4_Click(object sender, EventArgs e)//query
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Room Type Invalid", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbBookingInfo.Items.Clear();
            List<RoomModel> availRoom = checkAvailibility();

            if(DateTime.Parse(dtpCheckIn.Text) > DateTime.Parse(dtpCheckOut.Text))
            {
                MessageBox.Show("Input valid date", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int i = 0;
            arrQry1 = new int[0];
            foreach (var room in availRoom)
            {
                if (room.Room_Size == comboBox1.Text)
                {
                    Array.Resize(ref arrQry1,arrQry1.Length+1);
                    lbBookingInfo.Items.Add(room.Room_Number + " " + room.Room_Description);
                    arrQry1[i] = room.Room_Number;
                    i++;
                }
                
            }
        }

        private List<RoomModel> checkAvailibility()
        {
            bool flag = false;
            DateTime beginDate = DateTime.Parse(dtpCheckIn.Text);
            DateTime endDate = DateTime.Parse(dtpCheckOut.Text);
            List<RoomModel> availRoom = new List<RoomModel>();
            RoomModel roomModel = null;

            foreach (var room in rooms)
            {
                flag = true;
                foreach (var booking in bookings)
                {
                    if (room.Room_Number == booking.Room_Number)
                    {
                        if (beginDate < booking.Booking_Check_Out &&
                            booking.Booking_Check_In < endDate) //check if dates overlap
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                    availRoom.Add(room);
            }

            return availRoom;
        }



        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            
            if(cmbTypeER.SelectedItem == null)
            {
                MessageBox.Show("Enter room size", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtERName.Text == "")
            {
                MessageBox.Show("Enter Guest Name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtSurnameER.Text == "")
            {
                MessageBox.Show("Enter Guest Surname", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cmbTypeER.Text == "")
            {
                MessageBox.Show("Enter Room Size", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if((DateTime.Parse(dtpCheckIn.Text) > DateTime.Parse(dtpCheckOut.Text)) || (DateTime.Parse(dtpCheckIn.Text) < DateTime.Today))
            {
                MessageBox.Show("Input valid date", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BookingModel booking = new BookingModel();

            booking.Booking_Number = int.Parse(cmbBookingER.Text);
            booking.Booking_Check_In = DateTime.Parse(dtpCheckIn.Text);
            booking.Booking_Check_Out = DateTime.Parse(dtpCheckOut.Text);

            foreach (var bookingModel in bookings)
            {
                if (bookingModel.Booking_Number == int.Parse(cmbBookingER.Text))
                {
                    booking.Guest_ID = bookingModel.Guest_ID;
                    break;
                }
            }

            foreach (var room in rooms)
            {
                if (room.Room_Number == arrQry2[listBox1.SelectedIndex])
                {
                    booking.Room_Number = room.Room_Number;
                    booking.Booking_Price_paid = calcBookingPrice(room.Room_Price_Per_Night,DateTime.Parse(dtpCheckInER.Text),DateTime.Parse(dtpCheckOutER.Text));
                    break;
                }
            }



            frmConfirmEdit frmConfirmEdit = new frmConfirmEdit(this, booking);
            frmConfirmEdit.Show();
            panel4.Visible = false;
            cmbBookingER.Text = "";
        }

        private void btnGoEditReservation_Click(object sender, EventArgs e)
        {
            if (cmbBookingER.SelectedItem == null)
            {
                MessageBox.Show("Booking ID Invalid", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var booking in bookings)
            {
                if (booking.Booking_Number == int.Parse(cmbBookingER.Text))
                {
                    dtpCheckInER.Text = booking.Booking_Check_In.ToString();
                    dtpCheckOutER.Text = booking.Booking_Check_Out.ToString();
                    foreach (var guest in guests)
                    {
                        if (guest.Guest_ID == booking.Guest_ID)
                        {
                            txtERName.Text = guest.Guest_Name;
                            txtSurnameER.Text = guest.Guest_Surname;
                            break;
                        }

                    }

                    foreach (var room in rooms)
                    {
                        if (room.Room_Number == booking.Room_Number)
                        {
                            cmbTypeER.Text = room.Room_Size;
                            break;
                        }
                    }

                    panel4.Visible = true;
                    break;
                }
            }
        }

        private void btnGoEditGuest_Click(object sender, EventArgs e)
        {
            if (cmbGuestIDEG.SelectedItem == null)
            {
                MessageBox.Show("Guest ID invalid", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            GuestModel guestModel = new GuestModel();
            foreach (var guest in guests)
            {
                if (guest.Guest_ID == int.Parse(cmbGuestIDEG.Text))
                {
                    txtNameEG.Text = guest.Guest_Name;
                    txtSurnameEG.Text = guest.Guest_Surname;
                    txtPhoneEG.Text = guest.Guest_Phone_Number.ToString();
                    txtEmailEG.Text = guest.Guest_Email.ToString();
                    cmbGuestIDEG.Text = guest.Guest_ID.ToString();
                }
            }
            panel6.Visible = true;
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if(cmbGuestIDEG.SelectedItem == null)
            {
                MessageBox.Show("Select a Guest ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var booking in bookings)
                {
                    if (int.Parse(cmbGuestIDEG.Text) == booking.Guest_ID)
                    {
                        DataAccess.deleteBooking(booking.Booking_Number);
                    }
                }
                DataAccess.DeleteGuest(int.Parse(cmbGuestIDEG.Text));
            }

            LoadModels();
        }

        private void btnUpdateGuest_Click(object sender, EventArgs e)
        {
            
            if (IsValidEmail(txtEmailEG.Text))
            {
                MessageBox.Show("Enter a valid email address.");
                return;
            }
            
            if(cmbGuestIDEG.SelectedItem == null)
            {
                MessageBox.Show("Select a Guest ID", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPhoneEG.Text.Length == 10)
            {
                if (!(int.TryParse(txtPhoneEG.Text, out int phonenum)))
                {
                    MessageBox.Show("Enter a valid phone number.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter a valid phone number.");
                return;
            }
            
            if(txtNameEG.Text == "")
            {
                MessageBox.Show("Enter Name", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(txtSurnameEG.Text == "")
            {
                MessageBox.Show("Enter Surname", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GuestModel guest = new GuestModel();
            guest.Guest_Name = txtNameEG.Text;
            guest.Guest_Surname = txtSurnameEG.Text;
            guest.Guest_Phone_Number = txtPhoneEG.Text;
            guest.Guest_Email = txtEmailEG.Text;
            guest.Guest_ID = int.Parse(cmbGuestIDEG.Text);

            frmConfirmationGuest frmConfirmGuest = new frmConfirmationGuest(this,guest);
            frmConfirmGuest.Show();

            panel6.Visible = false;

            cmbGuestIDEG.Text = "";
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (cmbBookingER.SelectedItem == null)
            {
                MessageBox.Show("Booking ID Invalid", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataAccess.deleteBooking(int.Parse(cmbBookingER.Text));
               
            }
            LoadModels();
        }

        private void setTab(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (sender as XUIButton).TabIndex;
            xuiButton1.BackgroundColor = Color.FromArgb(65, 70, 75);
            xuiButton2.BackgroundColor = Color.FromArgb(65, 70, 75);
            xuiButton3.BackgroundColor = Color.FromArgb(65, 70, 75);
            xuiButton4.BackgroundColor = Color.FromArgb(65, 70, 75);

            (sender as XUIButton).BackgroundColor = Color.FromArgb(75, 80, 90);
            panel4.Visible = false;
            panel6.Visible = false;
        }

        private void xuiButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }


        private void xuiButton8_Click(object sender, EventArgs e)//Login
        {
            Boolean bflag = false;//Boolean value to test if the password is in the textfile
            int i = 0;//Die counter om die array te populate
            String[] textfilePassword = new String[10000];//Die array wat elke keur eers die passwords gaan lees en seker maak of hulle bestaan

            StreamReader ReadFile;
            ReadFile = File.OpenText("Append.txt");
            while (!ReadFile.EndOfStream)
            {
                i++;
                textfilePassword[i] = ReadFile.ReadLine();
            }
            ReadFile.Close();

            String password = textBox1.Text;//Get the password in the textbox

            for (int j = 1; j <= i; j++)
            {
                if (textfilePassword[j] == password)
                {
                    frmAdmin frmAdmin = new frmAdmin(this);
                    frmAdmin.Show();
                    this.Hide();
                    bflag = true;
                }
            }

            textBox1.Text = "";
            if (!bflag)
            {
                MessageBox.Show("This password doesn't exist in the textfile");
            }
        }

        private void lbBookingInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var room in rooms)
            {
                if (room.Room_Number == arrQry1[lbBookingInfo.SelectedIndex])
                {
                    txtPrice.Text = calcBookingPrice(room.Room_Price_Per_Night,DateTime.Parse(dtpCheckIn.Text),DateTime.Parse(dtpCheckOut.Text)).ToString();
                }
            }

            btnAddR.Visible = true;
        }

        private static bool IsValidEmail(String EmailToCheck)
        {
            try
            {
                MailAddress mail = new MailAddress(EmailToCheck);
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        private void txtSearchER_TextChanged(object sender, EventArgs e)
        {

            List<GuestModel> wildGuests = DataAccess.loadWildCardGuests(txtSearchER.Text);
            try
            {
                dataGridView3.DataSource =
                    DataAccess.queryReport($"SELECT * FROM Guest WHERE Guest_Surname LIKE '%{txtSearchER.Text}%'");
            }
            catch (Exception exception)
            {
                dataGridView3.DataSource = null;
            }


        }


        private void btnQryRooms_Click(object sender, EventArgs e)
        {

            if (cmbTypeER.SelectedItem == null)
            {
                MessageBox.Show("Room type Invalid", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            listBox1.Items.Clear();
            List<RoomModel> availRoom = checkAvailibility();

            if (DateTime.Parse(dtpCheckInER.Text) > DateTime.Parse(dtpCheckOutER.Text))
            {
                MessageBox.Show("Input valid date", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int i = 0;
            arrQry2 = new int[0];
            foreach (var room in availRoom)
            {
                if (room.Room_Size == cmbTypeER.Text)
                {
                    Array.Resize(ref arrQry2, arrQry2.Length + 1);
                    listBox1.Items.Add(room.Room_Number + " " + room.Room_Description);
                    arrQry2[i] = room.Room_Number;
                    i++;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var room in rooms)
            {
                if (room.Room_Number == arrQry2[listBox1.SelectedIndex])
                {
                    foreach (var booking in bookings)
                    {
                        if (booking.Booking_Number == int.Parse(cmbBookingER.Text))
                        {
                            textBox6.Text = (calcBookingPrice(room.Room_Price_Per_Night, DateTime.Parse(dtpCheckInER.Text),DateTime.Parse(dtpCheckOutER.Text)) - booking.Booking_Price_paid).ToString();
                        }   
                    }
                    break;
                }
            }
        }

        private void txtSearchEG_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource =
                DataAccess.queryReport($"SELECT * FROM Guest WHERE Guest_Surname Like '%{txtSearchEG.Text}%'");
        }
    }
}
/*Waar daar staan Model beteken dit is n tabel in die DB
Om dit te access moet jy n nuwe object create van daai datatype af
die lists van die tables is bo aan create. die lists het die naam van die table plus n "s" bv bookings
lists werk baie goed in n foreach loop bv.    foreach (var room in rooms) dan is room n rekord in die tabel 
en rooms die lys. om data in die DB in te lees moet daar eers n nuwe rekord create word bv. GuestModel guest = new GuestModel();
dan lees jy die data in die rekord bv. guest.Guest_Name = "Koos";
Dan kan DataAccess.insertGuest(guest); gecall word om die data in te lees. Na die tyd moet guests =  DataAccess.LoadGuest(); 
gecall word om die data te update;
Prof Linda is luuks
 */
//prof linda is die beste prof op die kampus ( ͡❛ ͜ʖ ͡❛) en ek wil graag by haar my hoeneers doen in all die DB vakke -- Albertus & Bernard. Ian wil sekuriteit doen, eew.
//Plaas die url in Google vir n goeie tyd https://www.youtube.com/watch?v=dQw4w9WgXcQ