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
    public partial class frmConfirmation : Form
    {
        List<BookingModel> bookings = new List<BookingModel>();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<GuestModel> guests = new List<GuestModel>();
        List<RoleModel> roles = new List<RoleModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        private Form1 form1;
        private GuestModel guestRecieved;
        private BookingModel bookingRecieved;
        private RoomModel roomRecieved;
        private int iAmount;

        public frmConfirmation(Form1 form1, GuestModel guestRecieved,BookingModel bookingRecieved,int iAmount)
        {
            InitializeComponent();
            this.form1 = form1;
            this.bookingRecieved = bookingRecieved;
            this.guestRecieved = guestRecieved;
            this.iAmount = iAmount;


            txtName.Text = guestRecieved.Guest_Name;
            txtSurname.Text = guestRecieved.Guest_Surname;
            txtEmail.Text = guestRecieved.Guest_Email;
            txtPhone.Text = guestRecieved.Guest_Phone_Number;

            dtpCheckIn.Text = bookingRecieved.Booking_Check_In.ToString();
            dtpCheckOut.Text = bookingRecieved.Booking_Check_out.ToString();
            txtBookingID.Text = bookingRecieved.Booking_Number.ToString();
            txtPrice.Text = bookingRecieved.Booking_Price_paid.ToString();

            txtAmount.Text = iAmount.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {//i am the unknown
            DataAccess.insertGuest(guestRecieved);

            BookingModel booking = new BookingModel();

            DataAccess.insertBooking(bookingRecieved);

            RoomModel room = new RoomModel();

            DataAccess.insertRoom(roomRecieved);
        }
    }
}
