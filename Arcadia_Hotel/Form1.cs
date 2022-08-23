using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcadia_Hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======
           // LoadModels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataAccess.LoadBooking();
            // DataAccess.LoadEmployee();
            // DataAccess.LoadGuest();
            roles = DataAccess.LoadRole();
            //DataAccess.LoadRoom();
            dataGridView1.DataSource = roles;
        }

        private void LoadModels()
        {
            DataAccess.LoadBooking();
            DataAccess.LoadEmployee();
            DataAccess.LoadGuest();
            DataAccess.LoadRole();
            DataAccess.LoadRoom();
>>>>>>> Stashed changes
        }
    }
}
