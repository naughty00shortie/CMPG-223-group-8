using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcadia_Hotel_DB
{
    public class RoleModel
    {
        public int Role_ID { get; set; }
        public string Role_Description { get; set; }
        public decimal Role_Salary { get; set; }
        public int Role_Hours_Per_Day { get; set; }
    }
}
