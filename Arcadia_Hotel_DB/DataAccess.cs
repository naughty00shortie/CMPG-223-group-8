using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace Arcadia_Hotel_DB
{
    public class DataAccess
    {
        public static List<BookingModel> LoadBooking()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<BookingModel>("select * from Booking", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<EmployeeModel> LoadEmployee()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EmployeeModel>("select * from Employee", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<GuestModel> LoadGuest()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GuestModel>("select * from Guest", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<RoleModel> LoadRole()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoleModel>("select * from Role", new DynamicParameters());
                return output.ToList();
            }
        }     
        
        public static List<RoomModel> LoadRoom()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<RoomModel>("select * from Room", new DynamicParameters());
                return output.ToList();
            }
        }



        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}
