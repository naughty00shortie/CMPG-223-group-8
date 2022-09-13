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
        private BookingModel bookingRecieved;
        private GuestModel selectedGuest;
        private RoomModel selectedRoom;

        private List<GuestModel> guests;
        private List<RoomModel> rooms;
        private Form1 form1;

        public frmConfirmEdit(Form1 form1,BookingModel bookingRecieved)
        {
            this.form1 = form1;
            InitializeComponent();
            this.bookingRecieved = bookingRecieved;

            guests = DataAccess.loadGuest();
            rooms = DataAccess.loadRoom();

            foreach (var guest in guests)
                if (guest.Guest_ID == bookingRecieved.Guest_ID)
                {
                    selectedGuest = guest;
                    break;
                }

            foreach (var room in rooms)
            {
                if (room.Room_Number == bookingRecieved.Room_Number)
                {
                    selectedRoom = room;
                }
            }

            txtBookingID.Text = bookingRecieved.Booking_Number.ToString();
            txtName.Text = selectedGuest.Guest_Name;
            txtSurname.Text = selectedGuest.Guest_Surname;
            txtRoomType.Text = selectedRoom.Room_Size;
            dtpCheckIn.Text = bookingRecieved.Booking_Check_In.ToString();
            dtpCheckOut.Text = bookingRecieved.Booking_Check_Out.ToString();
            txtPrice.Text = bookingRecieved.Booking_Price_paid.ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            DataAccess.updateBooking(bookingRecieved);
            form1.LoadModels();
            this.Close();
            
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}