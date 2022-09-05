using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace Arcadia_Hotel_DB
{
    public class DataAccess
    {

        #region SELECT

        public static List<BookingModel> loadBooking()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BookingModel>("select * from Booking", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<EmployeeModel> loadEmployee()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EmployeeModel>("select * from Employee", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<GuestModel> loadGuest()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GuestModel>("select * from Guest", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<RoleModel> loadRole()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoleModel>("select * from Role", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<RoomModel> loadRoom()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoomModel>("select * from Room", new DynamicParameters());
                return output.ToList();
            }
        }

        public static DataTable querySQL(String query)
        {
            using (SqlConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(query, cnn);
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                cnn.Close();
                return ds.Tables[0];
            }
        }

        #endregion

        #region INSERT

        public static void insertBooking(BookingModel booking)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute(
                    "INSERT into BOOKING(Room_Number,Guest_ID,Booking_Check_In,Booking_Check_Out,Booking_Price_Paid) VALUES (@Room_Number,@Guest_ID,@Booking_Check_In,@Booking_Check_Out,@Booking_Price_Paid)",
                    booking);
            }
        }


        public static void insertEmployee(EmployeeModel employee)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute(
                    "INSERT into EMPLOYEE(Role_ID,Employee_Surname,Employee_Name,Employee_Date_Of_Birth,Employee_Email) VALUES (@Role_ID,Employee_Surname,@Employee_Name,@Employee_Date_Of_Birth,@Employee_Email)",
                    employee);
            }
        }

        public static void insertGuest(GuestModel guest)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute(
                    "INSERT into GUEST(Role_ID,Employee_Surname,Employee_Name,Employee_Date_Of_Birth,Employee_Email) VALUES (@Role_ID,Employee_Surname,@Employee_Name,@Employee_Date_Of_Birth,@Employee_Email)",
                    guest);
            }
        }

        public static void insertRoom(RoomModel room)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute(
                    "INSERT into ROOM(Role_ID,Employee_Surname,Employee_Name,Employee_Date_Of_Birth,Employee_Email) VALUES (@Role_ID,Employee_Surname,@Employee_Name,@Employee_Date_Of_Birth,@Employee_Email)",
                    room);
            }
        }



        #endregion

        #region UPDATE

        public static void updateBooking(BookingModel booking,int iD)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute(
                    "INSERT into ROOM(Role_ID,Employee_Surname,Employee_Name,Employee_Date_Of_Birth,Employee_Email) VALUES (@Role_ID,Employee_Surname,@Employee_Name,@Employee_Date_Of_Birth,@Employee_Email)",
                    booking);
            }
        }

        #endregion

        #region DELETE


        public static void DeleteBooking(int iD)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"DELETE Booking WHERE {iD} = Booking_Number");
            }
        }

        public static void DeleteGuest(int iD)
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"DELETE Guest WHERE {iD} = Guest_ID");
            }
        }


        #endregion






        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}
