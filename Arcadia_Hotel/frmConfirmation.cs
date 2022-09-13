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

        private List<RoomModel> rooms;
        private List<GuestModel> guests;

        private Form1 form1;
        private GuestModel guestRecieved;
        private BookingModel bookingRecieved;
        private RoomModel roomRecieved;


        public frmConfirmation(Form1 form1, GuestModel guestRecieved,BookingModel bookingRecieved)
        {
            InitializeComponent();

            rooms = DataAccess.loadRoom();

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

            foreach (var room in rooms)
            {
                if (room.Room_Number == bookingRecieved.Room_Number)
                {
                    textBox1.Text = room.Room_Size;
                    break;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {//i am the unknown

            DataAccess.insertGuest(guestRecieved);
            int biggest = 0;
            guests = DataAccess.loadGuest();
            foreach (var guest in guests)
            {
                if (guest.Guest_ID> biggest)
                {
                    biggest = guest.Guest_ID;
                }  
            }

            bookingRecieved.Guest_ID = biggest;
            DataAccess.insertBooking(bookingRecieved);
            form1.LoadModels();

             MessageBox.Show("Successfully added reservation for " + guestRecieved.Guest_Name);
             this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            form1.button4_Click(null, EventArgs.Empty);
            this.Close();
        }
    }
}
