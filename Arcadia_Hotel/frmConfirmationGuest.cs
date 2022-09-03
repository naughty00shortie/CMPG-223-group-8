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
    public partial class frmConfirmationGuest : Form
    {
        private Form1 form1;
        private GuestModel guest;

        public frmConfirmationGuest(Form1 form1,GuestModel guest)
        {
            InitializeComponent();
            this.form1 = form1;
            this.guest = guest;

            txtName.Text = guest.Guest_Name;
            txtSurname.Text = guest.Guest_Surname;
            txtGuestId.Text = guest.Guest_ID.ToString();
            txtEmail.Text = guest.Guest_Email;
            txtPhone.Text = guest.Guest_Phone_Number;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DataAccess.insertGuest(guest);
            form1.Show();
        }
    }
}
