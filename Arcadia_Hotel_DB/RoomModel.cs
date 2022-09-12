using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcadia_Hotel_DB
{
    public class RoomModel
    {
        public int Room_Number { get; set; }
        public string Room_Description { get; set; }
        public int Room_Availability { get; set; }
        public string Room_Size { get; set; }
        public decimal Room_Price_Per_Night { get; set; }
       
    }
}
