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

        private void LoadModels()
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
            foreach (var room in uniqueRoomTypes)
            {
                comboBox1.Items.Add(room.Room_Size);
                cmbTypeER.Items.Add(room.Room_Size);
            }

            dataGridView2.DataSource = bookings;
            dataGridView1.DataSource = guests;

        }

        private void loadUI()
        {
            panel4.Visible = false;
            panel6.Visible = false;

            // Make Page Invisible
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.ActiveHeaderColor = Color.FromArgb(60,60,60);
            tabControl1.ActiveTextColor = Color.FromArgb(60,60,60);
            tabControl1.InActiveTextColor = Color.FromArgb(60,60,60);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            xuiButton4.BackgroundColor = Color.FromArgb(75, 80, 90);

            
        }






        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddR_Click(object sender, EventArgs e)
        {
            GuestModel guest = new GuestModel();
            guest.Guest_Surname = textBox2.Text;
            guest.Guest_Name = textBox3.Text; 
            guest.Guest_Email = textBox4.Text;
            guest.Guest_Phone_Number = textBox5.Text;

            BookingModel booking = new BookingModel();
            booking.Booking_Price_paid = decimal.Parse(txtPrice.Text);
            booking.Booking_Check_In = DateTime.Parse(dtpCheckIn.Text);
            booking.Booking_Check_Out = DateTime.Parse(dtpCheckOut.Text);
            booking.Room_Number = int.Parse(lbBookingInfo.GetItemText(lbBookingInfo.SelectedIndex));

            DataAccess.insertGuest(guest);
            guests = DataAccess.loadGuest();


            DataAccess.insertBooking(booking);
            bookings = DataAccess.loadBooking();

        }

        public decimal calcBookingPrice(decimal price)
        {
            int totalDays = 0;
            totalDays = (int)(DateTime.Parse(dtpCheckIn.Text) - DateTime.Parse(dtpCheckOut.Text)).TotalDays;

            return  price * totalDays;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbBookingInfo.Items.Clear();
            List<RoomModel> availRoom = checkAvailibility();

            foreach (var room in availRoom)
            {
                lbBookingInfo.Items.Add(room.Room_Number+ " " + room.Room_Description);
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

            BookingModel booking = new BookingModel();
            GuestModel guest = new GuestModel();
            RoomModel room = new RoomModel();



            booking.Booking_Number = int.Parse(txtBookingIDER.Text);
            guest.Guest_Name = txtERName.Text;
            guest.Guest_Surname = txtSurnameER.Text;
            room.Room_Size = cmbTypeER.Text;
            booking.Booking_Check_In =  DateTime.Parse(dtpCheckIn.Text);
            booking.Booking_Check_Out = DateTime.Parse(dtpCheckOut.Text); 
            //alles van frontend na backend


            frmConfirmEdit frmConfirmEdit = new frmConfirmEdit(this, booking,guest,room);
            frmConfirmEdit.Show();

            bookings = DataAccess.loadBooking();
        }

        private void btnGoEditReservation_Click(object sender, EventArgs e)
        {
            foreach (var booking in bookings)
            {
                if (booking.Booking_Number == int.Parse(txtBookingER.Text))
                {

                    txtBookingIDER.Text = booking.Booking_Number.ToString();
                    //txtERName.Text = booking.Booking_Name.ToString();
                    //txtSurnameER.Text = booking.Booking_Surname.ToString();
                    
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
                        }
                    }


                    panel4.Visible = true;
                    break;
                }
            }
        }

        private void btnGoEditGuest_Click(object sender, EventArgs e)
        {            
            GuestModel guestModel = new GuestModel();
            foreach (var guest in guests)
            {
                if (guest.Guest_ID == int.Parse(txtGuestIDEG.Text))
                {
                    txtNameEG.Text = guest.Guest_Name;
                    txtSurnameEG.Text = guest.Guest_Surname;
                    txtPhoneEG.Text = guest.Guest_Phone_Number.ToString();
                    txtEmailEG.Text = guest.Guest_Email.ToString();
                    txtGuestIDEG.Text = guest.Guest_ID.ToString();
                }
            }
            frmConfirmationGuest frmConfirmationGuest = new frmConfirmationGuest(this , guestModel);
            panel6.Visible = true;
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataAccess.deleteBooking(int.Parse(txtGuestIDEG.Text));
            }
        }

        private void btnUpdateGuest_Click(object sender, EventArgs e)
        {
            GuestModel guest = new GuestModel();     
            guest.Guest_Name = txtNameEG.Text;
            guest.Guest_Surname = txtSurnameEG.Text;
            guest.Guest_Phone_Number = txtPhoneEG.Text;
            guest.Guest_Email = txtEmailEG.Text;
            guest.Guest_ID = int.Parse(txtGuestIDEG.Text);
            
            frmConfirmationGuest frmConfirmGuest = new frmConfirmationGuest(this, guest);
            frmConfirmGuest.Show();

        }

        private void btnBackEG_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataAccess.deleteBooking(int.Parse(txtBookingER.Text));
            }
        }


        private void setTab(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (sender as XUIButton).TabIndex;
            xuiButton1.BackgroundColor = Color.FromArgb(65, 70, 75);
            xuiButton2.BackgroundColor = Color.FromArgb(65, 70, 75);
            xuiButton3.BackgroundColor = Color.FromArgb(65, 70, 75);
            xuiButton4.BackgroundColor = Color.FromArgb(65, 70, 75);

            (sender as XUIButton).BackgroundColor = Color.FromArgb(75, 80, 90);
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


        private void xuiButton8_Click(object sender, EventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin(this);
            frmAdmin.Show();
            this.Hide();
        }

        private void lbBookingInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var room in rooms)
            {
                if (room.Room_Number == int.Parse(lbBookingInfo.GetItemText(lbBookingInfo.SelectedIndex)))
                {
                    txtPrice.Text = calcBookingPrice(room.Room_Price_Per_Night).ToString("C");
                }
            }
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
 

