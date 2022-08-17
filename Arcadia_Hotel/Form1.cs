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
            LoadModels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataAccess.LoadBooking();
            DataAccess.LoadEmployee();
            DataAccess.LoadGuest();
            DataAccess.LoadRole();
            DataAccess.LoadRoom();
            dataGridView1.DataSource = bookings;
        }

        private void LoadModels()
        {
            DataAccess.LoadBooking();
            DataAccess.LoadEmployee();
            DataAccess.LoadGuest();
            DataAccess.LoadRole();
            DataAccess.LoadRoom();
        }
    }
}
