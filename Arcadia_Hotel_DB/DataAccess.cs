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

        public static List<BookingModel> LoadBooking()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BookingModel>("select * from Booking", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<EmployeeModel> LoadEmployee()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EmployeeModel>("select * from Employee", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<GuestModel> LoadGuest()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GuestModel>("select * from Guest", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<RoleModel> LoadRole()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoleModel>("select * from Role", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<RoomModel> LoadRoom()
        {
            using (IDbConnection cnn = new SqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoomModel>("select * from Room", new DynamicParameters());
                return output.ToList();
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








        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}
