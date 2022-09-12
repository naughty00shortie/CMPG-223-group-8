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
    public partial class frmConfirmation : Form
    {

        private Form1 form1;
        private GuestModel guestRecieved;
        private BookingModel bookingRecieved;
        private RoomModel roomRecieved;

        public frmConfirmation(Form1 form1, GuestModel guestRecieved,BookingModel bookingRecieved)
        {
            InitializeComponent();
            this.form1 = form1;
            this.bookingRecieved = bookingRecieved;
            this.guestRecieved = guestRecieved;


            txtName.Text = guestRecieved.Guest_Name;
            txtSurname.Text = guestRecieved.Guest_Surname;
            txtEmail.Text = guestRecieved.Guest_Email;
            txtPhone.Text = guestRecieved.Guest_Phone_Number;

            dtpCheckIn.Text = bookingRecieved.Booking_Check_In.ToString();
            dtpCheckOut.Text = bookingRecieved.Booking_Check_Out.ToString();
            txtPrice.Text = bookingRecieved.Booking_Price_paid.ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {//i am the unknown

            DataAccess.insertGuest(guestRecieved);

            DataAccess.insertBooking(bookingRecieved);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
