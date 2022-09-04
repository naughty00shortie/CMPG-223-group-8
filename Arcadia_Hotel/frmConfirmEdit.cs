using System;
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
    public partial class frmConfirmEdit : Form
    {


        private Form1 form1;
        private BookingModel bookingRecieved;


        public frmConfirmEdit(Form1 form1,BookingModel bookingRecieved)
        {
            InitializeComponent();
            this.form1 = form1;
            this.bookingRecieved = bookingRecieved;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GuestModel guest = new GuestModel();
            BookingModel booking = new BookingModel();
            RoomModel room = new RoomModel();

            guest.Guest_Name = txtName.Text;
            guest.Guest_Surname = txtSurname.Text;

            room.Room_Description = comboBox1.Text;

            txtPrice.Text = bookingRecieved.Booking_Price_paid.ToString();


            DataAccess.updateBooking(booking,booking.Room_Number);
        }
    }
}