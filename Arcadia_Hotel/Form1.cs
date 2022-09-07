﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcadia_Hotel_DB;

namespace Arcadia_Hotel
{
    public partial class Form1 : Form
    {
        List<BookingModel> bookings = new List<BookingModel>();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<GuestModel> guests = new List<GuestModel>();
        List<RoleModel> roles = new List<RoleModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadModels();
            panel4.Visible = false;
            panel6.Visible = false;

            // Make Page Invisible
            tabControl1.Appearance = TabAppearance.FlatButtons; 
            tabControl1.ItemSize = new Size(0, 1); 
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void LoadModels()
        {
            bookings = DataAccess.loadBooking();
            employees = DataAccess.loadEmployee();
            guests = DataAccess.loadGuest();
            roles = DataAccess.loadRole();
            rooms = DataAccess.loadRoom();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
         {
        //     BookingModel model = new BookingModel();
        //     foreach (var booking in bookings)
        //     {
        //         comboBox1.Items.Add(booking);
        //     }
        //
        //     model.Booking_Check_In = "1";
        //     model.Booking_Check_out = "1";
        //
        //
        //     DataAccess.InsertBooking(model);
        //    bookings = DataAccess.LoadBooking();



        }

        private void btnMakeR_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnEditR_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
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
            booking.Booking_Price_paid = calcBookingPrice();
            txtPrice.Text = calcBookingPrice().ToString();
            booking.Booking_Check_In = DateTime.Parse(dtpCheckIn.Text);
            booking.Booking_Check_Out = DateTime.Parse(dtpCheckOut.Text);

            DataAccess.insertGuest(guest);
            guests = DataAccess.loadGuest();

            for (int i = 0; i < nudRoomAmount.Value; i++)
            {
                DataAccess.insertBooking(booking);
                bookings = DataAccess.loadBooking();
            }
        }

        public float calcBookingPrice()
        {
            int totalDays = 0;
            totalDays = (int)(DateTime.Parse(dtpCheckIn.Text) - DateTime.Parse(dtpCheckOut.Text)).TotalDays;

            float price = 0;
            if(comboBox1.SelectedIndex == 0) { price = 1; }
            else if (comboBox1.SelectedIndex == 1) { price = 2; }
            else { price = 3; }

            return  price * totalDays * (int)nudRoomAmount.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbBookingInfo.Items.Clear();
            List<RoomModel> availRoom = checkAvailibility();

            foreach (var room in availRoom)
            {
                lbBookingInfo.Items.Add(room.Room_Description);
            }
        }

        private List<RoomModel> checkAvailibility()
        {
            List<RoomModel> availRoom = new List<RoomModel>();//
            foreach (var room in rooms)
            {
                if (room.Room_Availability == 1)
                {
                   availRoom.Add(room);
                }
            }

            return availRoom;
        }

        private void btnBackMR_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
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
                DataAccess.DeleteBooking(int.Parse(txtGuestIDEG.Text));
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
                DataAccess.DeleteBooking(int.Parse(txtBookingER.Text));
            }
        }

        private void btnBackER_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
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
 //prof linda is die beste prof op die kampus ( ͡❛ ͜ʖ ͡❛)
 

