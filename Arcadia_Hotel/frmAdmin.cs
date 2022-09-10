// NEE BERNARD
// JA JACOBUS
using System;                                                                                                                                                                                                                                      
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arcadia_Hotel_DB;
//Lets get that W
namespace Arcadia_Hotel
{
    public partial class frmAdmin : Form
    {
        List<BookingModel> bookings = new List<BookingModel>();
        List<EmployeeModel> employees = new List<EmployeeModel>();
        List<GuestModel> guests = new List<GuestModel>();
        List<RoleModel> roles = new List<RoleModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        private void LoadModels()
        {
            bookings = DataAccess.loadBooking();
            employees = DataAccess.loadEmployee();
            guests = DataAccess.loadGuest();
            roles = DataAccess.loadRole();
            rooms = DataAccess.loadRoom();

            //dgvEditGuest.DataSource = rooms;
            //dgvEditGuest.DataSource = rooms;
        }

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadModels();
            // Tab Control Make Visible
            xuiFlatTab1.Appearance = TabAppearance.FlatButtons;
            xuiFlatTab1.ItemSize = new Size(0, 1);
            xuiFlatTab1.SizeMode = TabSizeMode.Fixed;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            RoomModel room = new RoomModel();

            room.Room_Description = redRoleDescription.Text;
            room.Room_Number = (int)nupdRoomAmount.Value;
            room.Room_Size = txtRoomSize.Text;
            room.Room_Price_Per_Night = float.Parse(txtRoomPrice.Text);

            DataAccess.insertRoom(room);
            LoadModels();

        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            RoleModel role = new RoleModel();

            foreach (var roleModel in roles)
                cmbRoleUR.Items.Add(roleModel.Role_ID);

            role.Role_Description = txtDescriptionUR.Text;
            role.Role_Salary = float.Parse(txtSalaryUR.Text);
            role.Role_Hours_Per_Day = int.Parse(txtHoursUR.Text);

            DataAccess.updateRole(role);
            LoadModels();

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
           EmployeeModel employee = new EmployeeModel();

           employee.Role_ID = int.Parse(cmbRoleUR.Text);
           employee.Employee_Surname = txtSurnameAE.Text;
           employee.Employee_Name = txtNameAE.Text; 
           employee.Employee_Email = txtEmailAE.Text;
           employee.Employee_Date_Of_Birth = dtpBirthDateAE.Text ;

           DataAccess.insertEmployee(employee);
           LoadModels();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            RoleModel role = new RoleModel();

            role.Role_Description = redRoleDescription.Text;
            role.Role_Salary = float.Parse(txtSalaryAR.Text);
            role.Role_Hours_Per_Day = int.Parse(txtHoursAR.Text);

            DataAccess.insertRole(role);
            LoadModels();
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            //? i came in like a wrecking ball
            foreach (var room in rooms)
            {
                if (int.Parse(cmbRoomID.Text) == room.Room_Number)
                {
                    DataAccess.deleteRoom(room.Room_Number);
                    break;
                }
            }
            LoadModels();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            foreach(var employee in employees)
            {
                if(txtNameAE.Text == employee.Employee_Name)
                {
                    DataAccess.deleteRole(employee.Employee_ID);
                    break;
                }
            }

            LoadModels();
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            RoomModel room = new RoomModel();
            room.Room_Description = redRoomDescription.Text;
            room.Room_Size = txtSizeUR.Text;
            room.Room_Price_Per_Night = int.Parse(txtPriceUR.Text);
            DataAccess.updateRoom(room);
            
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            foreach (var role in roles)
            {
                if (int.Parse(comboBox1.Text) == role.Role_ID)
                {
                    DataAccess.deleteRole(role.Role_ID);
                    break;
                }
            }
            LoadModels();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = new EmployeeModel();
            RoleModel role = new RoleModel();
            employee.Employee_Surname = textBox4.Text;
            employee.Employee_Name = textBox5.Text;
            role.Role_ID = int.Parse(comboBox2.Text);
            employee.Employee_Date_Of_Birth = dateTimePicker1.Text;
            employee.Employee_Email = textBox6.Text;
            DataAccess.updateEmployee(employee);

            LoadModels();
        }
    }
}
