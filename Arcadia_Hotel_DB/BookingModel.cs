using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcadia_Hotel_DB
{
    public class BookingModel
    {
        public int Booking_Number { get; set; }
        public int Room_Number { get; set; }
        public int Guest_ID { get; set; }
        public string Booking_Check_In { get; set; }
        public string Booking_Check_out { get; set; }
        public int Booking_Price_paid { get; set; }
    }
}
